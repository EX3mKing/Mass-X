using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Cookie : Interactable
{
    //private Outline outline;

    public override void Start()
    {
        base.Start();
        interactText = "It's just a cookie.";
    }
    
    public override void OnLook()
    {
        base.OnLook();
    }

    public override void Interact()
    {
        base.Interact();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
