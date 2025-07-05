using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private ShopController _shopController;
    [SerializeField] private BuildingController _buildingController;

    void Start()
    {
        MasterData.Instance.Init();
        _shopController.Init();
        _buildingController.Init();
    }
    
    public ShopController ShopController()
    {
        return _shopController;
    }
    
    public BuildingController BuildingController()
    {
        return _buildingController;
    }
}
