using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
   

    void Update()
    {
        GetTouchDeltaPosition();
        IsThereTouchScreen();
    }

    public Vector2 GetTouchDeltaPosition()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).deltaPosition;
        }
        return Vector2.zero;
    }

    public bool IsThereTouchScreen()
    {
        if (Input.touchCount > 0) return true;
        else return false;
    }
}
