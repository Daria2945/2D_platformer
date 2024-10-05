using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action<Coin> IsCoinFound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin _coin))
        {
            IsCoinFound?.Invoke(_coin);
        }
    }
}