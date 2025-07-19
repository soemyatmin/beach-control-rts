using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonData
{
    public int ID;
    public string ShopBuildingName;
    public enum ShopCategory
    {
        Building,
        Defense,
        Soldier,
        Tank
    }
    public string ShopBuildingDescription;
    public ShopCategory Category;
    public int ShopBuildingDependentID;
    public float ShopBuildingPrice;
    public float ShopBuildingBuildDuration;
    public int ShopBuildingLimit;
    
    public Sprite Image;

    public ShopButtonData(int id, string shopBuildingName, ShopCategory category, string shopBuildingDescription,
        int shopBuildingDependentID, float shopBuildingPrice, float shopBuildingBuildDuration, int shopBuildingLimit,
        Sprite image)
    {
        ID = id;
        ShopBuildingName = shopBuildingName;
        Category = category;
        ShopBuildingDescription = shopBuildingDescription;
        ShopBuildingDependentID = shopBuildingDependentID;
        ShopBuildingPrice = shopBuildingPrice;
        ShopBuildingBuildDuration = shopBuildingBuildDuration;
        ShopBuildingLimit = shopBuildingLimit;
        Image = image;
    }
}
