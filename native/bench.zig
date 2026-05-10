// Tiny native shim used to benchmark .NET P/Invoke marshalling strategies.
//
//   bench_fill  - writes `value` into `len` bytes of `buf`. Roughly the same
//                 shape as plc_tag_get_raw_bytes (memcpy on the native side).
//   bench_noop  - returns immediately. Measures pure call/transition cost.
//
// `export fn` defaults to the C calling convention, so the resulting symbols
// are callable from .NET P/Invoke without any further adornment.

export fn bench_fill(buf: ?[*]u8, len: i32, value: u8) i32 {
    if (buf) |b| {
        if (len > 0) {
            const n: usize = @intCast(len);
            @memset(b[0..n], value);
        }
    }
    return len;
}

export fn bench_noop(buf: ?[*]u8, len: i32) i32 {
    _ = buf;
    return len;
}
