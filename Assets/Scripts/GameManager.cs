using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private static TextMeshProUGUI interactionText;
    public Interactable currentInteractable;
    public float reach;
    
    public float cameraSeneitivity = 120f;
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
        }
    }

    private void Start()
    {
        OnSceneLoaded();
    }

    private void OnSceneLoaded()
    {
        interactionText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
        interactionText.text = "";
        currentInteractable = null;
    }
    
    public void changeInteractionText(string text)
    {
        interactionText.text = text;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void LoadNextScene(float delay)
    {
        StartCoroutine(IELoadNextScene(delay));
    }
    
    private IEnumerator IELoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GetInteractable()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, reach))
        {
            
            if (!(hit.collider.transform.parent.CompareTag("Interactable") || hit.collider.CompareTag("Interactable")))
            {
                print("Obj isn't Interactable");
                if(currentInteractable != null) currentInteractable.OnExit();
                currentInteractable = null;
                interactionText.text = "";
                return;
            }
            
            Interactable interactable = hit.transform.parent.GetComponent<Interactable>();
            if (interactable == null) interactable = hit.transform.GetComponent<Interactable>();

            if (interactable == null)
            {
                print("f+ed up somewhere w Interactable obj (Interactable missing)");
                if (currentInteractable != null) currentInteractable.OnExit();
                currentInteractable = null;
                interactionText.text = "";
                return;
            }
            
            if (currentInteractable == null)
            {
                currentInteractable = interactable;
                currentInteractable.OnLook();
                return;
            }
            
            if (interactable != currentInteractable)
            {
                currentInteractable.OnExit();
                currentInteractable = interactable;
                currentInteractable.OnLook();
            }
        }
        else
        {
            if(currentInteractable != null) currentInteractable.OnExit();
            currentInteractable = null;
            interactionText.text = "";
        }
    }

    public void Interact()
    {
        if (currentInteractable != null) currentInteractable.Interact();
    }
}