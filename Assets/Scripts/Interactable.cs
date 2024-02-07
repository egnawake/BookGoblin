using UnityEngine;
using UnityEngine.Rendering;

public abstract class Interactable : MonoBehaviour
{
    private Material material;
    private LocalKeyword emissionKeyword;

    public virtual void Focus()
    {
        material.EnableKeyword(emissionKeyword);
    }

    public virtual void Unfocus()
    {
        material.DisableKeyword(emissionKeyword);
    }

    public abstract void Activate();

    private Material GetHighlightMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            renderer = GetComponentInChildren<Renderer>();
        }

        return renderer.material;
    }

    private void Start()
    {
        material = GetHighlightMaterial();

        emissionKeyword = new LocalKeyword(material.shader, "_EMISSION");

        material.SetColor("_EmissionColor", new Color(0.1f, 0.1f, 0.1f));
    }
}
