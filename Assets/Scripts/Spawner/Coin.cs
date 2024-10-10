using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Coin : MonoBehaviour
{
    public bool IsHidden { get; private set; }

    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        IsHidden = false;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsHidden = true;
        gameObject.SetActive(false);
    }
}