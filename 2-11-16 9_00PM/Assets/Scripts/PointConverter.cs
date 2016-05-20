using UnityEngine;
using System.Collections;

public class PointConverter
{

    float num;

    public PointConverter(float pointsToConvert)
    {
        num = pointsToConvert;
    }

    public string convert()
    {
        if (num > 999999999) return (num / 1000000000f).ToString("########### beyond millions");
        if (num >= 1000000000) return (num / 100000000f).ToString("######### billion");
        if (num >= 100000000) return (num / 10000000f).ToString("######### million");
        if (num >= 10000000) return (num / 1000000f).ToString("######### million");
        if (num >= 1000000) return (num / 100000f).ToString("######### million");
        if (num >= 100000) return (num / 10000f).ToString("########## thousand");
        if (num >= 10000) return (num / 1000f).ToString("######### thousand");
        return num.ToString("#,0.0");
    }
}
