using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float ZoomOutMin = 1;
    public float ZoomOutMax = 8;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZeroPrevPos - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;
            Zoom(difference * 0.01f);
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
    }
    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, ZoomOutMin, ZoomOutMax);
    }
}
