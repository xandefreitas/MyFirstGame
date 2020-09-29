using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFunction : MonoBehaviour
{
    public Transform theDoor;
    private bool drawGUI = false;
    private bool doorIsClosed = true;

    void Update()
    {
        if (drawGUI == true && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("ChangeDoorState");
        }
    }

    void OnTriggerEnter (Collider theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {

            drawGUI = true;
        }
    }
    void OnTriggerExit (Collider theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {
            drawGUI = false;
        }
    }
    void OnGUI()
    {
        if (drawGUI == true)
        {
            GUI.Box(new Rect(Screen.width * 0.5f - 51, 200, 102, 22), "Press E to open");
        }
    }
    IEnumerator ChangeDoorState()
    {
        if (doorIsClosed == true)
        {
            theDoor.GetComponent<Animation>().CrossFade("Open");
            //theDoor.audio.PlayOneShot();
            doorIsClosed = false;
            yield return new WaitForSeconds(3.0f);
            theDoor.GetComponent<Animation>().CrossFade("Close");
            //theDoor.audio.PlayOneShot();
            doorIsClosed = true;
        }
    }
}

