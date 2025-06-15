using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnBuilding : MonoBehaviour
{
    
    [SerializeField] private Button btnToBuild;
    [SerializeField] private Button btnReadyBuild;
    [SerializeField] private Button btnCancelBuild;
    [SerializeField] private GameObject readyStatus;
    [SerializeField] private Slider sliderProgressShow;
    
    private BuildingButtonData buildingButtonData;
    
    public void Init(BuildingButtonData buildingButtonData)
    {
        this.buildingButtonData = buildingButtonData;
    }

    public void OnClickToBuild()
    {
        //start cooldown
        //show ready action after finish cooldown 
    }
    
    public void OnClickReadyBuild()
    {
        //right click to cancel
    }
    
}
