using UnityEngine;

public abstract class Pauseable : MonoBehaviour
{
    private PauseManager pauseManager;

    public abstract void NotifyPaused();
    public abstract void NotifyUnpaused();

    protected virtual void Start()
    {
        pauseManager = GameObject.FindWithTag("PauseManager")?
            .GetComponent<PauseManager>();

        if (pauseManager != null)
        {
            pauseManager.OnPause += NotifyPaused;
            pauseManager.OnUnpause += NotifyUnpaused;
        }
    }
}
