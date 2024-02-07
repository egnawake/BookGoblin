using UnityEngine;

public class PlayerPause : Pauseable
{
    private PlayerController controller;
    private PlayerInteractor interactor;
    private CameraPitch cameraPitch;

    public override void NotifyPaused()
    {
        controller.enabled = false;
        interactor.enabled = false;
        cameraPitch.enabled = false;
    }

    public override void NotifyUnpaused()
    {
        controller.enabled = true;
        interactor.enabled = true;
        cameraPitch.enabled = true;
    }

    protected override void Start()
    {
        base.Start();

        controller = GetComponentInChildren<PlayerController>();
        interactor = GetComponentInChildren<PlayerInteractor>();
        cameraPitch = GetComponentInChildren<CameraPitch>();
    }
}
