namespace GBM;
public enum SurfaceFormat : uint
{

    BIG_ENDIAN = 1u << 31,


    INVALID = 0,


    C8 = ((int)('C') | ((int)('8') << 8) | ((int)(' ') << 16) | ((int)(' ') << 24)),


    R8 = ((int)('R') | ((int)('8') << 8) | ((int)(' ') << 16) | ((int)(' ') << 24)),


    R16 = ((int)('R') | ((int)('1') << 8) | ((int)('6') << 16) | ((int)(' ') << 24)),


    RG88 = ((int)('R') | ((int)('G') << 8) | ((int)('8') << 16) | ((int)('8') << 24)),
    GR88 = ((int)('G') | ((int)('R') << 8) | ((int)('8') << 16) | ((int)('8') << 24)),


    RG1616 = ((int)('R') | ((int)('G') << 8) | ((int)('3') << 16) | ((int)('2') << 24)),
    GR1616 = ((int)('G') | ((int)('R') << 8) | ((int)('3') << 16) | ((int)('2') << 24)),


    RGB332 = ((int)('R') | ((int)('G') << 8) | ((int)('B') << 16) | ((int)('8') << 24)),
    BGR233 = ((int)('B') | ((int)('G') << 8) | ((int)('R') << 16) | ((int)('8') << 24)),


