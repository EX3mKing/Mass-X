using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float sens;
    public Transform orientation;
    public GameObject holder;
    
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
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
        
        transform.position = holder.transform.position;
        orientation.rotation = Quaternion.Euler(0f, yRot, 0f);
    }
}
