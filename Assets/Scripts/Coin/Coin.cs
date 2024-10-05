using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Coin : MonoBehaviour
{
    public bool IsHadden { get; private set; }

    private void Awake()
    {
        Collect();
    }

    public void ResetTrigger()
    {
        IsHadden = false;
        gameObject.SetActive(true);
    }

    public void Collect()
    {
        IsHadden = true;
        gameObject.SetActive(false);
    }
}