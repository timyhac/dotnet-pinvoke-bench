const std = @import("std");

const Rid = struct {
    name: []const u8,
    query: std.Target.Query,
};

const default_rids = [_]Rid{
    .{ .name = "win-x64",     .query = .{ .cpu_arch = .x86_64,  .os_tag = .windows, .abi = .gnu } },
    .{ .name = "linux-x64",   .query = .{ .cpu_arch = .x86_64,  .os_tag = .linux,   .abi = .gnu } },
    .{ .name = "linux-arm64", .query = .{ .cpu_arch = .aarch64, .os_tag = .linux,   .abi = .gnu } },
    .{ .name = "osx-x64",     .query = .{ .cpu_arch = .x86_64,  .os_tag = .macos } },
    .{ .name = "osx-arm64",   .query = .{ .cpu_arch = .aarch64, .os_tag = .macos } },
};

pub fn build(b: *std.Build) void {
    const optimize = b.standardOptimizeOption(.{});

    for (default_rids) |rid| {
        const target = b.resolveTargetQuery(rid.query);

        const mod = b.createModule(.{
            .root_source_file = b.path("bench.zig"),
            .target = target,
            .optimize = optimize,
            .pic = true,
        });

        const lib = b.addLibrary(.{
            .name = "bench",
            .linkage = .dynamic,
            .root_module = mod,
        });

        const install = b.addInstallArtifact(lib, .{
            .dest_dir = .{ .override = .{ .custom = b.fmt("../../runtimes/{s}/native", .{rid.name}) } },
        });

        b.getInstallStep().dependOn(&install.step);
    }
}
