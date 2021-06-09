using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menuPanel;

    [SerializeField]
    private GameObject _gameplayPanel;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
