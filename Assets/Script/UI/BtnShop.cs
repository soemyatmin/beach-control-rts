using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnShop : MonoBehaviour {
  [SerializeField] private Image background;
  [SerializeField] private TextMeshProUGUI shopItemName;
  [SerializeField] private TextMeshProUGUI Count;
  [SerializeField] private Button btnToBuild;
  [SerializeField] private Button btnReadyBuild;
  [SerializeField] private Button btnCancelBuild;
  [SerializeField] private GameObject readyStatusGameObject;
  [SerializeField] private Slider sliderProgressShow;

  [SerializeField] private GameObject statusObjectToBuild;
  [SerializeField] private GameObject statusObjectReadyBuild;
  [SerializeField] private GameObject statusObjectCancelBuild;
  [SerializeField] private GameObject statusObjectProhibitedBuild;

  private ShopButtonData _shopButtonData;

  private Coroutine cooldownCoroutine;

  private int counter = 0;
  public void Init(ShopButtonData shopButtonData) {
    this._shopButtonData = shopButtonData;

    Count.gameObject.SetActive(!(shopButtonData.Category is ShopButtonData.ShopCategory.Building or ShopButtonData.ShopCategory.Defense));

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

  void BindView() {
    background.sprite = _shopButtonData.Image;
    shopItemName.text = _shopButtonData.ShopBuildingName;
  }

  public ShopButtonData GetShopBuilding() {
    return _shopButtonData;
  }

  private void OnClickToBuild() {
    if ((_shopButtonData.Category is ShopButtonData.ShopCategory.Building or ShopButtonData.ShopCategory.Defense)) {
      StartCooldown(_shopButtonData.ShopBuildingBuildDuration);
      statusObjectToBuild.SetActive(false);
      statusObjectReadyBuild.SetActive(false);
      statusObjectCancelBuild.SetActive(true);
      // TODO: not allow to build related build
      CanvasManager.Instance.BuildingTrainingList().ProhibitedBuild(_shopButtonData);
    } else {
      if (counter == 0) {
        StartCooldown(_shopButtonData.ShopBuildingBuildDuration);
      }
      AddCounter();
    }
  }

  private void OnClickReadyBuild() {
    if ((_shopButtonData.Category is ShopButtonData.ShopCategory.Building or ShopButtonData.ShopCategory.Defense)) {
      statusObjectToBuild.SetActive(false);
      statusObjectReadyBuild.SetActive(true);
      statusObjectCancelBuild.SetActive(false);
      GameManager.Instance.BuildingController().BuildBuildingFromUI(_shopButtonData);
    } 
  }

  private void OnClickCancelBuild() {
    if ((_shopButtonData.Category is ShopButtonData.ShopCategory.Building or ShopButtonData.ShopCategory.Defense)) {
      // TODO: Web version, right click to cancel
      StopCooldown();
      sliderProgressShow.value = 0;

      statusObjectToBuild.SetActive(true);
      statusObjectReadyBuild.SetActive(false);
      statusObjectCancelBuild.SetActive(false);

      CanvasManager.Instance.BuildingTrainingList().ResetBuildComplete(_shopButtonData);
    } else {
      Debug.Log("Unit Cancel");
      RemoveCounter();
    }
  }

  public void Reset() {
    statusObjectToBuild.SetActive(true);
    statusObjectReadyBuild.SetActive(false);
    statusObjectCancelBuild.SetActive(false);
    statusObjectProhibitedBuild.SetActive(false);
  }

  public void ProhibitedBuild() {
    statusObjectProhibitedBuild.SetActive(true);
  }
  
  private void StartCooldown(float seconds) {
    StopAllCoroutines();
    cooldownCoroutine = StartCoroutine(CooldownRoutine(seconds));
  }

  private void StopCooldown() {
    if (cooldownCoroutine != null) {
      StopCoroutine(cooldownCoroutine);
      cooldownCoroutine = null;
    }
  }

  private IEnumerator CooldownRoutine(float seconds) {
    float elapsed = 0f;
    while (elapsed < seconds) {
      elapsed += Time.deltaTime;
      sliderProgressShow.value = Mathf.Lerp(100f, 0f, elapsed / seconds);
      yield return null;
    }

    sliderProgressShow.value = 0f;
    OnCooldownFinished();
  }

  private void OnCooldownFinished() {
    if ((_shopButtonData.Category is ShopButtonData.ShopCategory.Building or ShopButtonData.ShopCategory.Defense)) {
      statusObjectToBuild.SetActive(false);
      statusObjectReadyBuild.SetActive(true);
      statusObjectCancelBuild.SetActive(false);
    } else {
      Debug.Log("Unit Ready");
      RemoveCounter();
      if (counter != 0) {
        StartCooldown(_shopButtonData.ShopBuildingBuildDuration);
      }
    }
  }

  private void AddCounter() {
    if (counter < 30) { // TODO: move the number to master data
      counter++;
      Count.text = counter.ToString();
    }
  }

  private void RemoveCounter() {
    if (counter > 0) {
      counter--;
      Count.text = counter.ToString();
    }
  }
}