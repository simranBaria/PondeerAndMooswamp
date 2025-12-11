using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool drag;
    private Vector3 screenPoint, offset;
    RectTransform rect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(drag)
        {
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;

            cursorPosition.x = Mathf.Clamp(cursorPosition.x, -20, 20);
            cursorPosition.y = Mathf.Clamp(cursorPosition.y, -20, 20);

            rect.position = cursorPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = rect.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
        rect.position = Vector3.zero;
        throw new System.NotImplementedException();
    }
}
