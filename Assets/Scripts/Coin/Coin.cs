using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Coin : MonoBehaviour
{
    public bool HasTriggered { get; private set; }

    private void Awake()
    {
        Hide();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player _))
        {
            Hide();
        }
    }

    public void ResetTrigger()
    {
        HasTriggered = false;
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        HasTriggered = true;
        gameObject.SetActive(false);
    }
}