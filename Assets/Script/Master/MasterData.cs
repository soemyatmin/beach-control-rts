using System.Collections.Generic;
using UnityEngine;

public class MasterData : SingletonMonoBehaviour<MasterData> {
    string ShopBuildingButtonDataPrefix = "UI/Buttons/Building/";
    string ShopDefenseButtonDataPrefix = "UI/Buttons/Defense/";
    string ShopSoldierButtonDataPrefix = "UI/Buttons/Soldier/";

    string BuildingPrefabDataPrefix = "Prefabs/Building/";

    private List<ShopButtonData> shopButtonDataList = new List<ShopButtonData>();
    private List<BuildingData> buildingDataList = new List<BuildingData>();

    public void Init() {
        //Shop Building Data
        shopButtonDataList.Add(new ShopButtonData(1, "Town Center", ShopButtonData.ShopCategory.Building, "", 0, 3000, 2, 5,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-towncenter")));
        shopButtonDataList.Add(new ShopButtonData(2, "House", ShopButtonData.ShopCategory.Building, "", 0, 500, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-house")));
        shopButtonDataList.Add(new ShopButtonData(3, "Community Center", ShopButtonData.ShopCategory.Building, "", 0, 1000, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-community-center")));
        shopButtonDataList.Add(new ShopButtonData(4, "Energy Station", ShopButtonData.ShopCategory.Building, "", 0, 700, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-energy-station")));
        shopButtonDataList.Add(new ShopButtonData(5, "Gold Miner", ShopButtonData.ShopCategory.Building, "", 0, 2000, 10, 5,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-gold-miner")));

        shopButtonDataList.Add(new ShopButtonData(6, "Oil Rig", ShopButtonData.ShopCategory.Building, "", 0, 500, 10, 4,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-oil-rig")));
        shopButtonDataList.Add(new ShopButtonData(7, "University", ShopButtonData.ShopCategory.Building, "", 0, 2000, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-university")));
        shopButtonDataList.Add(new ShopButtonData(8, "Tank Factory", ShopButtonData.ShopCategory.Building, "", 0, 2000, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-tank-factory")));
        shopButtonDataList.Add(new ShopButtonData(9, "Barrack", ShopButtonData.ShopCategory.Building, "", 0, 1000, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-barrack")));
        shopButtonDataList.Add(new ShopButtonData(10, "Radio Tower", ShopButtonData.ShopCategory.Building, "", 0, 1500, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-radio-tower")));

        shopButtonDataList.Add(new ShopButtonData(11, "Tech Lab", ShopButtonData.ShopCategory.Building, "", 0, 6000, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-tech-lab")));
        shopButtonDataList.Add(new ShopButtonData(12, "Laser Gun Factory", ShopButtonData.ShopCategory.Building, "", 0, 4000, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopBuildingButtonDataPrefix + "button-shop-building-laser-gun-factory")));

        //Shop Defense Data
        shopButtonDataList.Add(new ShopButtonData(1, "Town Center", ShopButtonData.ShopCategory.Defense, "", 0, 3000, 2, 5,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopDefenseButtonDataPrefix + "button-shop-building-towncenter")));
        shopButtonDataList.Add(new ShopButtonData(2, "House", ShopButtonData.ShopCategory.Defense, "", 0, 500, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopDefenseButtonDataPrefix + "button-shop-building-towncenter")));
        shopButtonDataList.Add(new ShopButtonData(3, "Community Center", ShopButtonData.ShopCategory.Defense, "", 0, 1000, 10, 20,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopDefenseButtonDataPrefix + "button-shop-building-towncenter")));

        //Shop Soldier Data
        shopButtonDataList.Add(new ShopButtonData(1, "GL", ShopButtonData.ShopCategory.Soldier, "", 0, 100, 2, 1000,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopSoldierButtonDataPrefix + "button-shop-soldier-gl")));
        shopButtonDataList.Add(new ShopButtonData(2, "Engineer", ShopButtonData.ShopCategory.Soldier, "", 0, 500, 2, 1000,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopSoldierButtonDataPrefix + "button-shop-soldier-engineer")));
        shopButtonDataList.Add(new ShopButtonData(3, "Air Striker", ShopButtonData.ShopCategory.Soldier, "", 0, 200, 2, 1000,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopSoldierButtonDataPrefix + "button-shop-soldier-air-striker")));
        shopButtonDataList.Add(new ShopButtonData(4, "The Shield", ShopButtonData.ShopCategory.Soldier, "", 0, 1000, 2, 1000,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopSoldierButtonDataPrefix + "button-shop-soldier-shield")));
        shopButtonDataList.Add(new ShopButtonData(5, "Destroyer", ShopButtonData.ShopCategory.Soldier, "", 0, 1000, 2, 1000,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopSoldierButtonDataPrefix + "button-shop-soldier-destroyer")));
        shopButtonDataList.Add(new ShopButtonData(5, "The Bird", ShopButtonData.ShopCategory.Soldier, "", 0, 600, 2, 1000,
          UniversalLoader.Instance.LoadResourceByName<Sprite>(ShopSoldierButtonDataPrefix + "button-shop-soldier-bird")));

        //Building Data
        buildingDataList.Add(new BuildingData(1, "Town Center", "", 4000, 10, 4, 4, 1.0f, 0,
      UniversalLoader.Instance.LoadResourceByName<GameObject>(BuildingPrefabDataPrefix + "TempBuilding")));
    }

    public List<ShopButtonData> GetMasterShopBuildingButtonData() {
        return shopButtonDataList;
    }
    public List<BuildingData> GetMasterBuildingData() {
        return buildingDataList;
    }
}