using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private LayerMask rayMask;
    [SerializeField] private float interactDistance = 2.5f;

    private Interactable focused;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, interactDistance,
            rayMask))
        {
            var interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null && interactable != focused)
            {
                interactable.Focus();
                focused = interactable;
            }
        }
        else
        {
            if (focused != null)
            {
                focused.Unfocus();
                focused = null;
            }
        }
    }
}
