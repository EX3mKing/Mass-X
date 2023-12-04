using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Switch : Interactable
{
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
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
