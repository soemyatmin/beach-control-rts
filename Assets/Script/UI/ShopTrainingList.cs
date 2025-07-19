using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrainingList : MonoBehaviour
{
    private List<BtnShop> btnShopList = new List<BtnShop>();
    [SerializeField] private Transform listContent;
    
    [SerializeField] private Transform unviewList;

    public void AddToBuildingListContent(ShopButtonData shopButtonData, GameObject PrefabGameObjectShopPrefab)
    {
        BtnShop ShopButton = Instantiate(PrefabGameObjectShopPrefab,listContent).GetComponent<BtnShop>();
        btnShopList.Add(ShopButton);
        
        ShopButton.Init(shopButtonData);
    }

    public void ViewShopTab(ShopButtonData.ShopCategory shopCategory)
    {
        foreach (BtnShop ele in btnShopList)
        {
            if (ele.GetShopBuilding().Category == shopCategory)
            {
                ele.transform.SetParent(listContent, false);
            }
            else
            {
                ele.transform.SetParent(unviewList, false);
            }
        }
    }
    

    public void ResetBuildComplete(ShopButtonData shopBuildingID)
    {
        // TODO: according to building relatation some building are back to allow and some are not, more reference on Doc.
        foreach (BtnShop ele in btnShopList)
        {
            if (shopBuildingID.Category == ele.GetShopBuilding().Category)
            {
                ele.Reset();
            }
        }
    }
    
    public void ProhibitedBuild(ShopButtonData shopBuildingID)
    {
        // TODO: according to building relatation some building are prohibited and some are not, more reference on Doc.
        foreach (BtnShop ele in btnShopList)
        {
            if (shopBuildingID.Category == ele.GetShopBuilding().Category)
            {
                if (shopBuildingID.ID != ele.GetShopBuilding().ID)
                {
                    ele.ProhibitedBuild();
                }
            }
        }
    }
}
