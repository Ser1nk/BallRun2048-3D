using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    private void Update()
    {
        float horizontal = Input.GetAxis(GlobalStringVars.Horizontal);

        //_movement.Move(horizontal);
    }
}
