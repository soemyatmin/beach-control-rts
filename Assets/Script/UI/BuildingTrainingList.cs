using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTrainingList : MonoBehaviour
{
    private List<BtnShopBuilding> btnShopBuildingList = new List<BtnShopBuilding>();
    [SerializeField] private GameObject listContent;
    public void AddToBuildingListContent(ShopBuildingButtonData shopBuildingButtonData, GameObject PrefabGameObjectShopPrefab)
    {
        BtnShopBuilding ShopButton = Instantiate(PrefabGameObjectShopPrefab,listContent.transform).GetComponent<BtnShopBuilding>();
        btnShopBuildingList.Add(ShopButton);
        
        ShopButton.Init(shopBuildingButtonData);
    }
    
    public void ResetBuildComplete(int buildingID)
    {
        // TODO: according to building relatation some building are back to allow and some are not, more reference on Doc.
        foreach (BtnShopBuilding ele in btnShopBuildingList)
        {
            ele.Reset();
        }
    }
    
    public void ProhibitedBuild(int shopBuildingID)
    {
        // TODO: according to building relatation some building are prohibited and some are not, more reference on Doc.
        foreach (BtnShopBuilding ele in btnShopBuildingList)
        {
            if(shopBuildingID != ele.GetShopBuildingID()){
                ele.ProhibitedBuild();
            }
        }
    }
}
