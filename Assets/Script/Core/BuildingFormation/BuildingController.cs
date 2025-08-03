using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingController : MonoBehaviour{
    [Header("Placement Settings")]
    [SerializeField] private LayerMask groundLayerMask;

    [Header("Twinkle - Placeable (Green)")]
    [SerializeField] private float placeableTwinkleSpeed = 10f;
    [SerializeField][Range(0, 1)] private float placeableMinStrength = 0.3f;
    [SerializeField][Range(0, 1)] private float placeableMaxStrength = 0.6f;

    [Header("Twinkle - Unplaceable (Red)")]
    [SerializeField] private float unplaceableTwinkleSpeed = 25f;
    [SerializeField][Range(0, 1)] private float unplaceableMinStrength = 0.4f;
    [SerializeField][Range(0, 1)] private float unplaceableMaxStrength = 0.8f;

    private GameObject objectToPlace;
    private CheckNearByBuilding objectChecker;
    private Camera mainCamera;
    private bool lastPlacementValidity = true;

    public void Init()
    {
        
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (objectToPlace != null)
        {
            if (Input.GetMouseButtonDown(1)) { CancelPlacement(); return; }
            FollowMouseAndApplyHighlight();
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (objectChecker.IsPlacementValid()) {
                    PlaceBuilding();
                }
            }
        }
    }

    public void BuildBuildingFromUI(ShopButtonData data)
    {
        if (data == null) return;

        BuildingData buildingData = GameManager.Instance.BuildingDataManager().GetBuildingData(data.ID);
        if (buildingData == null || buildingData.ModelGameObject == null)
        {
            Debug.LogError($"Could not find valid BuildingData or ModelGameObject for ID {data.ID}");
            return;
        }

        if (objectToPlace != null) { CancelPlacement(); }

        objectToPlace = Instantiate(buildingData.ModelGameObject);
        objectChecker = objectToPlace.GetComponent<CheckNearByBuilding>();

        BoxCollider bc = objectToPlace.GetComponent<BoxCollider>();
        if (bc != null)
        {
            bc.size = new Vector3(buildingData.BuildingGridX, bc.size.y, buildingData.BuildingGridY);
        }

        objectChecker.placementPadding = buildingData.PlacementPadding;
        objectChecker.EnableHighlight(true);
        lastPlacementValidity =true;
        objectToPlace.GetComponent<Collider>().enabled = false;
        objectToPlace.layer = 0;
    }

    private void FollowMouseAndApplyHighlight()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundLayerMask))
        {
            Vector3 position = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
            objectToPlace.transform.position = position;

            bool isCurrentlyValid = objectChecker.IsPlacementValid();

            if (isCurrentlyValid != lastPlacementValidity)
            {
                if (isCurrentlyValid)
                {
                    objectChecker.SetHighlightColor(Color.green);
                    objectChecker.SetTwinkle(placeableTwinkleSpeed, placeableMinStrength, placeableMaxStrength);
                }
                else
                {
                    objectChecker.SetHighlightColor(Color.red);
                    objectChecker.SetTwinkle(unplaceableTwinkleSpeed, unplaceableMinStrength, unplaceableMaxStrength);
                }
                lastPlacementValidity = isCurrentlyValid;
            }
        }
    }

    private void PlaceBuilding()
    {
        objectChecker.BuildAction();
        objectToPlace = null;
        objectChecker = null;
    }

    private void CancelPlacement()
    {
        objectChecker.EnableHighlight(false);
        Destroy(objectToPlace);
        objectToPlace = null;
        objectChecker = null;
    }
}