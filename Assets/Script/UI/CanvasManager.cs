using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CanvasManager : SingletonMonoBehaviour<CanvasManager>
{
    [SerializeField] private ShopTrainingList shopTrainingList;
    
    [SerializeField] private ShopTabs shopTabs;

    public ShopTrainingList BuildingTrainingList()
    {
        return shopTrainingList;
    }
    
    public ShopTabs BuildingTab()
    {
        return shopTabs;
    }

    public void ViewShopTab(ShopButtonData.ShopCategory shopCategory)
    {
        shopTrainingList.ViewShopTab(shopCategory);
    }
}