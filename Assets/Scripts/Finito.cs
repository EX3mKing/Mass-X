using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finito : MonoBehaviour
{
    private bool wasEnabled = false;
    public float delayTime = 5f;

    private void FixedUpdate()
    {
        if (!wasEnabled)
        {
            wasEnabled = true;
            Invoke("Fin", delayTime);
        }
    }

    private void Fin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
