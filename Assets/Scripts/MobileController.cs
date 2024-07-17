using UnityEngine;

public class MobileController : MonoBehaviour
{    
    public float ZoomOutMin = 1;
    public float ZoomOutMax = 20;

    private Vector2 touchStartPos;
    private float swipeThresholdX = 100f;
    private float swipeThresholdY = 50f;
    private bool xDirectionChanged = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                xDirectionChanged = false;
            }
            else if (touch.phase == TouchPhase.Moved && !xDirectionChanged)
            {
                Vector2 currentPos = touch.position;
                if (Mathf.Sign(currentPos.x - touchStartPos.x) != Mathf.Sign(touch.position.x - touchStartPos.x))
                {
                    xDirectionChanged = true;
                    touchStartPos = touch.position;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 touchEndPos = touch.position;
                float swipeDistanceX = touchEndPos.x - touchStartPos.x;
                float swipeDistanceY = touchEndPos.y - touchStartPos.y;

                if (Mathf.Abs(swipeDistanceX) >= swipeThresholdX &&
                    Mathf.Abs(swipeDistanceY) <= swipeThresholdY &&
                    swipeDistanceX > 0)
                {
                    Debug.Log("Swipe right");
                }
            }
        }
        if (Input.touchCount == 2)
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
    }
    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, ZoomOutMin, ZoomOutMax);
    }
}
