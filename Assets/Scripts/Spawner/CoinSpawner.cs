using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawnPoint[] _spawnerPoints;
    [SerializeField] private float _spawnDelay = 2;
    [SerializeField] private int _maxCoinsPerLevel = 20;

    private int _numberOfCoinsGreated;

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSecondsRealtime(_spawnDelay);

        while (_numberOfCoinsGreated < _maxCoinsPerLevel)
        {
            yield return wait;

            int index = Random.Range(0, _spawnerPoints.Length);

            if (_spawnerPoints[index].IsFreePoint)
                _spawnerPoints[index].ShowCoin();

            _numberOfCoinsGreated++;
        }
    }
}