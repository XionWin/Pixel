namespace Graphic.Drawing.Color;
public static class Extension
{
    public static HSLA ToHSL(this RGBA rgb)
    {
        var hsl = new HSLA();
        // Convert RGB to a 0.0 to 1.0 range.
        float r = rgb.R / 255f;
        float g = rgb.G / 255f;
        float b = rgb.B / 255f;

        // Get the maximum and minimum RGB components.
        float max = r;
        if (max < g) max = g;
        if (max < b) max = b;

        float min = r;
        if (min > g) min = g;
        if (min > b) min = b;

        float diff = max - min;
        hsl.L = (max + min) / 2;
        if (Math.Abs(diff) < 0.00001)
        {
            hsl.S = 0;
            hsl.H = 0;  // H is really undefined.
        }
        else
        {
            if (hsl.L <= 0.5) hsl.S = diff / (max + min);
            else hsl.S = diff / (2 - max - min);

            float rd = (max - r) / diff;
            float gd = (max - g) / diff;
            float bd = (max - b) / diff;

            if (r == max) hsl.H = bd - gd;
            else if (g == max) hsl.H = 2 + rd - bd;
            else hsl.H = 4 + gd - rd;

            hsl.H *= 60;
            if (hsl.H < 0) hsl.H += 360;
        }
        return hsl;
    }

    // Convert an HSL value into an RGB value.
    public static RGBA ToRGB(this HSLA hsl)
    {
        float p2;
        if (hsl.L <= 0.5) p2 = hsl.L * (1 + hsl.S);
        else p2 = hsl.L + hsl.S - hsl.L * hsl.S;

        float p1 = 2 * hsl.L - p2;
        float r, g, b;
        if (hsl.S == 0)
        {
            r = hsl.L;
            g = hsl.L;
            b = hsl.L;
        }
        else
        {
            r = QqhToRgb(p1, p2, hsl.H + 120);
            g = QqhToRgb(p1, p2, hsl.H);
            b = QqhToRgb(p1, p2, hsl.H - 120);
        }

        return new RGBA(r, g, b);
    }

    private static float QqhToRgb(float q1, float q2, float hue)
    {
        if (hue > 360) hue -= 360;
        else if (hue < 0) hue += 360;

        if (hue < 60) return q1 + (q2 - q1) * hue / 60;
        if (hue < 180) return q2;
        if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
        return q1;
    }
}
