
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity =-9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight= 3f;
    //public PhotonView photonView;
    PhotonView photonView;
    [SerializeField] private Camera m_Camera;


    bool isGrounded;
    //[SerializeField] private Camera m_Camera;

    Vector3 velocity;
   
    // Start is called before the first frame update
    void Start()
    {
       photonView = GetComponent<PhotonView>();
       if (!photonView.IsMine)
        {
            Destroy(m_Camera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

            if (isGrounded && velocity.y<0)
            {
                velocity.y = -2f;
            }
            float x =Input.GetAxis("Horizontal");
            float z =Input.GetAxis("Vertical");

            Vector3 move =transform.right*x+ transform.forward*z;
            controller.Move(move*speed*Time.deltaTime);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y=Mathf.Sqrt(jumpHeight*-2f*gravity);
            }

            velocity.y+=gravity*Time.deltaTime;
            controller.Move(velocity*Time.deltaTime);
        } 

    }
}
