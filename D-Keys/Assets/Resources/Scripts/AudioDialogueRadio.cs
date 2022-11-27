using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;

///--------------------------------
///   Author: Victor Alvarez, Ph.D.
///   University of Oviedo, Spain
///--------------------------------

public class AudioDialogueRadio : MonoBehaviour
{
    public AudioSource audioHello, audioGoodbye;
    public GameObject madHatterCat;
    private Boolean audioHelloWasPlayed = false;
    private Animator animator;
    private Boolean aux= true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.Log("missing animator component!");

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player") && !audioHelloWasPlayed && aux)
        {
            Debug.Log("I've found the mad hatter!");
            if (audioGoodbye.isPlaying)
                audioGoodbye.Stop();
            animator.SetTrigger("FirstGreeting");
            audioHello.Play();
            audioHelloWasPlayed = true;
            aux=false;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player") && audioHelloWasPlayed)
        {
            StartCoroutine(SayGoodBye());
        }
    }

    IEnumerator SayGoodBye()
    {
        Debug.Log("Good-bye mad hatter");
        yield return new WaitUntil(()=>audioHello.isPlaying == false);
    }   

}
