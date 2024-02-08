using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Library : MonoBehaviour
{
    [SerializeField] private int id;

    private IList<Slot> slots;

    private void Start()
    {
        slots = GetComponentsInChildren<Slot>();

        foreach (Slot s in slots)
        {
            s.OnPlace += HandleSlotPlace;
        }
    }

    private void HandleSlotPlace()
    {
        if (IsComplete())
        {
            Debug.Log("Puzzle complete!");
        }
    }

    private bool IsComplete()
    {
        int i = 0;
        foreach (Slot s in slots)
        {
            if (!IsBookInRightSlot(s.Contained, i))
            {
                return false;
            }

            i += 1;
        }

        return true;
    }

    private bool IsBookInRightSlot(Book book, int slotIdx)
    {
        return book != null && book.Library == id && book.Position == slotIdx;
    }
}
