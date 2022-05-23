using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class MouseLook : MonoBehaviour
{   
    public float mouseSensitivity =100f;
    public Transform playerBody;
    public PhotonView photonView;
    float xRotation=0f;
    //[SerializeField] private Camera m_Camera;
    
    // Start is called before the first frame update
    void Start()
    {
      
       /* if (!photonView.IsMine)
        {
            Destroy(m_Camera);
        }*/
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (photonView.IsMine)
        {
            float mouseX=Input.GetAxis("Mouse X") * mouseSensitivity*Time.deltaTime;
            float mouseY=Input.GetAxis("Mouse Y") * mouseSensitivity*Time.deltaTime;

            xRotation-=mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation=Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
