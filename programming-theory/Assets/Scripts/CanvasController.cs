using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuPanel;

    [SerializeField]
    private GameObject _gameplayPanel;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    // Start is called before the first frame update
    private void Start()
    {
        

        MasterSingleton.instance.SceneLoader.OnMenuLoaded += EnableMenuPanel;
        MasterSingleton.instance.SceneLoader.OnMenuLoaded += DisableGameplayPanel;

        MasterSingleton.instance.SceneLoader.OnGameplayLoaded += EnableGameplayPanel;
        MasterSingleton.instance.SceneLoader.OnGameplayLoaded += DisableMenuPanel;
    }

    private void OnDestroy()
    {
        MasterSingleton.instance.SceneLoader.OnMenuLoaded -= EnableMenuPanel;
        MasterSingleton.instance.SceneLoader.OnMenuLoaded -= DisableGameplayPanel;

        MasterSingleton.instance.SceneLoader.OnGameplayLoaded -= EnableGameplayPanel;
        MasterSingleton.instance.SceneLoader.OnGameplayLoaded -= DisableMenuPanel;
    }

    void DisableMenuPanel()
    {
        _menuPanel.SetActive(false);
    }

    void EnableMenuPanel()
    {
        _menuPanel.SetActive(true);
    }

    void DisableGameplayPanel()
    {
        _gameplayPanel.SetActive(false);
    }

    void EnableGameplayPanel()
    {
        _gameplayPanel.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }
}
