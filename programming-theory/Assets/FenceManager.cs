using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoints;

    public void PlaceAnimal(Animal animal)
    {
        if(_spawnPoints.Count <= 0)
        {
            Debug.Log("No Spawn Points Remaining.");
            return;
        }

        int index = UnityEngine.Random.Range(0, _spawnPoints.Count);
        Transform randomTransform = _spawnPoints[index];
        animal.gameObject.transform.position = randomTransform.position;
        animal.gameObject.transform.rotation = randomTransform.rotation;
        animal.DisableAI();

        _spawnPoints.RemoveAt(index);

    }
}
