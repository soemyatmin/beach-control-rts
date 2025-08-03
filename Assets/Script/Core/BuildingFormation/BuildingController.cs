using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingController : MonoBehaviour {
  [Header("Placement Settings")]
  [SerializeField] private LayerMask groundLayerMask;

  [Header("Twinkle - Placeable (Green)")]
  [SerializeField] private float placeableTwinkleSpeed = 10f;
  [SerializeField] [Range(0, 1)] private float placeableMinAlpha = 0.2f;
  [SerializeField] [Range(0, 1)] private float placeableMaxAlpha = 0.5f;

  [Header("Twinkle - Unplaceable (Red)")]
  [SerializeField] private float unplaceableTwinkleSpeed = 25f;
  [SerializeField] [Range(0, 1)] private float unplaceableMinAlpha = 0.3f;
  [SerializeField] [Range(0, 1)] private float unplaceableMaxAlpha = 0.7f;

  private GameObject objectToPlace;
  private CheckNearByBuilding objectChecker;
  private Camera mainCamera;
  private bool lastPlacementValidity = true;
  private Dictionary<int, BuildingData> buildingDataDictionary;

  public void Init() {
    // TODO: Load building master data

    buildingDataDictionary = new Dictionary<int, BuildingData>();

    List<BuildingData> masterList = MasterData.Instance.GetMasterBuildingData();

    foreach (var data in masterList) {
      if (!buildingDataDictionary.TryAdd(data.ID, data)) {
        Debug.LogWarning($"Duplicate Building ID {data.ID} found in MasterData!");
      }
    }
  }

  private void Start() {
    mainCamera = Camera.main;
  }

  void Update() {
    if (objectToPlace != null) {
      if (Input.GetMouseButtonDown(1)) {
        CancelPlacement();
        return;
      }
      FollowMouseAndApplyHighlight();
      if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject()) {
        if (objectChecker.IsPlacementValid()) {
          PlaceBuilding();
        }
      }
    }
  }

  public void BuildBuildingFromUI(ShopButtonData data) {
    if (data == null) return;
    if (objectToPlace != null) CancelPlacement();

    BuildingData buildingData = GetBuildingData(data.ID);
    if (buildingData?.ModelGameObject == null) return;

    objectToPlace = Instantiate(buildingData.ModelGameObject);
    objectChecker = objectToPlace.GetComponent<CheckNearByBuilding>();

    objectChecker.placementPadding = buildingData.PlacementPadding;

    BoxCollider bc = objectToPlace.GetComponent<BoxCollider>();
    if (bc != null) {
      bc.size = new Vector3(buildingData.BuildingGridX, bc.size.y, buildingData.BuildingGridY);
    }

    objectToPlace.GetComponent<Collider>().enabled = false;
    objectToPlace.layer = 0;

    FollowMouseAndApplyHighlight();
    lastPlacementValidity = !objectChecker.IsPlacementValid();
    ApplyHighlightState(objectChecker.IsPlacementValid());
  }

  private BuildingData GetBuildingData(int id) {
    if (buildingDataDictionary.TryGetValue(id, out BuildingData data)) {
      return data;
    }
    Debug.LogError($"BuildingData with ID {id} not found!");
    return null;
  }

  private void FollowMouseAndApplyHighlight() {
    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundLayerMask)) {
      objectToPlace.transform.position = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
      bool isCurrentlyValid = objectChecker.IsPlacementValid();
      if (isCurrentlyValid != lastPlacementValidity) {
        ApplyHighlightState(isCurrentlyValid);
        lastPlacementValidity = isCurrentlyValid;
      }
    }
  }

  private void ApplyHighlightState(bool isValid) {
    if (isValid) { objectChecker.SetHighlight(Color.green, placeableTwinkleSpeed, placeableMinAlpha, placeableMaxAlpha, true); } else {
      objectChecker.SetHighlight(Color.red, unplaceableTwinkleSpeed, unplaceableMinAlpha, unplaceableMaxAlpha, true);
    }
  }

  private void PlaceBuilding() {
    objectChecker.BuildAction();
    objectToPlace = null;
    objectChecker = null;
  }

  private void CancelPlacement() {
    if (objectToPlace == null) return;
    objectChecker.SetHighlight(Color.clear, 0, 0, 0, false);
    Destroy(objectToPlace);
    objectToPlace = null;
    objectChecker = null;
  }
}