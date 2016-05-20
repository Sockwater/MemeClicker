﻿using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

    private DataCollector data;
    public UnityEngine.UI.Text radPerClick; // Text showing points per click
    public UnityEngine.UI.Text radPointDisplay; // Text showing how many points you have
    public double radPoints; // the amount of points you have
    public int radPointsPerClick = 1; // the amount of points you get per click
    public PointConverter converter;

    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataCollector>();
        radPoints = data.getRadPoints();
        data.setPointsPerClick(radPointsPerClick);

    }
    /// <summary>
    /// things that do every frame
    /// </summary>
    void Update()
    {
        radPoints = data.getRadPoints();
        converter = new PointConverter(radPoints);
        radPointDisplay.text = "Rad Points: " + converter.convert(); // makes the radPointDisplay show the new amount of points
        radPointsPerClick = data.getPointsPerClick();
        converter = new PointConverter(radPointsPerClick);
        radPerClick.text = converter.convert().Substring(0,converter.convert().Length-2) + " RP/click"; //makes the radPerClick show the new amount of points per click
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
