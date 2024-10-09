using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<Coin> CoinFound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinFound?.Invoke(coin);
        }
    }
}