using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private bool paused;

    public void Pause()
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

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
            pauseMenu.SetActive(paused);
        }
    }

    public event Action OnPause;
    public event Action OnUnpause;
}
