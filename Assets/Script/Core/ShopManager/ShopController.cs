using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// load the shop, button tab change
/// </summary>
public class ShopController : MonoBehaviour {
  [SerializeField] private GameObject PrefabGameObjectShopPrefab;

  public List<ShopButtonData> MasterShopBuildingButtonData;

  public void Init() {
    LoadMasterData();
    LoadShop();
  }

  public void LoadMasterData() {
    MasterShopBuildingButtonData = MasterData.Instance.GetMasterShopBuildingButtonData();
  }

  public void LoadShop() {
    foreach (var ele in MasterShopBuildingButtonData) {
      CanvasManager.Instance.BuildingTrainingList().AddToBuildingListContent(ele, PrefabGameObjectShopPrefab);
    }
  }

  /// <summary>
  /// Refreash Loading
  /// </summary>
  public void ReloadShop() {
  }
}