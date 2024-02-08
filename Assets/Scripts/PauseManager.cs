using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool paused;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            paused = !paused;

            if (paused)
            {
                Cursor.lockState = CursorLockMode.None;
                pauseMenu.SetActive(true);
                OnPause?.Invoke();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                pauseMenu.SetActive(false);
                OnUnpause?.Invoke();
            }
        }
    }

    public event Action OnPause;
    public event Action OnUnpause;
}
