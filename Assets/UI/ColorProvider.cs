using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProvider
{


    private static string[] COLORHEXCODE_CONSTRUCTION = { "616161", "494949", "B7B7B7" };
    private static string[] COLORHEXCODE_ACCOUNTING = { "579D46", "366832", "98CD73" };
    private static string[] COLORHEXCODE_HUMANRESOURCES = { "904176", "5F284C", "D774AE" };
    private static string[] COLORHEXCODE_SALESANDMARKETING = { "99B14F", "79923B", "E6EEB8" };
    private static string[] COLORHEXCODE_RESEARCHANDDEVELOPMENT = { "5F3D7E", "482667", "A590B9" };
    private static string[] COLORHEXCODE_INFORMATIONTECHNOLOGY = { "36766D", "214E47", "70C9BE" };
    private static string[] COLORHEXCODE_LOGISTICS = { "BC8055", "7D5233", "FAB380" };
    private static string[] COLORHEXCODE_PROCUREMENT = { "BC9754", "7D6333", "FFD281" };

    public static string COLORHEXCODE_PRIMARYBEZELS = "333333";

    public enum ColorType
    {
        FACE = 0,
        SHADOW,
        FUNCTION
    }

    public enum Department
    {
        CONSTRUCTION = 0,
        ACCOUNTING,
        HUMANRESOURCES,
        SALESANDMARKETING,
        RESEARCHANDDEVELOPMENT,
        INFORMATINOTECHNOLOGY,
        LOGISTICS,
        PROCUREMENT
    }

    //getColorFromHex(Colors[Department][ColorType])
    public static string[][] Colors =
    {
        COLORHEXCODE_CONSTRUCTION,
        COLORHEXCODE_ACCOUNTING,
        COLORHEXCODE_HUMANRESOURCES,
        COLORHEXCODE_SALESANDMARKETING,
        COLORHEXCODE_RESEARCHANDDEVELOPMENT,
        COLORHEXCODE_INFORMATIONTECHNOLOGY,
        COLORHEXCODE_LOGISTICS,
        COLORHEXCODE_PROCUREMENT
    };

    public static float BEZEL_OPACITY = 0.7f;

    private static float hexToFloatNormalized(string hex)
    {
        return System.Convert.ToInt32(hex, 16) / 255f;
    }

    public static Color GetColorFromHex(string hexCode)
    {
        float red = hexToFloatNormalized(hexCode.Substring(0, 2));
        float green = hexToFloatNormalized(hexCode.Substring(2, 2));
        float blue = hexToFloatNormalized(hexCode.Substring(4, 2));

        return new Color(red, green, blue);
    }

    public static Color GetBezelColorFromHex(string hexCode)
    {
        Color color = GetColorFromHex(hexCode);
        color.a = BEZEL_OPACITY;
        return color;
    }
}
