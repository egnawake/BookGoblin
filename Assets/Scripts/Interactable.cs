using System;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Interactable : MonoBehaviour
{
    private Material material;
    private LocalKeyword emissionKeyword;
    private Collider trigger;

    public virtual void Focus()
    {
        if (emissionKeyword.isValid)
        {
            material.EnableKeyword(emissionKeyword);
        }
        else
        {
            Color c = material.GetColor("_BaseColor");
            c.a = 0.15f;
            material.SetColor("_BaseColor", c);
        }
    }

    public virtual void Unfocus()
    {
        if (emissionKeyword.isValid)
        {
            material.DisableKeyword(emissionKeyword);
        }
        else
        {
            Color c = material.GetColor("_BaseColor");
            c.a = 0.07f;
            material.SetColor("_BaseColor", c);
        }
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

    private void Awake()
    {
        material = GetHighlightMaterial();

        Shader shader = material.shader;

        emissionKeyword = shader.keywordSpace.FindKeyword("_EMISSION");
        if (emissionKeyword.isValid)
        {
            material.SetColor("_EmissionColor", new Color(0.1f, 0.1f, 0.1f));
        }

        trigger = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        trigger.enabled = true;
    }

    private void OnDisable()
    {
        trigger.enabled = false;
    }
}
