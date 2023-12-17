using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Gift : Interactable
{
    public string requiredItem;
    public Transform itemHolder;
    public IN_Gift nextGift;
    public IN_Item nextItem;
    public string noRequiredItemText = "You are missing something";
    public override void Interact()
    {
        base.Interact();
        if (GameManager.Instance.currentItem != requiredItem)
        {
            GameManager.Instance.changeInteractionText(noRequiredItemText);
            return;
        }
        GameManager.Instance.ChangeItem("");
        Destroy(itemHolder.GetChild(0).gameObject);
        nextGift.gameObject.SetActive(true);
        if (nextItem != null) nextItem.pickupable = true;
        Destroy(gameObject);
    }
}