    XRGB4444 = ((int)('X') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    XBGR4444 = ((int)('X') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    RGBX4444 = ((int)('R') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    BGRX4444 = ((int)('B') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),

    ARGB4444 = ((int)('A') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    ABGR4444 = ((int)('A') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    RGBA4444 = ((int)('R') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    BGRA4444 = ((int)('B') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),

    XRGB1555 = ((int)('X') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    XBGR1555 = ((int)('X') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    RGBX5551 = ((int)('R') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    BGRX5551 = ((int)('B') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),

    ARGB1555 = ((int)('A') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    ABGR1555 = ((int)('A') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    RGBA5551 = ((int)('R') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    BGRA5551 = ((int)('B') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),

    RGB565 = ((int)('R') | ((int)('G') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),
    BGR565 = ((int)('B') | ((int)('G') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),


    RGB888 = ((int)('R') | ((int)('G') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    BGR888 = ((int)('B') | ((int)('G') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),


    XRGB8888 = ((int)('X') | ((int)('R') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    XBGR8888 = ((int)('X') | ((int)('B') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    RGBX8888 = ((int)('R') | ((int)('X') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    BGRX8888 = ((int)('B') | ((int)('X') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),

    ARGB8888 = ((int)('A') | ((int)('R') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    ABGR8888 = ((int)('A') | ((int)('B') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    RGBA8888 = ((int)('R') | ((int)('A') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    BGRA8888 = ((int)('B') | ((int)('A') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),

    XRGB2101010 = ((int)('X') | ((int)('R') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    XBGR2101010 = ((int)('X') | ((int)('B') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    RGBX1010102 = ((int)('R') | ((int)('X') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    BGRX1010102 = ((int)('B') | ((int)('X') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),

    ARGB2101010 = ((int)('A') | ((int)('R') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    ABGR2101010 = ((int)('A') | ((int)('B') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    RGBA1010102 = ((int)('R') | ((int)('A') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    BGRA1010102 = ((int)('B') | ((int)('A') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),


    XRGB16161616F = ((int)('X') | ((int)('R') << 8) | ((int)('4') << 16) | ((int)('H') << 24)),
    XBGR16161616F = ((int)('X') | ((int)('B') << 8) | ((int)('4') << 16) | ((int)('H') << 24)),

    ARGB16161616F = ((int)('A') | ((int)('R') << 8) | ((int)('4') << 16) | ((int)('H') << 24)),
    ABGR16161616F = ((int)('A') | ((int)('B') << 8) | ((int)('4') << 16) | ((int)('H') << 24)),


    YUYV = ((int)('Y') | ((int)('U') << 8) | ((int)('Y') << 16) | ((int)('V') << 24)),
    YVYU = ((int)('Y') | ((int)('V') << 8) | ((int)('Y') << 16) | ((int)('U') << 24)),
    UYVY = ((int)('U') | ((int)('Y') << 8) | ((int)('V') << 16) | ((int)('Y') << 24)),
    VYUY = ((int)('V') | ((int)('Y') << 8) | ((int)('U') << 16) | ((int)('Y') << 24)),

    AYUV = ((int)('A') | ((int)('Y') << 8) | ((int)('U') << 16) | ((int)('V') << 24)),
    XYUV8888 = ((int)('X') | ((int)('Y') << 8) | ((int)('U') << 16) | ((int)('V') << 24)),
    VUY888 = ((int)('V') | ((int)('U') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    VUY101010 = ((int)('V') | ((int)('U') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),


    Y210 = ((int)('Y') | ((int)('2') << 8) | ((int)('1') << 16) | ((int)('0') << 24)),
    Y212 = ((int)('Y') | ((int)('2') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    Y216 = ((int)('Y') | ((int)('2') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),


    Y410 = ((int)('Y') | ((int)('4') << 8) | ((int)('1') << 16) | ((int)('0') << 24)),
    Y412 = ((int)('Y') | ((int)('4') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    Y416 = ((int)('Y') | ((int)('4') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),

    XVYU2101010 = ((int)('X') | ((int)('V') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    XVYU12_16161616 = ((int)('X') | ((int)('V') << 8) | ((int)('3') << 16) | ((int)('6') << 24)),
    XVYU16161616 = ((int)('X') | ((int)('V') << 8) | ((int)('4') << 16) | ((int)('8') << 24)),



    Y0L0 = ((int)('Y') | ((int)('0') << 8) | ((int)('L') << 16) | ((int)('0') << 24)),

    X0L0 = ((int)('X') | ((int)('0') << 8) | ((int)('L') << 16) | ((int)('0') << 24)),


    Y0L2 = ((int)('Y') | ((int)('0') << 8) | ((int)('L') << 16) | ((int)('2') << 24)),

    X0L2 = ((int)('X') | ((int)('0') << 8) | ((int)('L') << 16) | ((int)('2') << 24)),


    YUV420_8BIT = ((int)('Y') | ((int)('U') << 8) | ((int)('0') << 16) | ((int)('8') << 24)),
    YUV420_10BIT = ((int)('Y') | ((int)('U') << 8) | ((int)('1') << 16) | ((int)('0') << 24)),


    XRGB8888_A8 = ((int)('X') | ((int)('R') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),
    XBGR8888_A8 = ((int)('X') | ((int)('B') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),
    RGBX8888_A8 = ((int)('R') | ((int)('X') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),
    BGRX8888_A8 = ((int)('B') | ((int)('X') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),
    RGB888_A8 = ((int)('R') | ((int)('8') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),
    BGR888_A8 = ((int)('B') | ((int)('8') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),
    RGB565_A8 = ((int)('R') | ((int)('5') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),
    BGR565_A8 = ((int)('B') | ((int)('5') << 8) | ((int)('A') << 16) | ((int)('8') << 24)),


    NV12 = ((int)('N') | ((int)('V') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    NV21 = ((int)('N') | ((int)('V') << 8) | ((int)('2') << 16) | ((int)('1') << 24)),
    NV16 = ((int)('N') | ((int)('V') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),
    NV61 = ((int)('N') | ((int)('V') << 8) | ((int)('6') << 16) | ((int)('1') << 24)),
    NV24 = ((int)('N') | ((int)('V') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    NV42 = ((int)('N') | ((int)('V') << 8) | ((int)('4') << 16) | ((int)('2') << 24)),
}

    // public enum SurfaceFormat : uint
    // {
    //     BigEndian = 1u << 31,

    //     C8 = ((int)('C') | ((int)('8') << 8) | ((int)(' ') << 16) | ((int)(' ') << 24)),
    //     RGB332 = ((int)('R') | ((int)('G') << 8) | ((int)('B') << 16) | ((int)('8') << 24)),
    //     BGR233 = ((int)('B') | ((int)('G') << 8) | ((int)('R') << 16) | ((int)('8') << 24)),

    //     XRGB4444 = ((int)('X') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     XBGR4444 = ((int)('X') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     RGBX4444 = ((int)('R') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     BGRX4444 = ((int)('B') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),

    //     ARGB4444 = ((int)('A') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     ABGR4444 = ((int)('A') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     RGBA4444 = ((int)('R') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     BGRA4444 = ((int)('B') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),

    //     XRGB1555 = ((int)('X') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    //     XBGR1555 = ((int)('X') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    //     RGBX5551 = ((int)('R') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    //     BGRX5551 = ((int)('B') | ((int)('X') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),

    //     ARGB1555 = ((int)('A') | ((int)('R') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    //     ABGR1555 = ((int)('A') | ((int)('B') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    //     RGBA5551 = ((int)('R') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),
    //     BGRA5551 = ((int)('B') | ((int)('A') << 8) | ((int)('1') << 16) | ((int)('5') << 24)),

    //     RGB565 = ((int)('R') | ((int)('G') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),
    //     BGR565 = ((int)('B') | ((int)('G') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),

    //     RGB888 = ((int)('R') | ((int)('G') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     BGR888 = ((int)('B') | ((int)('G') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),

    //     XRGB8888 = ((int)('X') | ((int)('R') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     XBGR8888 = ((int)('X') | ((int)('B') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     RGBX8888 = ((int)('R') | ((int)('X') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     BGRX8888 = ((int)('B') | ((int)('X') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),

    //     ARGB8888 = ((int)('A') | ((int)('R') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     ABGR8888 = ((int)('A') | ((int)('B') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     RGBA8888 = ((int)('R') | ((int)('A') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     BGRA8888 = ((int)('B') | ((int)('A') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),

    //     XRGB2101010 = ((int)('X') | ((int)('R') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    //     XBGR2101010 = ((int)('X') | ((int)('B') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    //     RGBX1010102 = ((int)('R') | ((int)('X') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    //     BGRX1010102 = ((int)('B') | ((int)('X') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),

    //     ARGB2101010 = ((int)('A') | ((int)('R') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    //     ABGR2101010 = ((int)('A') | ((int)('B') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    //     RGBA1010102 = ((int)('R') | ((int)('A') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),
    //     BGRA1010102 = ((int)('B') | ((int)('A') << 8) | ((int)('3') << 16) | ((int)('0') << 24)),

    //     YUYV = ((int)('Y') | ((int)('U') << 8) | ((int)('Y') << 16) | ((int)('V') << 24)),
    //     YVYU = ((int)('Y') | ((int)('V') << 8) | ((int)('Y') << 16) | ((int)('U') << 24)),
    //     UYVY = ((int)('U') | ((int)('Y') << 8) | ((int)('V') << 16) | ((int)('Y') << 24)),
    //     VYUY = ((int)('V') | ((int)('Y') << 8) | ((int)('U') << 16) | ((int)('Y') << 24)),

    //     AYUV = ((int)('A') | ((int)('Y') << 8) | ((int)('U') << 16) | ((int)('V') << 24)),

    //     NV12 = ((int)('N') | ((int)('V') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     NV21 = ((int)('N') | ((int)('V') << 8) | ((int)('2') << 16) | ((int)('1') << 24)),
    //     NV16 = ((int)('N') | ((int)('V') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),
    //     NV61 = ((int)('N') | ((int)('V') << 8) | ((int)('6') << 16) | ((int)('1') << 24)),

    //     YUV410 = ((int)('Y') | ((int)('U') << 8) | ((int)('V') << 16) | ((int)('9') << 24)),
    //     YVU410 = ((int)('Y') | ((int)('V') << 8) | ((int)('U') << 16) | ((int)('9') << 24)),
    //     YUV411 = ((int)('Y') | ((int)('U') << 8) | ((int)('1') << 16) | ((int)('1') << 24)),
    //     YVU411 = ((int)('Y') | ((int)('V') << 8) | ((int)('1') << 16) | ((int)('1') << 24)),
    //     YUV420 = ((int)('Y') | ((int)('U') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     YVU420 = ((int)('Y') | ((int)('V') << 8) | ((int)('1') << 16) | ((int)('2') << 24)),
    //     YUV422 = ((int)('Y') | ((int)('U') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),
    //     YVU422 = ((int)('Y') | ((int)('V') << 8) | ((int)('1') << 16) | ((int)('6') << 24)),
    //     YUV444 = ((int)('Y') | ((int)('U') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    //     YVU444 = ((int)('Y') | ((int)('V') << 8) | ((int)('2') << 16) | ((int)('4') << 24)),
    // }
