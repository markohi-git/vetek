
using UnityEngine;

using Photon.Pun;

public class Teleport : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("törmäys "+other.gameObject.tag);
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Teleportti_konelabraan")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            PhotonNetwork.LoadLevel("Konelabra");
           // SceneManager.LoadSceneAsync("Konelabra");

        }

        
    }
}