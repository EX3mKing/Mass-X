using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactText;
    public AudioClip interactSound;
    protected Outline outline;
    public bool isInteractable = true;
    public bool isLookable = true;

    public virtual void Start()
    {
        outline = GetComponent<Outline>();
    }

    public virtual void OnLook()
    {
        if (!isLookable) return;
        outline.enabled = true;
    }

    public virtual void Interact()
    {
        if (!isInteractable) return;
        print(interactText);
        if (interactSound != null) AudioManager.Instance.PlaySFX(interactSound);
        
    }

    public virtual void OnExit()
    {
        outline.enabled = false;
    }
}
