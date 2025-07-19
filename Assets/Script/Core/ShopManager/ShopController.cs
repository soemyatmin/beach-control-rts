using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    // load the shop 
    // button tab change

    [SerializeField] private GameObject PrefabGameObjectShopPrefab;

    // [SerializeField] private Button btnBuildingTab;
    // [SerializeField] private Button btnDeferenceTab;
    // [SerializeField] private Button btnSoldierTab;
    // [SerializeField] private Button btnTankTab;

    public List<ShopButtonData> MasterShopBuildingButtonData;

    public void Init()
    {
        LoadMasterData();
        LoadShop();
    }

    public void LoadMasterData()
    {
        MasterShopBuildingButtonData = MasterData.Instance.GetMasterShopBuildingButtonData();
        // Debug.Log("complete Loading Master Data");
    }

    public void LoadShop()
    {
        foreach (var ele in MasterShopBuildingButtonData)
        {
            CanvasManager.Instance.BuildingTrainingList().AddToBuildingListContent(ele, PrefabGameObjectShopPrefab);
        }
    }

    // Refreash Loading
    public void ReloadShop()
    {
    }
}