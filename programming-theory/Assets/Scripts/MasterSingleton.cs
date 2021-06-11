using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton instance { get; private set; }

    public SceneLoader SceneLoader { get { return _sceneLoader; } }
    public CanvasController CanvasController { get { return _canvasController; } }
    public SoundEffects SoundEffects { get { return _soundEffects; } }

    private SoundEffects _soundEffects;
    private SceneLoader _sceneLoader;
    private CanvasController _canvasController;
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
        _canvasController = GetComponentInChildren<CanvasController>();
        _soundEffects = GetComponentInChildren<SoundEffects>();
    }

    
}
