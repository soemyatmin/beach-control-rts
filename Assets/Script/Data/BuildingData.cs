using UnityEngine;

public class BuildingData
{
    public int ID;
    public string BuildingName;
    public string BuildingDescription;
    public int BuildingHitPoint;
    
    public int BuidingArmorPercent;
    public float BuildingGridX;
    public float BuildingGridY;
    public int TagWeapon;

    public BuildingData(int id, string buildingName, string buildingDescription, int buildingHitPoint, int buidingArmorPercent, float buildingGridX, float buildingGridY, int tagWeapon)
    {
        ID = id;
        BuildingName = buildingName;
        BuildingDescription = buildingDescription;
        BuildingHitPoint = buildingHitPoint;
        BuidingArmorPercent = buidingArmorPercent;
        BuildingGridX = buildingGridX;
        BuildingGridY = buildingGridY;
        TagWeapon = tagWeapon;
    }
}
