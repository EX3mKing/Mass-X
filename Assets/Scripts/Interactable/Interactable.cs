using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactText;
    public AudioClip interactSound;
    protected Outline outline;

    public virtual void Start()
    {
        outline = GetComponent<Outline>();
    }

    public virtual void OnLook()
    {
        outline.enabled = true;
    }

    public virtual void Interact()
    {
        print(interactText);
        if (interactSound != null) AudioManager.Instance.PlaySFX(interactSound);
        
    }

    public virtual void OnExit()
    {
        outline.enabled = false;
    }
}
