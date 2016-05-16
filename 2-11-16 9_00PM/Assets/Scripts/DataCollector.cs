using UnityEngine;
using System.Collections;

public class DataCollector : MonoBehaviour {
    [SerializeField]
    private float radPoints = 0;
    public float getRadPoints()
    {
        return this.radPoints;
    }
    public void setRadPoints(float rad)
    {
        this.radPoints = rad;
    }
    [SerializeField]

    private ArrayList itemData = new ArrayList();
    public ArrayList getItemData()
    {
        return this.itemData;
    }
    public void setItemData(ArrayList items)
    {
        this.itemData = items;
    }
    [SerializeField]  
    private ArrayList memeData = new ArrayList();
    public ArrayList getMemeData()
    {
        return this.memeData;
    }
    public void setMemeData(ArrayList memes)
    {
        this.memeData = memes;
    }
    [SerializeField]

    private float pointsPerSec = 0;

    public float getPointPerSec()
    {
        return this.pointsPerSec;
    }
    public void setPointsPerSec(float points)
    {
        this.pointsPerSec = points;
    }
    [SerializeField]
     
    private int pointsPerClick = 1;

    public int getPointsPerClick()
    {
        return this.pointsPerClick;
    }
    public void setPointsPerClick(int points)
    {
        this.pointsPerClick = points;
    }



   






	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
