using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTabs : MonoBehaviour
{
    [SerializeField] private Button btnBuildingTab;
    [SerializeField] private Button btnDefenseTab;
    [SerializeField] private Button btnSoldierTab;
    [SerializeField] private Button btnTankTab;

    void Start()
    {
        btnBuildingTab.onClick.AddListener(OnClickBuilding);
        btnDefenseTab.onClick.AddListener(OnClickDefense);
        btnSoldierTab.onClick.AddListener(OnClickSoldier);
        btnTankTab.onClick.AddListener(OnClickTank);
    }

    private void OnClickBuilding()
    {
        CanvasManager.Instance.ViewShopTab(ShopButtonData.ShopCategory.Building);
    }
    private void OnClickDefense()
    {
        CanvasManager.Instance.ViewShopTab(ShopButtonData.ShopCategory.Defense);
    }
    private void OnClickSoldier()
    {
        CanvasManager.Instance.ViewShopTab(ShopButtonData.ShopCategory.Soldier);
    }
    private void OnClickTank()
    {
        CanvasManager.Instance.ViewShopTab(ShopButtonData.ShopCategory.Tank);
    }
}
