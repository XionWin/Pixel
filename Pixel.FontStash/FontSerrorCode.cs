namespace Pixel.FontStash;
public enum FontSerrorCode
{		// Font atlas is full.
    ATLAS_FULL = 1,
    // Scratch memory used to render glyphs is full, requested size reported in 'val', you may need to bump up SCRATCH_BUF_SIZE.
    SCRATCH_FULL = 2,
    // Calls to fonsPushState has craeted too large stack, if you need deep state stack bump up MAX_STATES.
    STATES_OVERFLOW = 3,
    // Trying to pop too many states fonsPopState().
    STATES_UNDERFLOW = 4,
}