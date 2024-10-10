using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins;

    public void CollectCoin()
    {
        _coins++;
    }
}