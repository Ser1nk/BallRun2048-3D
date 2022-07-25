using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParentBall _parent;

    private float _timeReload = 1;
    private float _timeLeft = 0;

    private const int _damage = 2;

    private void Update()
    {
        _timeLeft += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GlobalStringVars.Parent)
        {
            if (_timeLeft >= _timeReload)
            {
                Attack();

                _timeLeft = 0;
            }
        }
    }

    private void Attack()
    {
        _parent.TakeDamage(_damage);
    }
}
