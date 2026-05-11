# Build the native shim with Zig, then run BenchmarkDotNet for each requested
# .NET TFM. Defaults to net10.0 if no TFMs are passed.
#
# Usage:
#   .\run.ps1                          # net10.0 only, full job
#   .\run.ps1 net8.0 net10.0 net481    # one run per TFM, sequentially
#   .\run.ps1 -Short                   # BenchmarkDotNet Short job (fewer iterations, faster)
#   .\run.ps1 -Short net8.0 net10.0    # Short job across multiple TFMs
#   .\run.ps1 --Aot                    # Include net10.0 NativeAOT benchmarks

[CmdletBinding()]
param(
    [switch] $Short,
    [switch] $Aot,
    [Parameter(Position = 0, ValueFromRemainingArguments = $true)]
    [string[]] $Tfms = @('net10.0')
)

$ErrorActionPreference = 'Stop'

$root      = Split-Path -Parent $MyInvocation.MyCommand.Path
$nativeDir = Join-Path $root 'native'
$benchDir  = Join-Path $root 'benchmark'

if (-not (Get-Command zig -ErrorAction SilentlyContinue)) {
    throw "zig not found on PATH. Install from https://ziglang.org/download/"
}
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    throw "dotnet not found on PATH."
}

Write-Host "==> Building native shim with zig (ReleaseFast)" -ForegroundColor Cyan
Push-Location $nativeDir
try {
    & zig build -Doptimize=ReleaseFast
    if ($LASTEXITCODE -ne 0) { throw "zig build failed" }
} finally { Pop-Location }

$job = if ($Short) { 'Short' } else { 'Default' }

if ($Aot) {
    Write-Host ""
    Write-Host "==> Running benchmarks on .NET 10 NativeAOT (job: $job)" -ForegroundColor Cyan
    Push-Location $benchDir
    try {
        $env:CustomBeforeMicrosoftCommonTargets = Join-Path $root 'nativeaot-bench.targets'
        try {
            & dotnet run -c Release -f net10.0 -- --filter '*' --job $job --runtimes nativeaot10.0
            if ($LASTEXITCODE -ne 0) { throw "dotnet run failed for net10.0 NativeAOT" }
        } finally {
            Remove-Item Env:\CustomBeforeMicrosoftCommonTargets -ErrorAction SilentlyContinue
        }
    } finally { Pop-Location }
}

foreach ($tfm in $Tfms) {
    Write-Host ""
    Write-Host "==> Running benchmarks on $tfm (job: $job)" -ForegroundColor Cyan
    Push-Location $benchDir
    try {
        & dotnet run -c Release -f $tfm -- --filter '*' --job $job
        if ($LASTEXITCODE -ne 0) { throw "dotnet run failed for $tfm" }
    } finally { Pop-Location }
}

Write-Host ""
Write-Host "==> Done. Reports under benchmark/BenchmarkDotNet.Artifacts/results/" -ForegroundColor Green
