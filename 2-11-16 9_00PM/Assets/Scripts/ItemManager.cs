using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public UnityEngine.UI.Text itemInfo; //Text showing information about the item
    private DataCollector data; // references the Click class
    public double cost; // cost of the item
    public int tickValue; // the points/second value of that item
    public int count; // how many of this item you own
    public string itemName; // name of item
    private double baseCost; // base cost of item
    public PointConverter converter;
    /// <summary>
    /// runs at start of game
    /// </summary>
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataCollector>();
        baseCost = cost; // sets the baseCost to the cost we defined in Unity
        
    }

    /// <summary>
    /// Updates things
    /// </summary>
    void Update()
    {
        converter = new PointConverter(cost);
        itemInfo.text = itemName + "\nCost: " + converter + "\n" + tickValue + " RP/s\nCount: " + count; //ItemInfo shows name,cost,and points/second
    }

    /// <summary>
    /// Method used to purchase an item
    /// </summary>
    public void PurchasedItem()
    {
        if(data.getRadPoints() >= cost) //checks to see if you have enough points to buy
        {
            data.setRadPoints(data.getRadPoints() - cost); //spends you points
            count++; //gives you one of this item
            cost = Mathf.Round((float)(baseCost * Mathf.Pow(1.15f, count))); //item increases in cost by 15%
            data.setPointsPerSec(data.getPointPerSec() + tickValue);
        }
    }

    public void UpgradePowerValue(ItemManager other)
    {
        double num = 0;
        if (data.getRadPoints() >= cost) // checks to see if you have enough points to buy it
        {
            num = data.getPointPerSec() - (other.count * other.tickValue);
            data.setPointsPerSec(num);
            data.setRadPoints(data.getRadPoints() - cost); //spends your points
            this.count++;
            other.tickValue = (int)(other.tickValue * 2.5);
            this.tickValue = (int)(other.tickValue * 2.5);
            this.cost = Mathf.Round((float)(this.baseCost * Mathf.Pow(11.5f, this.count))); // cost increases by 15% each time you purchase it, rounds cost to nearest int
            data.setPointsPerSec(data.getPointPerSec() + (other.count * other.tickValue));
        }

    }

}
