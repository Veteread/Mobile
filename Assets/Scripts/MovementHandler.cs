using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    public InputHandler inputHandler;
    [SerializeField] private float speed = 0.2f;

    void Update()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        if (inputHandler.IsThereTouchScreen())
        {
            Vector2 currDeltaPos = inputHandler.GetTouchDeltaPosition();
            currDeltaPos = currDeltaPos * speed;
            Vector3 NewGravityPos = new Vector3 (currDeltaPos.x, Physics.gravity.y, currDeltaPos.y);
            Physics.gravity = NewGravityPos;
        }
    }
}
