using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Tree : Interactable
{
    //private Outline outline;
    public ParticleSystem snowflakes;
    public float snowStrength = 140f;
    
    public List<GameObject> lights = new List<GameObject>();
    public float lightOnSpeed = 0.1f;
    public float lightOnVariation = 0.03f;
    public float lightOffSpeed = 1f;
    public float lightOffVariation = 1.5f;
    
    private bool hasBeenInteracted = false;

    public override void Start()
    {
        base.Start();
        interactText = "Press E";
        LightsOnOff();
    }
    
    public override void OnLook()
    {
        base.OnLook();
    }

    public override void Interact()
    {
        if (hasBeenInteracted) return;
        base.Interact();
        snowflakes.Play();
        GameManager.Instance.LoadNextScene(5f);
        hasBeenInteracted = true;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void LightsOnOff()
    {
        if (lights.Count == 0) return;
        
        foreach (var VARIABLE in lights)
        {
            VARIABLE.SetActive(!VARIABLE.activeSelf);
        }
        
        if (!lights[0].activeSelf)
        {
            Invoke("LightsOnOff", lightOnSpeed + Random.Range(-lightOnVariation, lightOnVariation));
        }
        else
        {
            Invoke("LightsOnOff", lightOffSpeed + Random.Range(-lightOffVariation, lightOffVariation));
        }
    }
}
