using UnityEngine;

public class CheckNearByBuilding : MonoBehaviour {
  private Renderer[] renderers;
  private static readonly int OverlayColorID = Shader.PropertyToID("_OverlayColor");
  private static readonly int UseTwinkleID = Shader.PropertyToID("_UseTwinkle");
  private static readonly int TwinkleSpeedID = Shader.PropertyToID("_TwinkleSpeed");
  private static readonly int MinStrengthID = Shader.PropertyToID("_MinStrength");
  private static readonly int MaxStrengthID = Shader.PropertyToID("_MaxStrength");
  private BoxCollider buildingCollider;

  public float placementPadding = 1f;

  void Awake() {
    renderers = GetComponentsInChildren<Renderer>();
    buildingCollider = GetComponent<BoxCollider>();
  }

  public bool IsPlacementValid() {
    Vector3 clearanceAreaSize = buildingCollider.size + new Vector3(placementPadding * 2, 0, placementPadding * 2);

    Collider[] hits = Physics.OverlapBox(transform.position, clearanceAreaSize / 2, Quaternion.identity, LayerMask.GetMask("Building"));

    return hits.Length == 0;
  }

  public void SetHighlight(Color color, float speed, float minAlpha, float maxAlpha, bool useTwinkle) {
    SetMaterialProperty(mat => {
      mat.SetColor(OverlayColorID, new Color(color.r, color.g, color.b, 0));
      mat.SetFloat(UseTwinkleID, useTwinkle ? 1.0f : 0.0f);
      mat.SetFloat(TwinkleSpeedID, speed);
      mat.SetFloat(MinStrengthID, minAlpha);
      mat.SetFloat(MaxStrengthID, maxAlpha);
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
    SetHighlight(Color.clear, 0, 0, 0, false);
  }

  private void OnDrawGizmos() {
    if (buildingCollider == null) return;

    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube(transform.position, buildingCollider.size);

    Gizmos.color = Color.cyan;
    Vector3 clearanceSize = buildingCollider.size + new Vector3(placementPadding * 2, 0, placementPadding * 2);
    Gizmos.DrawWireCube(transform.position, clearanceSize);
  }
}