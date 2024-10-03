using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawnPoint[] _spawnerPoints;
    [SerializeField] private float _spawnDelay = 2;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSecondsRealtime(_spawnDelay);

        while (true)
        {
            yield return wait;

            int index = Random.Range(0, _spawnerPoints.Length);

            if (_spawnerPoints[index].IsFreePoint)
                _spawnerPoints[index].ShowCoin();
        }
    }
}