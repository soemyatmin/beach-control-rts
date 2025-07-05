using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnShopBuilding : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI shopItemName;
    [SerializeField] private Button btnToBuild;
    [SerializeField] private Button btnReadyBuild;
    [SerializeField] private Button btnCancelBuild;
    [SerializeField] private GameObject readyStatusGameObject;
    [SerializeField] private Slider sliderProgressShow;
    
    [SerializeField] private GameObject statusObjectToBuild;
    [SerializeField] private GameObject statusObjectReadyBuild;
    [SerializeField] private GameObject statusObjectCancelBuild;
    [SerializeField] private GameObject statusObjectProhibitedBuild;
    
    private ShopBuildingButtonData _shopBuildingButtonData;
    
    private Coroutine cooldownCoroutine;
    public void Init(ShopBuildingButtonData shopBuildingButtonData)
    {
        this._shopBuildingButtonData = shopBuildingButtonData;
        btnToBuild.onClick.AddListener(OnClickToBuild);
        btnReadyBuild.onClick.AddListener(OnClickReadyBuild);
        btnCancelBuild.onClick.AddListener(OnClickCancelBuild);
        
        // TODO: While changing panel, status will come from data
        statusObjectToBuild.SetActive(true); 
        statusObjectReadyBuild.SetActive(false);
        statusObjectCancelBuild.SetActive(false);
        statusObjectProhibitedBuild.SetActive(false);
        
        BindView();
    }
    
    void BindView()
    {
        background.sprite = _shopBuildingButtonData.Image;
        shopItemName.text = _shopBuildingButtonData.ShopBuildingName;
    }

    private void OnClickToBuild()
    {
        StartCooldown(_shopBuildingButtonData.ShopBuildingBuildDuration);
        statusObjectToBuild.SetActive(false);
        statusObjectReadyBuild.SetActive(false);
        statusObjectCancelBuild.SetActive(true);
        // TODO: not allow to build related build
        CanvasManager.Instance.BuildingTrainingList().ProhibitedBuild(_shopBuildingButtonData.ID);
    }
    
    private void OnClickReadyBuild()
    {
        statusObjectToBuild.SetActive(false);
        statusObjectReadyBuild.SetActive(true);
        statusObjectCancelBuild.SetActive(false);
        GameManager.Instance.BuildingController().BuildBuilding(_shopBuildingButtonData.ID);
    }
    
    private void OnClickCancelBuild()
    {
        // TODO: Web version, right click to cancel
        StopCooldown();
        sliderProgressShow.value = 0;
        
        statusObjectToBuild.SetActive(true);
        statusObjectReadyBuild.SetActive(false);
        statusObjectCancelBuild.SetActive(false);
        
        CanvasManager.Instance.BuildingTrainingList().ResetBuildComplete(_shopBuildingButtonData.ID);
    }
    
    public int GetShopBuildingID()
    {
        return _shopBuildingButtonData.ID;
    }
    
    public void Reset()
    {
        statusObjectToBuild.SetActive(true);
        statusObjectReadyBuild.SetActive(false);
        statusObjectCancelBuild.SetActive(false);
        statusObjectProhibitedBuild.SetActive(false);
    }
    
    public void ProhibitedBuild()
    {
        statusObjectProhibitedBuild.SetActive(true);
    }
    
    private void StartCooldown(float seconds)
    {
        Debug.Log("StartCooldown" + seconds);
        StopAllCoroutines();
        cooldownCoroutine = StartCoroutine(CooldownRoutine(seconds));
    }
    
    private void StopCooldown()
    {
        if (cooldownCoroutine != null)
        {
            StopCoroutine(cooldownCoroutine);
            cooldownCoroutine = null;
        }
    }
    
    private IEnumerator CooldownRoutine(float seconds)
    {
        float elapsed = 0f;
        while (elapsed < seconds)
        {
            elapsed += Time.deltaTime;
            sliderProgressShow.value = Mathf.Lerp(100f, 0f, elapsed / seconds);
            yield return null;
        }
        sliderProgressShow.value = 0f; 
        OnCooldownFinished();
    }

    private void OnCooldownFinished()
    {
        statusObjectToBuild.SetActive(false);
        statusObjectReadyBuild.SetActive(true);
        statusObjectCancelBuild.SetActive(false);
    }
}
