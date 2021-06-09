using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private const string _menuName = "menu";

    [SerializeField]
    private const string _gameplayName = "gameplay";

    public void LoadMenu()
    {
        SceneManager.LoadScene(_menuName);
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene(_gameplayName);
    }
}
