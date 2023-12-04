using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IN_Stairs : Interactable
{
    public Transform spawnInfo;
    public GameObject player;
    public GameObject camera;
    public GameObject orientation;
    
    public override void Start()
    {
        
    }
    
    public override void OnLook()
    {
        
    }

    public override void Interact()
    {
        base.Interact();
        player.transform.position = spawnInfo.position;
        player.transform.rotation = spawnInfo.rotation;
        camera.transform.rotation = spawnInfo.rotation;
        orientation.transform.rotation = spawnInfo.rotation;
    }

    public override void OnExit()
    {
        
    }
}
