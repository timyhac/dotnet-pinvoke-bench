#!/usr/bin/env bash
# Build the native shim with Zig, then run BenchmarkDotNet for each requested
# .NET TFM. Defaults to net8.0 if no TFMs are passed.
#
# Usage:
#   ./run.sh                          # net8.0 only
#   ./run.sh net8.0 net10.0           # one run per TFM, sequentially

set -euo pipefail

root="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
native_dir="$root/native"
bench_dir="$root/benchmark"

tfms=("$@")
if [[ ${#tfms[@]} -eq 0 ]]; then tfms=(net8.0); fi

if ! command -v zig    >/dev/null 2>&1; then echo "zig not found on PATH"    >&2; exit 1; fi
if ! command -v dotnet >/dev/null 2>&1; then echo "dotnet not found on PATH" >&2; exit 1; fi

echo "==> Building native shim with zig (ReleaseFast)"
( cd "$native_dir" && zig build -Doptimize=ReleaseFast )

for tfm in "${tfms[@]}"; do
    echo
    echo "==> Running benchmarks on $tfm"
    ( cd "$bench_dir" && dotnet run -c Release -f "$tfm" -- --job Default )
done

echo
echo "==> Done. Reports under benchmark/BenchmarkDotNet.Artifacts/results/"
