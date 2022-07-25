using UnityEngine;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    private Touch _touch;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                _movement.MoveTouch(_touch);
            }
        }
    }
}
