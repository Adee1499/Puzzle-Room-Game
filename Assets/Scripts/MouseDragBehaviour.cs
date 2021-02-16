using UnityEngine;
using UnityEngine.EventSystems;

public class MouseDragBehaviour : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 lastMousePosition;

    /// This method will be called on the start of the mouse drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        lastMousePosition = eventData.position;
    }
    
    /// This method will be called during the mouse drag
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();

        Vector3 newPosition = rect.position +  new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;
        if(!IsRectTransformInsideSreen(rect))
        {
            rect.position = oldPos;
        }
        lastMousePosition = currentMousePosition;

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = new Quaternion(transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z + 90,
                transform.rotation.w);
        }

    }

    /// This method will be called at the end of mouse drag
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        //Implement your funtionlity here
    }

    /// This methods will check is the rect transform is inside the screen or not
    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0,0,Screen.width, Screen.height);
        foreach(Vector3 corner in corners)
        {
            if(rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if(visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }
}