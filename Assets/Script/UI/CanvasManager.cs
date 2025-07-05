using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : SingletonMonoBehaviour<CanvasManager>
{
    [SerializeField] private BuildingTrainingList _buildingTrainingList;

    public BuildingTrainingList BuildingTrainingList()
    {
        return _buildingTrainingList;
    }

}