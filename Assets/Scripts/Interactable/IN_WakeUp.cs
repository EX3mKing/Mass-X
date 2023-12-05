using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_WakeUp : Interactable
{
    [SerializeField] private GameObject introCamera;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private Canvas uiCanvas;
    
    public override void OnLook()
    {
        GameManager.Instance.changeInteractionText(interactText);
    }

    public override void Interact()
    {
        base.Interact();
        introCamera.SetActive(false);
        mainCamera.SetActive(true);
        player.SetActive(true);
        uiCanvas.worldCamera = mainCamera.GetComponent<Camera>();
        GameManager.Instance.changeInteractionText("");
        Destroy(gameObject);
    }
    
    public override void OnExit()
    {
        GameManager.Instance.changeInteractionText("");
    }
}
