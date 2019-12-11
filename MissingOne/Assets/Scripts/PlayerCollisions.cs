using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    // Logic for Shack Door
    private bool doorIsOpen = false;
    private float doorTimer = 0.0f;
    public float doorOpenTime = 3.0f;


    // Foor sounds
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;
    private new AudioSource audio;

    // Battery
    public AudioClip batteryCollectSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();          // its epic gamer time ayyyyy lmao
    }

    // Update is called once per frame
    void Update()
    {
        // Timer that automatically shuts door once it's open
        if(doorIsOpen)
        {
            doorTimer += Time.deltaTime;
        }
        if(doorTimer > doorOpenTime)
        {
            ShutDoor();
            doorTimer = 0.0f;
        }
           
    }

    // Collision detection
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "shackDoor" && !doorIsOpen && BatteryCollect.charge >= 4)
        {
            OpenDoor();
            BatteryCollect.chargeUI.enabled = false;

        }
        else if (hit.gameObject.tag == "shackDoor" && !doorIsOpen && BatteryCollect.charge < 4)
        {
            BatteryCollect.chargeUI.enabled = true;


        }
    }

    // Battery Collision
    private void OnTriggerEnter(Collider coll)
    {
        BatteryCollect.charge++;
        audio.PlayOneShot(batteryCollectSound);
        Destroy(coll.gameObject);
    }


    void OpenDoor()
    {
        // Play audio ding dong
        audio.PlayOneShot(doorOpenSound);
        // Set doorIsOpen to true wallawallabingbang
        doorIsOpen = true;
        // Find the GameObject that has animation ding dong
        GameObject myShack = GameObject.Find("Shack");
        // Play animation
        myShack.GetComponent<Animation>().Play("doorOpen");
    }


    void ShutDoor()
    {
        audio.PlayOneShot(doorOpenSound);
        doorIsOpen = true;
        GameObject myShack = GameObject.Find("Shack");
        myShack.GetComponent<Animation>().Play("doorShut");
    }


}
