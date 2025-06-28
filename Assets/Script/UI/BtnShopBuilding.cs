using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnShopBuilding : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI name;

    [SerializeField] private Button btnToBuild;
    [SerializeField] private Button btnReadyBuild;
    [SerializeField] private Button btnCancelBuild;
    [SerializeField] private GameObject readyStatusGameObject;
    [SerializeField] private Slider sliderProgressShow;
    
    private ShopBuildingButtonData _shopBuildingButtonData;
    
    public void Init(ShopBuildingButtonData shopBuildingButtonData)
    {
        this._shopBuildingButtonData = shopBuildingButtonData;
        BindView();
    }

    void BindView()
    {
        background.sprite = _shopBuildingButtonData.Image;
        name.text = _shopBuildingButtonData.ShopBuildingName;
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
