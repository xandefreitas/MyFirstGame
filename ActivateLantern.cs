using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLantern : MonoBehaviour
{
    public GameObject Axe;
    public GameObject GroundAxe;
    private bool drawGUI = false;
    private bool Passou = false;
    public GameObject WeaponChange;

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
            
            GroundAxe.SetActive(false);
            if (Passou == false)
            {
                Axe.SetActive(true);
                Axe.GetComponent<Animation>().CrossFade("Swap02");
                WeaponChange.SetActive(true);
                drawGUI = true;
            }
            Passou = true;
            
        }
    }
    void OnGUI()
    {
        if (drawGUI == true)
        {
            GUI.Box(new Rect(Screen.width * 0.5f - 51, 200, 204, 22), " Press Q for Weapon Change");
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
