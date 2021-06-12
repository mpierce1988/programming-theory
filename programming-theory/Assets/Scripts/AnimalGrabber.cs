using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalGrabber : MonoBehaviour
{
    private FenceManager _fenceManager;

    private void Awake()
    {
        _fenceManager = FindObjectOfType<FenceManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Animal>())
        {
            Animal caughtAnimal = other.GetComponent<Animal>();
            caughtAnimal.CaptureAnimal();
            _fenceManager.PlaceAnimal(caughtAnimal);
        }
    }    
}
