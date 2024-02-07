using UnityEngine;

public class Book : Interactable
{
    [field: SerializeField]
    public int Library { get; private set; }

    [field: SerializeField]
    public int Position { get; private set; }

    public override void Activate()
    {
        return;
    }
}
