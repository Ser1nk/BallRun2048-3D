using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovement : MonoBehaviour
{
    [Header("Speed parameters")]
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _directionSpeed;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _forwardSpeed);
    }

    public void MoveTouch(Touch touch)
    {
        Vector3 offset = new Vector3(_rigidbody.velocity.x + touch.deltaPosition.x * _directionSpeed, _rigidbody.velocity.y, _rigidbody.velocity.z);

        _rigidbody.velocity = offset;
    }

}
