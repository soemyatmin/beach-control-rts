using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : SingletonMonoBehaviour<MasterData>
{
    
    string ShopBuildingButtonDataPrefix = "UI/Buttons/Buildings/";
    private List<ShopBuildingButtonData> shopBuildingButtonDataList = new List<ShopBuildingButtonData>();
    
    public void Init()
    {
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(1, "ShopBuildingName1", "", 0, 1000, 10,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button_towncenter_background")));
        shopBuildingButtonDataList.Add(new ShopBuildingButtonData(2, "ShopBuildingName2", "", 0, 1000, 10,
            ImageLoader.Instance.LoadImageByName(ShopBuildingButtonDataPrefix + "button_towncenter_background")));
    }

    public List<ShopBuildingButtonData> GetMasterShopBuildingButtonData()
    {
        return shopBuildingButtonDataList;
    }
}
