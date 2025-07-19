using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingController : MonoBehaviour
{
    // TODO: get from Resource Loader
    public GameObject building;
    public GameObject home;

    GameObject PlantedBuilding = null;
    RaycastHit hit;
    Ray ray;

    public LayerMask groundask;

    public bool buildingInProgress = false;

    private ShopButtonData currentlyBuildingShopButton;
    public void Init()
    {
        // TODO: Load buidling master data
        //throw new System.NotImplementedException();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (PlantedBuilding == null)
            {
                PlantedBuilding = Instantiate(building);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (PlantedBuilding == null)
            {
                PlantedBuilding = Instantiate(home);
            }
        }

        if (PlantedBuilding != null)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f, LayerMask.GetMask("Ground")))
            {
                if (hit.transform.tag == "ground")
                {
                    //PlantedBuilding.transform.position = hit.point;
                    //Collider[] m_HitDetect = Physics.OverlapBox(hit.point + new Vector3(0, 1.5f, 0), new Vector3(8, 3, 8) / 2, Quaternion.identity, LayerMask.GetMask("Default"));
                    Vector3 point = new Vector3(Mathf.Round(hit.point.x), 0, Mathf.Round(hit.point.z));
                    PlantedBuilding.transform.position = point;
                    // if (m_HitDetect.Length == 0) {  
                    // } else if (m_HitDetect.Length > 0) {
                    //     Debug.Log(m_HitDetect.Length);
                    //     for (int i = 0; i < m_HitDetect.Length; i++) {
                    //         Vector3 overlapObjPoint = m_HitDetect[i].transform.position;
                    //         float fx = Mathf.Abs(overlapObjPoint.x - hit.point.x);
                    //         float fz = Mathf.Abs(overlapObjPoint.z - hit.point.z);
                    //         bool isXBigger = fx > fz;
                    //         Vector3 targetPos = Vector3.zero;
                    //         if (overlapObjPoint.z > hit.point.z && !isXBigger) {
                    //             targetPos = overlapObjPoint + m_HitDetect[i].transform.forward * -8f;
                    //             targetPos.x = hit.point.x;
                    //         } else if (overlapObjPoint.z < hit.point.z && !isXBigger) {
                    //             targetPos = overlapObjPoint + m_HitDetect[i].transform.forward * 8f;
                    //             targetPos.x = hit.point.x;
                    //         } else if (overlapObjPoint.x > hit.point.x && isXBigger) {
                    //             targetPos = overlapObjPoint + m_HitDetect[i].transform.right * -8f;
                    //             targetPos.z = hit.point.z;
                    //         } else if (overlapObjPoint.x < hit.point.x && isXBigger) {
                    //             targetPos = overlapObjPoint + m_HitDetect[i].transform.right * 8f;
                    //             targetPos.z = hit.point.z;
                    //         }
                    //         if (isOkay(targetPos)) {
                    //             PlantedBuilding.transform.position = targetPos;
                    //             break;
                    //         }
                    //     }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // check allow plant here
            if (PlantedBuilding != null)
            {
                if (PlantedBuilding.GetComponent<CheckNearByBuilding>().CheckingBuildingAllowedBuild())
                {
                    PlantedBuilding.GetComponent<CheckNearByBuilding>().BuildAction();
                    PlantedBuilding = null;
                    CanvasManager.Instance.BuildingTrainingList().ResetBuildComplete(currentlyBuildingShopButton);
                }
            }
        }
    }

    public void BuildBuilding(ShopButtonData shopButtonData)
    {
        currentlyBuildingShopButton = shopButtonData;
        if (PlantedBuilding == null)
        {
            PlantedBuilding = Instantiate(building);
        }
        // TODO: Search by id to get building ID
    }


    // public bool isOkay(Vector3 point) {
    //     Collider[] m_HitDetect = Physics.OverlapBox(point, new Vector3(7.9f, 3f, 7.9f) / 2, Quaternion.identity, LayerMask.GetMask("Default"));
    //     return m_HitDetect.Length == 0;
    // }
    
}