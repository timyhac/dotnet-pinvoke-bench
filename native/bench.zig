// Native shim for benchmarking .NET P/Invoke marshalling strategies.
// `export fn` defaults to the C calling convention.
//
// `bench_wstrlen` / `bench_get_utf16_string` use u16 (not wchar_t) so the
// signature matches .NET's UTF-16 strings on every platform; wchar_t is
// 4 bytes on Linux/macOS and would be wrong here.

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

export fn bench_wstrlen(s: ?[*:0]const u16) i32 {
    if (s) |str| {
        var i: usize = 0;
        while (str[i] != 0) : (i += 1) {}
        return @intCast(i);
    }
    return 0;
}

export fn bench_wstrlen_noop(s: ?[*:0]const u16) i32 {
    _ = s;
    return 0;
}

pub const Point = extern struct {
    x: i32,
    y: i32,
};

pub const Rect = extern struct {
    left: i32,
    top: i32,
    right: i32,
    bottom: i32,
};

export fn bench_struct_byval(p: Point) i32 {
    return p.x + p.y;
}

export fn bench_struct_byref(p: ?*const Point) i32 {
    if (p) |ptr| return ptr.x + ptr.y;
    return 0;
}

export fn bench_struct_byval_large(r: Rect) i32 {
    return (r.right - r.left) + (r.bottom - r.top);
}

export fn bench_struct_byref_large(r: ?*const Rect) i32 {
    if (r) |ptr| return (ptr.right - ptr.left) + (ptr.bottom - ptr.top);
    return 0;
}

export fn bench_struct_array_sum(arr: ?[*]const Point, len: i32) i32 {
    if (arr) |a| {
        if (len > 0) {
            const n: usize = @intCast(len);
            var sum: i32 = 0;
            var i: usize = 0;
            while (i < n) : (i += 1) sum += a[i].x + a[i].y;
            return sum;
        }
    }
    return 0;
}

const CallbackFn = *const fn (arg: i32) callconv(.c) i32;

export fn bench_invoke_callback(cb: ?CallbackFn, arg: i32) i32 {
    if (cb) |f| return f(arg);
    return 0;
}

const CallbackUserdataFn = *const fn (ctx: ?*anyopaque, arg: i32) callconv(.c) i32;

export fn bench_invoke_callback_userdata(cb: ?CallbackUserdataFn, ctx: ?*anyopaque, arg: i32) i32 {
    if (cb) |f| return f(ctx, arg);
    return 0;
}

export fn bench_bool_u8(b: u8) u8 {
    return if (b != 0) 1 else 0;
}

export fn bench_bool_i32(b: i32) i32 {
    return if (b != 0) 1 else 0;
}

export fn bench_scalar_i32(v: i32) i32 {
    return v;
}

export fn bench_scalar_i64(v: i64) i64 {
    return v;
}

export fn bench_scalar_f32(v: f32) f32 {
    return v;
}

export fn bench_scalar_f64(v: f64) f64 {
    return v;
}

export fn bench_out_int(p: ?*i32) i32 {
    if (p) |ptr| ptr.* = 42;
    return 0;
}

export fn bench_inout_int(p: ?*i32) i32 {
    if (p) |ptr| {
        ptr.* += 1;
        return ptr.*;
    }
    return 0;
}

// Library-owned static strings — caller must not free.
const utf8_msg: [*:0]const u8 = "hello, native interop world";
const utf16_msg: [*:0]const u16 = &[_:0]u16{
    'h', 'e', 'l', 'l', 'o', ',', ' ', 'n', 'a', 't', 'i', 'v', 'e', ' ',
    'i', 'n', 't', 'e', 'r', 'o', 'p', ' ', 'w', 'o', 'r', 'l', 'd',
};

export fn bench_get_utf8_string() ?[*:0]const u8 {
    return utf8_msg;
}

export fn bench_get_utf16_string() ?[*:0]const u16 {
    return utf16_msg;
}

export fn bench_handle_passthrough(h: ?*anyopaque) ?*anyopaque {
    return h;
}
