using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLantern : MonoBehaviour
{
    public GameObject Lantern;
    public GameObject GroundLantern;
    private bool drawGUI = false;
    private bool Passou = false;

    void Update()
    {
        if (drawGUI == true)
        {
            StartCoroutine("ShowTip");
        }
    }
    void OnTriggerEnter (Collider theCollider)
    {
        if (theCollider.CompareTag("Player"))
        {
            
            GroundLantern.SetActive(false);
            if (Passou == false)
            {
                Lantern.SetActive(true);
                Lantern.GetComponent<Animation>().CrossFade("Swap02");
                drawGUI = true;
            }
            Passou = true;
            
        }
    }
    void OnGUI()
    {
        if (drawGUI == true)
        {
            GUI.Box(new Rect(Screen.width * 0.5f - 51, 200, 102, 22), "F for Flashlight");
        }
    }
    IEnumerator ShowTip()
    {
        if (drawGUI == true)
        {
            yield return new WaitForSeconds(3.0f);
            drawGUI = false;

        }
    }
}
