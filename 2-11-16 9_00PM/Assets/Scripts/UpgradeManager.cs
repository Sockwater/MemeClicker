using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    private DataCollector data;
    public Text itemInfo; //A bit of text showing information about the item (name,cost,power)
    public double cost; // how many points an item costs
    public int count = 0; // how many of this item you have
    public int clickPower; // how many points/click this item adds
    public string itemName; //name of the item
    private double baseCost; //base cost of the item
    public PointConverter converter;
    public bool changeColor;
    
    /// <summary>
    /// runs at the beginning of the game
    /// </summary>
    void Start()
    {
        baseCost = cost;//sets the base cost to whatever we assigned it to in unity
        data = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataCollector>();
        if (changeColor)
        {
            itemInfo.color = RandomColor();
        }
    }

    /// <summary>
    /// Updates things
    /// </summary>
    void Update()
    {
        converter = new PointConverter(cost);
        itemInfo.text = itemName + "\nCost: " + converter + "\nPower: " + clickPower + "\nCount: " + count; // updates the text on the button to show current name, cost, power
    }
    public void ClickPower(int num,int power)
    {

        data.setPointsPerClick(data.getPointsPerClick() + (num * power));
    }
    
    /// <summary>
    /// Method for purchasing an upgrade
    /// </summary>
    public void PurchasedUpgrade(Click MainClick)
    {
        if (data.getRadPoints() >= cost) // checks to see if you have enough points to buy it
        {
            data.setRadPoints(data.getRadPoints() - cost); //spends your points
            count++; //gives you 1 of this item 
            data.setPointsPerClick(data.getPointsPerClick() + clickPower);  // adds the power to the total points/click
            cost = Mathf.Round((float)(baseCost * Mathf.Pow(1.15f, count))); // cost increases by 15% each time you purchase it, rounds cost to nearest int
        }
    }
    /// <summary>
    /// Method for purchasing an upgrade to the click values
    /// </summary>
    public void UpgradePowerValue(UpgradeManager other)
    {
        int num = 0;
        if (data.getRadPoints() >= cost) // checks to see if you have enough points to buy it
        {
            num = data.getPointsPerClick() - (other.count * other.clickPower);
            data.setPointsPerClick(num);
            data.setRadPoints(data.getRadPoints() - cost); //spends your points
            this.count++;
            other.clickPower = clickPower;
            this.clickPower = (int)(clickPower * 1.5);
            this.cost = Mathf.Round((float)(this.baseCost * Mathf.Pow(11.5f, this.count))); // cost increases by 15% each time you purchase it, rounds cost to nearest int
            ClickPower(other.count,other.clickPower);
        }

    }
    private Color RandomColor()
    {
        return Random.ColorHSV();
    }
}
