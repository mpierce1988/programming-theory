using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private const string _menuName = "menu";

    [SerializeField]
    private const string _gameplayName = "gameplay";

    public event Action OnMenuLoaded = delegate { };
    public event Action OnGameplayLoaded = delegate { };

    public void LoadMenu()
    {
        SceneManager.LoadScene(_menuName);
        OnMenuLoaded.Invoke();
    }

    public void LoadGameplay()
    {
        SceneManager.LoadScene(_gameplayName);
        OnGameplayLoaded.Invoke();
    }
}
