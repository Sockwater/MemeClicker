using UnityEngine;
using System.Collections;

public class PointsPerSec : MonoBehaviour {

    public UnityEngine.UI.Text pointsPerSecDisplay; // text displaying the amount of points/ second
    //public Click click; // references the Click class
    public ItemManager[] items; // array of items
    private DataCollector data;
    public PointConverter converter;

    /// <summary>
    /// runs at start of game
    /// </summary>
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataCollector>();

        StartCoroutine(AutoTick()); //starts the AutoTick method
       

    }

    /// <summary>
    /// Updates things
    /// </summary>
    void Update()
    {
        converter = new PointConverter(data.getPointPerSec());
        pointsPerSecDisplay.text = converter.ToString().Substring(0, converter.ToString().Length - 2) + " RP/sec"; // updates the pointsPerSecDisplay to the current RP/second
        //data.setPointsPerSec((int)GetPointsPerSec());
    }

    /// <summary>
    /// Gets the amount of points/second
    /// </summary>
    /// <returns> tick </returns>
    public double GetPointsPerSec()
    {
        double tick = 0;//data.getPointPerSec(); //points/second
        foreach (ItemManager item in items)
        {
            if (item.count > 0) tick += item.count * item.tickValue; //adds the points/second value for each item you own.
        }
        data.setPointsPerSec((int)tick);
        Debug.Log(data.getPointPerSec());
        return data.getPointPerSec();
    }

    /// <summary>
    /// Adds the points/second to the total points each second
    /// </summary>
    public void AutoPointsPerSec()
    {
        // click.radPoints += GetPointsPerSec() / 10;
            data.setRadPoints(data.getRadPoints() + (data.getPointPerSec()/17.6));
    }

    /// <summary>
    /// runs AutoPointsPerSec once every second
    /// </summary>
    /// <returns> </returns>
    IEnumerator AutoTick()
    {
        while(true) // true is always true
        {
            
                AutoPointsPerSec(); // runs AutoPointsPerSec
                yield return new WaitForSeconds(0.10f); // does again after 1 second
            
        }
    }


}
