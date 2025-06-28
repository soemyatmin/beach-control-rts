using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : SingletonMonoBehaviour<MasterData>
{
    string ShopBuildingButtonDataPrefix = "UI/Buttons/Buildings/";
    
    string BuildingPrefabDataPrefix = "UI/P/Buildings/";
    
    private List<ShopBuildingButtonData> shopBuildingButtonDataList = new List<ShopBuildingButtonData>();
    private List<BuildingData> buildingButtonDataList = new List<BuildingData>();

    public void Init()
    {
        //Shop Building Data
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(1, "Town Center", "", 0, 3000, 10, 5,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-towncenter")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(2, "House", "", 0, 500, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-house")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(3, "Community Center", "", 0, 1000, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-community-center")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(4, "Energy Station", "", 0, 700, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-energy-station")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(5, "Gold Miner", "", 0, 2000, 10, 5,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-gold-miner")));
        
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(6, "Oil Rig", "", 0, 500, 10, 4,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-oil-rig")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(7, "University", "", 0, 2000, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-university")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(8, "Tank Factory", "", 0, 2000, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-tank-factory")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(9, "Barrack", "", 0, 1000, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-barrack")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(10, "Radio Tower", "", 0, 1500, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-radio-tower")));

        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(11, "Tech Lab", "", 0, 6000, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-tech-lab")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(12, "Laser Gun Factory", "", 0, 4000, 10, 20,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-laser-gun-factory")));
        
        //Building Data
        // buildingButtonDataList.Add(new BuildingData(1, "Electronic Gun Building", "", 4000, 10, 20,
        //     ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button-shop-building-null")));
    }

    public List<ShopBuildingButtonData> GetMasterShopBuildingButtonData()
    {
        return shopBuildingButtonDataList;
    }
}