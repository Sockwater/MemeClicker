using UnityEngine;
using System.Collections;

public class PointConverter
{

<<<<<<< HEAD
    float num;
=======
    private string conversion;
    private int commaCount;
>>>>>>> origin/master

    public PointConverter(double pointsToConvert,int maxBeforeWords = 2)
    {
<<<<<<< HEAD
        num = pointsToConvert;
=======
        conversion = pointsToConvert.ToString("N1");
        commaCount = commas();
        if (commaCount >= maxBeforeWords) this.toWord();
    }

    public int commas()
    {
        int num = 0;
        foreach (char val in conversion)
        {
            if (val == ',') num++;
        }
        return num;
    }
    public string toWord()
    {
        int firstComma = conversion.IndexOf(",");
        string word = "";
        string end = conversion.Substring(firstComma);
        foreach (char e in end)
        {
            if (e != ',') word += e;
        }
        end = word;
        if (end.Length >= 66) word = " Memeillion";
        else if (end.Length >= 63) word = " Vigintillion";
        else if (end.Length >= 60) word = " Novendecillion";
        else if (end.Length >= 57) word = " Octodecillion";
        else if (end.Length >= 54) word = " Septendecillion";
        else if (end.Length >= 51) word = " Sedecillion";
        else if (end.Length >= 48) word = " Quindecillion";
        else if (end.Length >= 45) word = " Quattuordecillion";
        else if (end.Length >= 42) word = " Tredecillion";
        else if (end.Length >= 39) word = " Duodeillion";
        else if (end.Length >= 36) word = " Undecillion";
        else if (end.Length >= 33) word = " Decillion";
        else if (end.Length >= 30) word = " Nonillion";
        else if (end.Length >= 27) word = " Octillion";
        else if (end.Length >= 24) word = " Septillion";
        else if (end.Length >= 21) word = " Sextillion";
        else if (end.Length >= 18) word = " Quintillion";
        else if (end.Length >= 15) word = " Quadrillion";
        else if (end.Length >= 12) word = " Trillion";
        else if (end.Length >= 9) word = " Billion";
        else if (end.Length >= 6) word = " Million";
        conversion = conversion.Substring(0, firstComma) + "." + end.Substring(0,3) + word;
        return conversion;
>>>>>>> origin/master
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
