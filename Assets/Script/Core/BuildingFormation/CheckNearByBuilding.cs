using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNearByBuilding : MonoBehaviour {
    private Renderer[] renderers;
    private static readonly int OverlayColorID = Shader.PropertyToID("_OverlayColor");
    private static readonly int UseTwinkleID = Shader.PropertyToID("_UseTwinkle");
    private static readonly int TwinkleSpeedID = Shader.PropertyToID("_TwinkleSpeed");
    private static readonly int MinStrengthID = Shader.PropertyToID("_MinStrength");
    private static readonly int MaxStrengthID = Shader.PropertyToID("_MaxStrength");
    private static readonly int StaticStrengthID = Shader.PropertyToID("_OverlayStrength");
    private BoxCollider buildingCollider;

    public float placementPadding = 0f;

    void Awake() {
        renderers = GetComponentsInChildren<Renderer>();
        buildingCollider = GetComponent<BoxCollider>();
    }

    public bool IsPlacementValid() {
        Vector3 clearanceAreaSize = buildingCollider.size + new Vector3(placementPadding * 2, 0, placementPadding * 2);
        Collider[] m_HitDetect = Physics.OverlapBox(
            transform.position,
            clearanceAreaSize / 2,
            Quaternion.identity,
            LayerMask.GetMask("Building"));

        return m_HitDetect.Length == 0;
    }

    public void SetHighlightColor(Color color) {
        SetMaterialProperty(mat => mat.SetColor(OverlayColorID, color));
    }

    public void SetTwinkle(float speed, float minStrength, float maxStrength) {
        SetMaterialProperty(mat => {
            mat.SetFloat(TwinkleSpeedID, speed);
            mat.SetFloat(MinStrengthID, minStrength);
            mat.SetFloat(MaxStrengthID, maxStrength);
        });
    }

    public void EnableHighlight(bool enable) {
        float useTwinkle = enable ? 1.0f : 0.0f;
        SetMaterialProperty(mat => {
            mat.SetFloat(UseTwinkleID, useTwinkle);
            if (!enable) {
                mat.SetFloat(StaticStrengthID, 0f);
            }
        });
    }

    private void SetMaterialProperty(System.Action<Material> setPropertyAction) {
        foreach (var rend in renderers) {
            foreach (var mat in rend.materials) {
                setPropertyAction(mat);
            }
        }
    }

    public void BuildAction() {
        GetComponent<Collider>().enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Building");
        gameObject.tag = "building";
        EnableHighlight(false);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(transform.position + new Vector3(0, GetComponent<BoxCollider>().center.y, 0),
          new Vector3(GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z));
    }
}