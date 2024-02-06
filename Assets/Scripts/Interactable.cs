using UnityEngine;
using UnityEngine.Rendering;

public class Interactable : MonoBehaviour
{
    private Material material;
    private LocalKeyword emissionKeyword;

    public void Focus()
    {
        material.EnableKeyword(emissionKeyword);
    }

    public void Unfocus()
    {
        material.DisableKeyword(emissionKeyword);
    }

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        emissionKeyword = new LocalKeyword(material.shader, "_EMISSION");

        material.SetColor("_EmissionColor", new Color(0.1f, 0.1f, 0.1f));
    }
}
