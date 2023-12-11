using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Switch : Interactable
{
    [Header("DESTRUCTION")]
    public bool destroy;
    public bool destructionMeansExit = false;
    public List<Component> destructibleComponents = new List<Component>();
    public List<GameObject> destructibleObjects = new List<GameObject>();
    [Header("SWITCH")]
    [SerializeField] private List<GameObject> objects = new List<GameObject>();
    public override void Start()
    {
        base.Start();
    }
    
    public override void OnLook()
    {
        base.OnLook();
    }

    public override void Interact()
    {
        base.Interact();
        
        foreach (var VARIABLE in objects)
        {
            VARIABLE.SetActive(!VARIABLE.activeSelf);
        }

        if(!destroy) return;
        if (destructionMeansExit) OnExit();
        foreach (var VARIABLE in destructibleObjects) Destroy(VARIABLE);
        foreach (var VARIABLE in destructibleComponents) Destroy(VARIABLE);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
