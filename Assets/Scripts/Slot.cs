using System;
using UnityEngine;

public class Slot : Interactable
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Book book;

    private new Renderer renderer;

    public Book Contained { get; private set; }

    public override void Activate()
    {
        base.Unfocus();
        Focus();
    }

    public override void Focus()
    {
        if (Contained != null)
        {
            Contained.Focus();
        }
        else
        {
            base.Focus();
        }
    }

    public override void Unfocus()
    {
        if (Contained != null)
        {
            Contained.Unfocus();
        }
        else
        {
            base.Unfocus();
        }
    }

    public void Place(Book book)
    {
        if (Contained != null)
        {
            return;
        }

        Transform t = book.gameObject.transform;
        t.SetParent(pivot.transform);
        t.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        renderer.enabled = false;

        book.enabled = false;

        Contained = book;

        OnPlace?.Invoke();
    }

    public Book Take()
    {
        if (Contained == null)
        {
            return null;
        }

        Contained.Unfocus();
        renderer.enabled = true;

        Book ret = Contained;
        Contained = null;

        return ret;
    }

    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();

        if (book != null)
        {
            Book bookInstance = Instantiate(book);
            Place(bookInstance);
        }
    }

    public event Action OnPlace;
}
