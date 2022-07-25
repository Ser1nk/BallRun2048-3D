using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Text _score;

    [SerializeField] public int _level;

    private int _currentLevel;

    private void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        _score.text = _level.ToString();
    }

    public void LoadNext()
    {
        SaveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene()
    {
        _level = PlayerPrefs.GetInt("sceneInfo");
        SceneManager.LoadScene(_level + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void SaveScene()
    {
        PlayerPrefs.SetInt("sceneInfo", _level);
    }
}
