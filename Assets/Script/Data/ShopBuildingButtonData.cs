using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuildingButtonData
{
    public int ID;
    public string ShopBuildingName;
    public string ShopBuildingDescription;
    
    public int ShopBuildingDependentID;
    public float ShopBuildingBuildDuration;
    public float ShopBuildingPrice;
    public Sprite Image;

    public ShopBuildingButtonData(int id, string shopBuildingName, string shopBuildingDescription, int shopBuildingDependentID, float shopBuildingBuildDuration, float shopBuildingPrice, Sprite image)
    {
        ID = id;
        ShopBuildingName = shopBuildingName;
        ShopBuildingDescription = shopBuildingDescription;
        ShopBuildingDependentID = shopBuildingDependentID;
        ShopBuildingBuildDuration = shopBuildingBuildDuration;
        ShopBuildingPrice = shopBuildingPrice;
        Image = image;
    }
}
