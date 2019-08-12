using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPool
{
    public static string HEX_PRIMARYBEZELS = "333333";
    public static string HEX_CONS = "666766";
    public static string HEX_CONS_DARK = "333333";
    public static string HEX_HR = "904176";
    public static string HEX_HR_DARK = "5F284C";
    public static string HEX_ACC = "579D46";
    public static string HEX_ACC_DARK = "366832";
    public static string HEX_RD = "BC8055";
    public static string HEX_RD_DARK = "7D5233";
    public static string HEX_CAL = "B6535D";
    public static string HEX_CAL_DARK = "793139";
    public static string HEX_IT = "36766D";
    public static string HEX_IT_DARK = "214E47";
    public static string HEX_PROC = "BC9754";
    public static string HEX_PROC_DARK = "7D6333";
    public static string HEX_LOG = "999999";
    public static string HEX_LOG_DARK = "666766";

    public static float BEZEL_OPACITY = 0.7f;

    private static float HexToFloatNormalized(string hex)
    {
        return System.Convert.ToInt32(hex, 16) / 255f;
    }

    public static Color getColorFromHex(string hexCode)
    {
        float red = HexToFloatNormalized(hexCode.Substring(0, 2));
        float green = HexToFloatNormalized(hexCode.Substring(2, 2));
        float blue = HexToFloatNormalized(hexCode.Substring(4, 2));

        return new Color(red, green, blue);
    }

    public static Color getBezelColorFromHex(string hexCode)
    {
        Color color = getColorFromHex(hexCode);
        color.a = BEZEL_OPACITY;
        return color;
    }
}
