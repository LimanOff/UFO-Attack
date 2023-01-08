using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _prefabOfEnemy;

    [Header("Parent")]
    [SerializeField] private GameObject _parentOfEnemies;

    [Header("SpawnPoints")]
    [SerializeField] private GameObject[] _spawnPoints;

    private void OnEnable()
    {
        UIEvents.OnStartCountButtonTouch += StartSpawn;
    }

    private void OnDisable()
    {
        UIEvents.OnStartCountButtonTouch -= StartSpawn;
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 randomPos = CalculateRandomPosition();
            Instantiate(_prefabOfEnemy, randomPos, Quaternion.identity, _parentOfEnemies.transform);
            yield return new WaitForSeconds(1f);
        }
    }

    private Vector3 CalculateRandomPosition()
    {
        Vector3 randomPos = _spawnPoints[Random.Range(0,_spawnPoints.Length-1)].transform.position;
        return randomPos;
    }
}
