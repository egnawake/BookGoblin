using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool paused;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;

            if (paused)
            {
                Cursor.lockState = CursorLockMode.None;
                OnPause?.Invoke();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                OnUnpause?.Invoke();
            }
        }
    }

    public event Action OnPause;
    public event Action OnUnpause;
}
