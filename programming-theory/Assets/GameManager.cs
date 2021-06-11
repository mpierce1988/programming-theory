using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _animalsToSpawn;
    [SerializeField]
    private List<Transform> _spawnPoints;

    private int _animalCount;
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        _animalCount = _animalsToSpawn.Count;
        SpawnAnimals();
        MasterSingleton.instance.CanvasController.UpdateScore(0);
    }

    private void SpawnAnimals()
    {
        // spawn each animal in list at a random spawn point, and register callback for OnGrabbed
        foreach (GameObject animal in _animalsToSpawn)
        {  
            Instantiate(animal, RandomSpawnPoint().position, Quaternion.identity);
            animal.GetComponent<Animal>().OnGrabbed += AnimalGrabbed;
        }
    }

    Transform RandomSpawnPoint()
    {
        int spawnIndex = UnityEngine.Random.Range(0, _spawnPoints.Count);
        Transform spawnPoint = _spawnPoints[spawnIndex];
        _spawnPoints.RemoveAt(spawnIndex);

        return spawnPoint;
    }

    void AnimalGrabbed()
    {
        _animalCount--;

        UpdateScore();

        if(_animalCount <= 0)
        {
            EndGame();
        }
    }

    void UpdateScore()
    {
        // increment score
        _score++;

        // update score text
        MasterSingleton.instance.CanvasController.UpdateScore(_score);
    }

    void EndGame()
    {
        // activate end game panel
    }
}
