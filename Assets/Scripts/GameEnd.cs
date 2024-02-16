using System.Collections;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Library[] libraries;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private GameObject gameEndScreen;
    [SerializeField] private AudioSource gameEndAudio;

    private bool gameEnded;

    private void Start()
    {
        foreach (Library lib in libraries)
        {
            lib.OnComplete += HandleLibraryComplete;
        }
    }

    private void HandleLibraryComplete()
    {
        foreach (Library lib in libraries)
        {
            if (!lib.IsComplete())
            {
                return;
            }
        }

        StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);

        pauseManager.Pause();
        pauseManager.enabled = false;

        gameEndAudio.Play();

        gameEndScreen.SetActive(true);

        gameEnded = true;
    }

    private void Update()
    {
        if (gameEnded && Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }
    }
}
