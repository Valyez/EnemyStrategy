using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    /*SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<> _potionsPrefabs;
    [SerializeField] private float _cooldown;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _cooldown)
        {
            Spawn();
            _timer = 0;
        }
    }

    private void Spawn()
    {
        List<SpawnPoint> emptySpawnPoints = _spawnPoints
            .Where(e => e.IsFree)
            .ToList();

        if (emptySpawnPoints.Capacity == 0)
        {
            return;
        }

        Potion randomPotion = _potionsPrefabs[Random.Range(0, _potionsPrefabs.Count)];
        SpawnPoint randomPosition = emptySpawnPoints[Random.Range(0, emptySpawnPoints.Count)];
        Potion newPotion = Instantiate(randomPotion, randomPosition.transform);
        randomPosition.Occupy(newPotion);
    }*/
}