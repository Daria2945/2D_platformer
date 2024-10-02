using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Coin : MonoBehaviour
{
    public bool IsCollected {  get; private set; } = false;

    public void ResetCollect()
    {
        IsCollected = false;
        gameObject.SetActive(true);
    }

    public void Collect()
    {
        IsCollected = true;
        gameObject.SetActive(false);
    }
}