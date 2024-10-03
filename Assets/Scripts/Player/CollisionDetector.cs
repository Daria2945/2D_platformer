using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class CollisionDetector : MonoBehaviour
{
    public bool IsCoinFound {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin _))
        {
            IsCoinFound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin _))
        {
            IsCoinFound = false;
        }
    }
}