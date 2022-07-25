using UnityEngine;
using UnityEngine.UI;

public class ChildBall : MonoBehaviour
{
    [SerializeField] private Text _score;

    [SerializeField] private ParentBall _parentBall;

    [SerializeField] private int _health;

    private bool _isMerge;

    private void Update()
    {
        _score.text = _health.ToString();
    }

    private void OnValidate()
    {
        if (((_health - 1) & _health) != 0 || _health > 1024)
        {
            _health = 0;

            Debug.LogError("Error ChildBall._number, enter one of the following numbers: 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024");
        }
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GlobalStringVars.Parent)
        {
           _isMerge = _parentBall.TryMerge(_health);

            if (_isMerge)
            {
                Destroy(gameObject);

               _isMerge = false;
            }
        }
    }
}
