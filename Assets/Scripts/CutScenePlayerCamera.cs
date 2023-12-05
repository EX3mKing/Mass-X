using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePlayerCamera : MonoBehaviour
{
    private float sens;

    float xRot = 0f;
    float yRot = 0f;

    public float minXRot = -90;
    public float maxXRot = 90;
    public float minYRot = -15;
    public float maxYRot = 15;
    

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
        
        if (maxXRot != 0 || minXRot != 0) xRot = Mathf.Clamp(xRot, minXRot, maxXRot);
        if (minYRot != 0 || maxYRot != 0) yRot = Mathf.Clamp(yRot, minYRot, maxYRot);
        
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
