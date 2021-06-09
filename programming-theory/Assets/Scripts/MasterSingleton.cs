using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton instance { get; private set; }

    public SceneLoader SceneLoader { get { return _sceneLoader; } }

    private SceneLoader _sceneLoader;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        _sceneLoader = GetComponentInChildren<SceneLoader>();
    }

    
}
