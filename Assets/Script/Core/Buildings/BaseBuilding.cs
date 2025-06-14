using UnityEngine;

public class BaseBuilding :MonoBehaviour
{
    private BuildingData buildingData;
    public virtual void  Init(BuildingData buildingData)
    {
        this.buildingData = buildingData;
    }

}