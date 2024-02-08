using UnityEngine;
using System.Collections.Generic;

public class Holdable : MonoBehaviour
{
    private IList<Renderer> renderers;

    private void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    public void Hold()
    {
        foreach (Renderer r in renderers)
        {
            r.gameObject.layer = LayerMask.NameToLayer("Hand");
        }
    }

    public void Drop()
    {
        foreach (Renderer r in renderers)
        {
            r.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
