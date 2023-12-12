using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Gift : Interactable
{
    public string requiredItem;
    public Transform itemHolder;
    public IN_Gift nextGift;
    public IN_Item nextItem;
    public override void Interact()
    {
        base.Interact();
        if (GameManager.Instance.currentItem != requiredItem) return;
        GameManager.Instance.ChangeItem("");
        Destroy(itemHolder.GetChild(0).gameObject);
        nextGift.gameObject.SetActive(true);
        nextItem.enabled = true;
        Destroy(gameObject);
    }
}
