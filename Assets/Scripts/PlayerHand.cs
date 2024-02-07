using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Transform pivot;

    public Interactable Held { get; private set; }

    public void Hold(Interactable interactable)
    {
        if (Held != null)
        {
            return;
        }

        Transform t = interactable.gameObject.transform;
        t.SetParent(pivot.transform, false);
        t.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        interactable.enabled = false;

        Held = interactable;
    }

    public Interactable Take()
    {
        if (Held == null)
        {
            return null;
        }

        Interactable ret = Held;
        Held = null;
        return ret;
    }
}
