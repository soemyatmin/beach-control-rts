using System.Collections.Generic;
using UnityEngine;

public class BuildingDataManager : MonoBehaviour {
  private Dictionary<int, BuildingData> buildingDataDictionary;

  public void Init() {
    buildingDataDictionary = new Dictionary<int, BuildingData>();

    List<BuildingData> masterList = MasterData.Instance.GetMasterBuildingData();

    foreach (var data in masterList) {
      if (!buildingDataDictionary.ContainsKey(data.ID)) {
        buildingDataDictionary.Add(data.ID, data);
      } else {
        Debug.LogWarning($"Duplicate Building ID {data.ID} found in MasterData!");
      }
    }
  }

  public BuildingData GetBuildingData(int id) {
    if (buildingDataDictionary.TryGetValue(id, out BuildingData data)) {
      return data;
    }
    Debug.LogError($"BuildingData with ID {id} not found!");
    return null;
  }
}