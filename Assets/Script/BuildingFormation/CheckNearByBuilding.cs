using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNearByBuilding : MonoBehaviour {

    void Update() {
        CheckingBuilding();
    }

    public bool CheckingBuilding() {
        Collider[] m_HitDetect = Physics.OverlapBox(transform.position + new Vector3(0, 1.5f, 0), new Vector3(8.2f, 3.2f, 8) /2, Quaternion.identity);
        if (m_HitDetect.Length > 0) {
            for (int i = 0; i < m_HitDetect.Length; i++) {
                if (m_HitDetect[i].tag == "building") {
                    return false;
                }
            }
        }
        return true;
    }

    public void BuildAction() {
        GetComponent<Collider>().enabled = true;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 1.5f, 0), new Vector3(8.2f, 3.2f, 8));
    }
}
