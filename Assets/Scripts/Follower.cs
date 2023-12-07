using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public GameObject target;
    public bool followCamera = false;
    private void Update()
    {
        if (followCamera) transform.position = Camera.main.transform.position;
        else transform.position = target.transform.position;
    }
}
