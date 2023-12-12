using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Item : Interactable
{
    public string itemName;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public GameObject itemHolder;
    public List<Collider> itemColliders = new List<Collider>();
    public bool pickupable = false;
    public string notPickupableText = "Nahh";

    public override void Interact()
    {
        base.Interact();
        if (!pickupable)
        {
            GameManager.Instance.changeInteractionText(notPickupableText);
            return;
        }
        
        transform.SetParent(itemHolder.transform);
        transform.localPosition = positionOffset;
        transform.localRotation = Quaternion.Euler(rotationOffset);
        foreach (var VARIABLE in itemColliders) VARIABLE.enabled = false;
        GameManager.Instance.ChangeItem(itemName);
        OnExit();
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
