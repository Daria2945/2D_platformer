using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private Coin _coin;

    public bool IsFreePoint => _coin.IsHidden;

    private void Awake()
    {
        _coin = Instantiate(_prefab, transform);
    }

    public void ShowCoin()
    {
        _coin.Show();
    }
}