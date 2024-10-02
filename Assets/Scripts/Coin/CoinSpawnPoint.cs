using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private Coin _coin;

    public bool IsFreePoint { get { return _coin.IsCollected; } }

    private void Awake()
    {
        _coin = Instantiate(_prefab, transform);
        _coin.Collect();
    }

    public void Spawn()
    {
        _coin.ResetCollect();
    }
}