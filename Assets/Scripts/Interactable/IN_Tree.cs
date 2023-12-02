using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Tree : Interactable
{
    //private Outline outline;
    public ParticleSystem snowflakes;
    public float snowStrength = 140f;
    
    private bool hasBeenInteracted = false;

    public override void Start()
    {
        base.Start();
        interactText = "Press E";
    }
    
    public override void OnLook()
    {
        base.OnLook();
    }

    public override void Interact()
    {
        if (hasBeenInteracted) return;
        base.Interact();
        snowflakes.Play();
        GameManager.Instance.LoadNextScene(5f);
        hasBeenInteracted = true;
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
