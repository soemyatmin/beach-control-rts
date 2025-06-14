using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNearByBuilding : MonoBehaviour
{
    // public bool isAllowedBuild = true;

    void Update()
    {
        // CheckingBuilding();
    }

    public bool CheckingBuildingAllowedBuild()
    {
        Collider[] m_HitDetect = Physics.OverlapBox(transform.position + new Vector3(0,
                GetComponent<BoxCollider>().center.y,
                0),
            new Vector3(GetComponent<BoxCollider>().size.x, 
                GetComponent<BoxCollider>().size.y, 
                GetComponent<BoxCollider>().size.z) / 2, Quaternion.identity);
        if (m_HitDetect.Length > 0)
        {
            for (int i = 0; i < m_HitDetect.Length; i++)
            {
                Debug.Log(i + " : " + m_HitDetect[i].tag);
                if (m_HitDetect[i].tag == "building")
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void BuildAction()
    {
        GetComponent<Collider>().enabled = true;
    }
    

    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.tag == "building")
    //     {
    //         isAllowedBuild = false;
    //     }
    //     else
    //     {
    //         isAllowedBuild = true;
    //     }
    // }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 
            GetComponent<BoxCollider>().center.y
            , 0), new Vector3(
            GetComponent<BoxCollider>().size.x, 
            GetComponent<BoxCollider>().size.y, 
            GetComponent<BoxCollider>().size.z));
    }
}