using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    private CharacterController characterController;

    [Header("Footsteps")]
    [SerializeField] AudioSource footstepSource;
    [SerializeField] AudioClip[] footstepSounds;
    [SerializeField] float pitchMinRange = -0.50f;
    [SerializeField] float pitchMaxRange = 1.50f;
    [SerializeField] float secondsBetweenFootsteps = 2f;
    private bool couroutineIsPlaying;

    [Header("Interactions")]
    [SerializeField] AudioSource interactionSource;
    [SerializeField] AudioClip BookPickUpSound;
    [SerializeField] AudioClip BookPlaceSound;
    [SerializeField] AudioClip BookDropSound;

    void Awake()
    {
        couroutineIsPlaying = false;
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (couroutineIsPlaying == false && Input.GetAxis("Horizontal") != 0 && characterController.isGrounded ||
            couroutineIsPlaying == false && Input.GetAxis("Vertical") != 0 && characterController.isGrounded)
        {
            StartCoroutine(PlayFootstepSound());
        }
        else if (couroutineIsPlaying == true && (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)) 
        {
            StopAllCoroutines();
            couroutineIsPlaying = false;
        }
    }

    private IEnumerator PlayFootstepSound()
    {

        couroutineIsPlaying = true;
        while (couroutineIsPlaying)
        {
            
            footstepSource.pitch = Random.Range(pitchMinRange, pitchMaxRange);
            footstepSource.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
            yield return new WaitForSeconds(secondsBetweenFootsteps);
            print("Currently Playing: Next Footstep");


        }

    }

    public void PlayBookDropSound() 
    {
        interactionSource.PlayOneShot(BookDropSound);
    }

    public void PlayBookPickUpSound()
    {
        interactionSource.PlayOneShot(BookPickUpSound);
    }

    public void PlayBookPlaceSound()
    {
        interactionSource.PlayOneShot(BookPlaceSound);
    }
}
