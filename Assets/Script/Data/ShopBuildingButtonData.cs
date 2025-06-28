using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBuildingButtonData
{
    public int ID;
    public string ShopBuildingName;
    public string ShopBuildingDescription;
    
    public int ShopBuildingDependentID;
    public float ShopBuildingPrice;
    public float ShopBuildingBuildDuration;
    public int ShopBuildingLimit;
    
    public Sprite Image;

    public ShopBuildingButtonData(int id, string shopBuildingName, string shopBuildingDescription,
        int shopBuildingDependentID, float shopBuildingPrice, float shopBuildingBuildDuration, int shopBuildingLimit,
        Sprite image)
    {
        ID = id;
        ShopBuildingName = shopBuildingName;
        ShopBuildingDescription = shopBuildingDescription;
        ShopBuildingDependentID = shopBuildingDependentID;
        ShopBuildingPrice = shopBuildingPrice;
        ShopBuildingBuildDuration = shopBuildingBuildDuration;
        ShopBuildingLimit = shopBuildingLimit;
        Image = image;
    }
}
