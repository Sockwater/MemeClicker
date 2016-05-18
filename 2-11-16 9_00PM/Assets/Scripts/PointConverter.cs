using UnityEngine;
using System.Collections;

public class PointConverter
{

    private string conversion;

    public PointConverter(float pointsToConvert)
    {
        if (pointsToConvert >= 10000) conversion = (pointsToConvert / 1000f).ToString("0.0## thousand");
        else if (pointsToConvert >= 100000) conversion = (pointsToConvert / 10000f).ToString("0.0# thousand");
        else if (pointsToConvert >= 1000000) conversion = (pointsToConvert / 100000f).ToString("0.0## million");
        else if (pointsToConvert >= 10000000) conversion = (pointsToConvert / 1000000f).ToString("0.0# million");
        else if (pointsToConvert >= 100000000) conversion = (pointsToConvert / 10000000f).ToString("0.0## billion");
        else if (pointsToConvert >= 1000000000) conversion = (pointsToConvert / 100000000f).ToString("0.0# billion");
        else conversion = pointsToConvert.ToString("#,0.0");
    }

    public override string ToString()
    {
        return conversion;
    }
}
