using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CoinSpawnPoint : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    public bool IsCoinCollected { get; private set; }

    private Coin _coin;

    private void Awake()
    {
        IsCoinCollected = true;

        _coin = Instantiate(_prefab, transform);
        _coin.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player _))
        {
            CollectCoin();
            IsCoinCollected = true;
        }
    }

    public void Spawn()
    {
        _coin.gameObject.SetActive(true);
        IsCoinCollected = false;
    }

    private void CollectCoin()
    {
        _coin.gameObject.SetActive(false);
    }
}