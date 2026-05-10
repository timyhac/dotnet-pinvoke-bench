// Tiny native shim used to benchmark .NET P/Invoke marshalling strategies.
//
//   bench_fill   - writes `value` into `len` bytes of `buf`. Roughly the same
//                  shape as plc_tag_get_raw_bytes (memcpy on the native side).
//   bench_noop   - returns immediately. Measures pure call/transition cost.
//   bench_strlen - walks a null-terminated UTF-8 string and returns its length.
//                  Used to compare string-marshalling strategies; the work is
//                  O(n) but trivial, so .NET-side encoding/marshalling cost
//                  is the dominant signal.
//   bench_strlen_noop - returns 0 immediately. Pairs with bench_strlen so the
//                  caller can subtract "native walk" cost and see the pure
//                  encoding+transition contribution of each strategy.
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

export fn bench_strlen(s: ?[*:0]const u8) i32 {
    if (s) |str| {
        var i: usize = 0;
        while (str[i] != 0) : (i += 1) {}
        return @intCast(i);
    }
    return 0;
}

export fn bench_strlen_noop(s: ?[*:0]const u8) i32 {
    _ = s;
    return 0;
}
