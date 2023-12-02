using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected string interactText;
    protected Outline outline;
    
    public virtual void Start()
    {
        outline = GetComponent<Outline>();
    }

    public virtual void OnLook()
    {
        outline.enabled = true;
        GameManager.Instance.changeInteractionText(interactText);
    }

    public virtual void Interact()
    {
        print(interactText);
    }

    public virtual void OnExit()
    {
        outline.enabled = false;
    }
}
