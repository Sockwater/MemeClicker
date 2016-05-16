using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

    private DataCollector data;
    public UnityEngine.UI.Text radPerClick; // Text showing points per click
    public UnityEngine.UI.Text radPointDisplay; // Text showing how many points you have
    public float radPoints; // the amount of points you have
    public int radPointsPerClick = 1; // the amount of points you get per click
    
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataCollector>();
        radPoints = data.getRadPoints();
        Debug.Log(radPoints);
        data.setPointsPerClick(radPointsPerClick);
        //radPointDisplay.text = "Rad Points: " + radPoints.ToString("F1"); // makes the radPointDisplay show the new amount of points
        //radPerClick.text = radPointsPerClick + "RP/click"; //makes the radPerClick show the new amount of points per click
    }
    /// <summary>
    /// things that do every frame
    /// </summary>
    void Update()
    {
        radPoints = data.getRadPoints();
        radPointsPerClick = data.getPointsPerClick();
        radPointDisplay.text = "Rad Points: " + radPoints.ToString("F1"); // makes the radPointDisplay show the new amount of points
        radPerClick.text = radPointsPerClick + "RP/click"; //makes the radPerClick show the new amount of points per click


    }
    /// <summary>
    /// runs whenever the button is clicked
    /// </summary>
    public void Clicked()
    {
        radPoints += radPointsPerClick; //adds the amounbt of points/click to your total points
        data.setPointsPerClick(radPointsPerClick);
        data.setRadPoints(radPoints);
    }
}
