using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
    }
}
