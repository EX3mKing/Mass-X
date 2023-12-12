using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Item : Interactable
{
    public string itemName;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;
    public GameObject itemHolder;
    public Collider itemCollider;

    public override void Interact()
    {
        transform.SetParent(itemHolder.transform);
        transform.localPosition = positionOffset;
        transform.localRotation = Quaternion.Euler(rotationOffset);
        itemCollider.enabled = false;
        base.Interact();
        GameManager.Instance.ChangeItem(itemName);
        OnExit();
    }
}
