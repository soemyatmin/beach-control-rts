using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager> {
  [SerializeField] private ShopController _shopController;
  [SerializeField] private BuildingController _buildingController;
  private BuildingDataManager _buildingDataManager;

  void Start() {
    MasterData.Instance.Init();
    _buildingDataManager = GetComponent<BuildingDataManager>();
    _shopController.Init();
    //_buildingController.Init();
    _buildingDataManager.Init();
  }

  public ShopController ShopController() {
    return _shopController;
  }

  public BuildingController BuildingController() {
    return _buildingController;
  }
  public BuildingDataManager BuildingDataManager() {
    return _buildingDataManager;
  }
}