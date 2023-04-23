using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _doubleBulletPowerUpPrefab;
    [SerializeField]
    private GameObject _livesPowerUpPrefab;
    [SerializeField]
    private GameObject _asteroidPrefab;
    [SerializeField]
    private GameObject _enemy2Prefab;
    private bool _stop = false;

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(SpawnViteRoutine());
        StartCoroutine(SpawnAsteroidRoutine());
        StartCoroutine(SpawnEnemy2Routine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stop == false)
        {
            Vector3 posToSpawn = new Vector3(8, Random.Range(-2f, 3.7f), 0);
            Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator SpawnEnemy2Routine()
    {
        while (_stop == false)
        {
            yield return new WaitForSeconds(Random.Range(5f, 15f));
            Vector3 posToSpawn = new Vector3(8, Random.Range(-2f, 3.7f), 0);
            Instantiate(_enemy2Prefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5f, 15f));
        }
    }

    IEnumerator SpawnAsteroidRoutine()
    {
        while (_stop == false)
        {
            yield return new WaitForSeconds(Random.Range(4f, 10f));
            Vector3 posToSpawn = new Vector3(8, Random.Range(-2f, 3.7f), 0);
            Instantiate(_asteroidPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4f, 10f));
        }
    }


    IEnumerator SpawnPowerUpRoutine()
    {
        while (_stop == false)
        {
            yield return new WaitForSeconds(Random.Range(8f, 20f));
            Vector3 posToSpawn = new Vector3(8, Random.Range(-2f, 3.7f), 0);
            Instantiate(_doubleBulletPowerUpPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(8f, 20f));
        }
    }

    IEnumerator SpawnViteRoutine()
    {
        while (_stop == false)
        {
            yield return new WaitForSeconds(Random.Range(10f, 30f));
            Vector3 posToSpawn = new Vector3(8, Random.Range(-2f, 3.7f), 0);
            Instantiate(_livesPowerUpPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(100f, 200f));
        }
    }

    public void PlayerDeath()
    {
        _stop = true;
    }
}