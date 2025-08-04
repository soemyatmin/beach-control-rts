using UnityEngine;

public class BuildingData {
  public int ID;
  public string BuildingName;
  public string BuildingDescription;
  public int BuildingHitPoint;

  public int BuildingArmorPercent;
  public float BuildingGridX;
  public float BuildingGridY;
  public int TagWeapon;
  public float PlacementPadding;

  public GameObject ModelGameObject;

  public BuildingData(int id, string buildingName, string buildingDescription, int buildingHitPoint, int buildingArmorPercent, float buildingGridX,
    float buildingGridY, float placementPadding, int tagWeapon, GameObject modelGameObject) {
    ID = id;
    BuildingName = buildingName;
    BuildingDescription = buildingDescription;
    BuildingHitPoint = buildingHitPoint;
    BuildingArmorPercent = buildingArmorPercent;
    BuildingGridX = buildingGridX;
    BuildingGridY = buildingGridY;
    PlacementPadding = placementPadding;
    TagWeapon = tagWeapon;
    ModelGameObject = modelGameObject;
  }
}