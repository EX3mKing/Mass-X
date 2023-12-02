using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePlayerCamera : MonoBehaviour
{
    private float sens;

    float xRot = 0f;
    float yRot = 0f;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        sens = GameManager.Instance.cameraSeneitivity;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        
        xRot -= mouseY;
        yRot += mouseX;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.Interact();
        }
    }

    private void FixedUpdate()
    {
        GameManager.Instance.GetInteractable();
    }
}
