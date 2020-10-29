using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    public RectTransform joystick;
    public float joyDistance;
    public float joyMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        joystick.transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        joyMagnitude = joystick.transform.localPosition.magnitude / joyDistance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joystick.position = eventData.position;
        joystick.localPosition = Vector3.ClampMagnitude(joystick.localPosition, joyDistance);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        joystick.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        joystick.position = eventData.position;
        joystick.localPosition = Vector3.ClampMagnitude(joystick.localPosition, joyDistance);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joystick.localPosition = Vector3.zero;
    }
}
