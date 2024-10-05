using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _detectorRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayerMask;

    public bool GetIsGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _detectorRadius, _groundLayerMask);

        return hit != null && hit.TryGetComponent(out Ground _);
    }
}