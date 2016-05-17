using UnityEngine;
using System.Collections;

public class UpgradeManager : MonoBehaviour {

    private DataCollector data;
    public UnityEngine.UI.Text itemInfo; //A bit of text showing information about the item (name,cost,power)
    public float cost; // how many points an item costs
    public int count = 0; // how many of this item you have
    public int clickPower; // how many points/click this item adds
    public string itemName; //name of the item
    private float baseCost; //base cost of the item

    /// <summary>
    /// runs at the beginning of the game
    /// </summary>
    void Start()
    {
        baseCost = cost;//sets the base cost to whatever we assigned it to in unity
        data = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DataCollector>();

    }

    /// <summary>
    /// Updates things
    /// </summary>
    void Update()
    {
        itemInfo.text = itemName + "\nCost: " + cost + "\nPower: " + clickPower + "\nCount: " + count; // updates the text on the button to show current name, cost, power
    }
    public void ClickPower(int num,int power)
    {

        data.setPointsPerClick(data.getPointsPerClick() + (num * power));
    }
    
    /// <summary>
    /// Method for purchasing an upgrade
    /// </summary>
    public void PurchasedUpgrade()
    {
        if(data.getRadPoints() >= cost) // checks to see if you have enough points to buy it
        {
            data.setRadPoints(data.getRadPoints() - cost); //spends your points
            count++; //gives you 1 of this item 
            data.setPointsPerClick(data.getPointsPerClick() + clickPower);  // adds the power to the total points/click
            cost = Mathf.Round(baseCost * Mathf.Pow(1.15f, count)); // cost increases by 15% each time you purchase it, rounds cost to nearest int
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
            this.cost = Mathf.Round(this.baseCost * Mathf.Pow(11.5f, this.count)); // cost increases by 15% each time you purchase it, rounds cost to nearest int
            ClickPower(other.count,other.clickPower);
        }

    }
}
