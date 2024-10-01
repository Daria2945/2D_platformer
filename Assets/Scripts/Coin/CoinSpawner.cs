using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private float _spawnDelay = 2;

    private CoinSpawnPoint[] _spawnerPoints;

    private void Awake()
    {
        _spawnerPoints = GetPoints();
        StartCoroutine(Spawn());
    }

    private CoinSpawnPoint[] GetPoints()
    {
        CoinSpawnPoint[] spawnerPoints = new CoinSpawnPoint[_spawner.childCount];

        for (int i = 0; i < spawnerPoints.Length; i++)
        {
            spawnerPoints[i] = _spawner.GetChild(i).GetComponent<CoinSpawnPoint>();
        }

        return spawnerPoints;
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSecondsRealtime(_spawnDelay);

        while (true)
        {
            yield return wait;

            int index = Random.Range(0, _spawnerPoints.Length);

            if (_spawnerPoints[index].IsCoinCollected)
                _spawnerPoints[index].Spawn();
        }
    }
}