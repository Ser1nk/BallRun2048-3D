using UnityEngine;
using UnityEngine.UI;

public class ParentBall : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text _score;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private SceneLoader _scene;

    [Header("Effects")]
    [SerializeField] private Audio _audio;
    [SerializeField] private VibrateController _vibrate;
    [SerializeField] private PhysicsMovement _movement;

    [Header("Materials")]
    [SerializeField] private Material[] materials;

    private Vector3 _scaleParameter = new Vector3(0.1f, 0.1f, 0.1f);

    private int _health = 2;

    private void Update()
    {
        _score.text = _health.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GlobalStringVars.Finish && _health == 2048)
        {
            _winPanel.SetActive(true);
            _audio.PlayWinSound();
        }

        else if (collision.gameObject.tag == GlobalStringVars.Finish && _health != 2048)
            _scene.Restart();

        if (collision.gameObject.tag == GlobalStringVars.DeathZone)
            _scene.Restart();
    }

    public bool TryMerge(int childNumber)
    {
        if (_health == childNumber)
        {
            _health += childNumber;

            SetMaterial();

            Resize(_scaleParameter);

            _audio.PlayMergeSound();

            _vibrate.Vibrate();

            return true;
        }

        _audio.PlayHitSound();

        return false;
    }

    public void TakeDamage(int damage)
    {
        _health /= damage;

        SetMaterial();

        Resize(-_scaleParameter);

        TryDie();

        _audio.PlayDamageSound();

        _vibrate.Vibrate();
    }

    public void Resize(Vector3 _scale)
    {
        transform.localScale += _scale;
    }

    public void BoostBall()
    {
        
    }

    private void TryDie()
    {
        if (_health < 2)
        {
            _health = 0;

            _scene.Restart();

            Destroy(gameObject);
        }
    }

    private void SetMaterial() //good practies
    {
        switch (_health)
        {
            case 2:
                GetComponent<Renderer>().material = materials[0];
                break;
            case 4:
                GetComponent<Renderer>().material = materials[1];
                break;
            case 8:
                GetComponent<Renderer>().material = materials[2];
                break;
            case 16:
                GetComponent<Renderer>().material = materials[3];
                break;
            case 32:
                GetComponent<Renderer>().material = materials[4];
                break;
            case 64:
                GetComponent<Renderer>().material = materials[5];
                break;
            case 128:
                GetComponent<Renderer>().material= materials[6];
                break;
            case 256:
                GetComponent<Renderer>().material = materials[7];
                break;
            case 512:
                GetComponent<Renderer>().material= materials[8];
                break;
            case 1024:
                GetComponent<Renderer>().material= materials[9];
                break;
            case 2048:
                GetComponent<Renderer>().material = materials[10];
                break;
            default:
                Debug.LogError("Error, incorrect ParentBall._health");
                break;
        }
    }

}
