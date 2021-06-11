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
        Debug.Log("AnimalGrabber trigger.");
        if (other.GetComponent<Animal>())
        {
            _fenceManager.PlaceAnimal(other.GetComponent<Animal>());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AnimalGrabber trigger.");
        if (collision.gameObject.GetComponent<Animal>())
        {
            _fenceManager.PlaceAnimal(collision.gameObject.GetComponent<Animal>());
        }
    }
}
