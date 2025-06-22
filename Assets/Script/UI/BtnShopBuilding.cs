using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnShopBuilding : MonoBehaviour
{
    [SerializeField] private Button btnToBuild;
    [SerializeField] private Button btnReadyBuild;
    [SerializeField] private Button btnCancelBuild;
    [SerializeField] private GameObject readyStatusGameObject;
    [SerializeField] private Slider sliderProgressShow;
    
    private ShopBuildingButtonData _shopBuildingButtonData;
    
    public void Init(ShopBuildingButtonData shopBuildingButtonData)
    {
        this._shopBuildingButtonData = shopBuildingButtonData;
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
