using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc2Exit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
