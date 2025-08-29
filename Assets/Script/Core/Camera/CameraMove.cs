using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour {
  private bool isCameraLocked = false;
  [Header("Camera Positioning")]
  public Vector3 positionOffset;
  public Vector3 rotationOffset;

  [Header("Movement Settings")]
  public float panSpeed = 30f;
  public float panBorderThickness = 15f;
  public bool useEdgePanning = true;

  private Transform cameraTransform;

  private void OnValidate() {
    if (cameraTransform == null) {
      cameraTransform = GetComponentInChildren<Camera>()?.transform;
    }

    if (cameraTransform != null) {
      cameraTransform.localPosition = positionOffset;
      cameraTransform.localEulerAngles = rotationOffset;
    }
  }

  void Start() {
    cameraTransform = transform.GetChild(0);
    if (cameraTransform != null) {
      cameraTransform.localPosition = positionOffset;
      cameraTransform.localEulerAngles = rotationOffset;
    } else {
      Debug.LogError("RTSCamera script requires a child Camera object.", this);
    }
  }

  void LateUpdate() {
#if UNITY_EDITOR
    if (Input.GetKeyDown(KeyCode.Escape)) {
      isCameraLocked = !isCameraLocked;

      if (isCameraLocked) {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      }
    }

    if (isCameraLocked) {
      return;
    }
#endif

    if (Input.GetKeyDown(KeyCode.F1)) {
      Vector3 startPos = new Vector3(155f, 32f, 117f);
      Vector3 delta = startPos - transform.position;
      transform.Translate(delta, Space.World);
    }

    HandleMovement();
  }

  void HandleMovement() {
    Vector3 moveDirection = Vector3.zero;

    moveDirection.x += Input.GetAxis("Horizontal");
    moveDirection.z += Input.GetAxis("Vertical");

    if (useEdgePanning) {
      if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        moveDirection.z += 1;
      if (Input.mousePosition.y <= panBorderThickness)
        moveDirection.z -= 1;
      if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        moveDirection.x += 1;
      if (Input.mousePosition.x <= panBorderThickness)
        moveDirection.x -= 1;
    }

    if (Input.GetMouseButton(2)) {
      moveDirection.x -= Input.GetAxis("Mouse X") * 2.5f;
      moveDirection.z -= Input.GetAxis("Mouse Y") * 2.5f;
    }

    transform.Translate(moveDirection.normalized * panSpeed * Time.deltaTime, Space.Self);
  }
}