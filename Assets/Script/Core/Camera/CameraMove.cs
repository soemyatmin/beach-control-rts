using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour {

    public GameObject[] Buttons;
    public float CameraMovementSpeed;

    ScreenPosition screenPosition = ScreenPosition.None;
    Vector3 moveDir;

    [System.Serializable]
    public enum ScreenPosition {
        Up,
        Down,
        Left,
        Right,
        None
    };

    void Start() {
        moveDir = Vector3.zero;
        for (int i = 0; i < Buttons.Length; i++) {
            HoverTrigger(Buttons[i]);
            HoverTriggerStop(Buttons[i]);
        }
    }

    void Update() {
        switch (screenPosition) {
            case ScreenPosition.Up:
                moveDir = transform.forward;
                break;
            case ScreenPosition.Down:
                moveDir = -transform.forward;
                break;
            case ScreenPosition.Left:
                moveDir = -transform.right;
                break;
            case ScreenPosition.Right:
                moveDir = transform.right;
                break;
            case ScreenPosition.None:
                moveDir = Vector3.zero;
                break;
        }
        transform.localPosition += moveDir * CameraMovementSpeed * Time.deltaTime;
    }


    public void HoverTrigger(GameObject fmitem) {
        EventTrigger pointerHoverTrigger = fmitem.GetComponent<EventTrigger>();
        EventTrigger.Entry yourNewEntry = new EventTrigger.Entry();
        yourNewEntry.eventID = EventTriggerType.PointerEnter;
        pointerHoverTrigger.triggers.Add(yourNewEntry);
        yourNewEntry.callback.AddListener((eventData) => {
            CameraViewMove(fmitem.GetComponent<CameraMovingBtn>().ButtonPosition);
        });
    }

    public void HoverTriggerStop(GameObject fmitem) {
        EventTrigger pointerHoverTrigger = fmitem.GetComponent<EventTrigger>();
        EventTrigger.Entry yourNewEntry = new EventTrigger.Entry();
        yourNewEntry.eventID = EventTriggerType.PointerExit;
        pointerHoverTrigger.triggers.Add(yourNewEntry);
        yourNewEntry.callback.AddListener((eventData) => {
            CameraViewStop();
        });
    }


    public void CameraViewMove(ScreenPosition screenPosition) {
        this.screenPosition = screenPosition;
    }

    public void CameraViewStop() {
        screenPosition = ScreenPosition.None;
    }
}
