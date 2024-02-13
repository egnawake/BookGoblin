using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private LayerMask rayMask;
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private float interactDistance = 2.5f;
    [SerializeField] private PlayerHand hand;
    [SerializeField] private Transform world;
    private PlayerSounds playerSounds;

    private Interactable focused;

    private void Start()
    {
        playerSounds = GetComponent<PlayerSounds>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, interactDistance,
            rayMask))
        {
            var interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null && interactable.enabled && interactable != focused)
            {
                if (focused != null)
                {
                    focused.Unfocus();
                }

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

        if (Input.GetButtonDown("Fire1") && focused != null)
        {
            Debug.Log($"Interacted with {focused.gameObject.name}");
            Handle(focused);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Interactable item = hand.Take();
            if (item != null)
            {
                Drop(item);
            }
        }
    }

    private void Handle(Interactable interactable)
    {
        if (interactable is Book book)
        {
            hand.Hold(book);
            playerSounds.PlayBookPickUpSound();
        }
        else if (interactable is Slot slot)
        {
            Book bookInHand = hand.Take() as Book;
            Book bookInSlot = slot.Take();

            if (bookInHand != null)
            {
                slot.Place(bookInHand);
                playerSounds.PlayBookPlaceSound();
            }

            if (bookInSlot != null)
            {
                hand.Hold(bookInSlot);
                playerSounds.PlayBookPickUpSound();
            }
        }

        focused.Activate();
    }

    private void Drop(Interactable item)
    {
        item.enabled = true;

        Transform itemTransform = item.gameObject.transform;
        itemTransform.SetParent(world.transform);
        itemTransform.position = FindDropPosition();
        playerSounds.PlayBookDropSound();
    }

    private Vector3 FindDropPosition()
    {
        Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit, floorMask);
        return hit.point;
    }
}
