using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Door : Interactable
{
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private Vector3 openRotation;
    [SerializeField] private Vector3 closedPosition;
    [SerializeField] private Vector3 closedRotation;
    
    [SerializeField] private bool isOpen = false;

    public override void Interact()
    {
        base.Interact();
        isOpen = !isOpen;
        if (isOpen)
        {
            transform.localPosition = openPosition;
            transform.localRotation = Quaternion.Euler(openRotation);
        }
        else
        {
            transform.localPosition = closedPosition;
            transform.localRotation = Quaternion.Euler(closedRotation);
        }
    }
}
