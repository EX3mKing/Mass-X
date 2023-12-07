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
        ReloadStuff();
    }

    public void ReloadStuff()
    {
        interactionText = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
        interactionText.text = "";
        currentInteractable = null;       
    }

    #region  Scene Management
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ReloadStuff();
    }
    
    public void LoadNextScene(float delay)
    {
        StartCoroutine(IELoadNextScene(delay));
    }
    
    private IEnumerator IELoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ReloadStuff();
    }

    public void Quit()
    {
        Debug.Log($"exited");
        Application.Quit();
    }
    
    #endregion
    
    public void changeInteractionText(string text)
    {
        interactionText.text = text;
    }
    
    public void GetInteractable()
    {
        if (Physics.Raycast(Camera.main.transform.position, 
                Camera.main.transform.forward, out RaycastHit hit, reach)) // something hit
        {
            // not interactable
            // remove info
            if (!(hit.collider.transform.parent && hit.collider.transform.parent.CompareTag("Interactable")) 
                && !hit.collider.CompareTag("Interactable"))
            {
                print("Obj isn't Interactable");
                if(currentInteractable != null) currentInteractable.OnExit();
                currentInteractable = null;
                interactionText.text = "";
                return;
            }

            Interactable interactable = hit.transform.parent.GetComponent<Interactable>();
            if (interactable == null) interactable = hit.transform.GetComponent<Interactable>();
            
            // not interactable
            // remove info
            if (interactable == null)
            {
                print("f+ed up somewhere w Interactable obj (Interactable missing)");
                if (currentInteractable != null) currentInteractable.OnExit();
                currentInteractable = null;
                interactionText.text = "";
                return;
            }
            
            // new interactable
            // add info
            if (currentInteractable == null)
            {
                currentInteractable = interactable;
                interactionText.text = currentInteractable.interactText;
                currentInteractable.OnLook();
                return;
            }
            
            // remove old info (old interactable)
            // add new info (new interactable)
            if (interactable != currentInteractable)
            {
                currentInteractable.OnExit();
                currentInteractable = interactable;
                interactionText.text = currentInteractable.interactText;
                currentInteractable.OnLook();
            }
        }
        else // nothing hit
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
