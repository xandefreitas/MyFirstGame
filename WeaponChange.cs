using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject Weapon01;
    public GameObject Weapon02;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WeaponSwap();
        }
        if (Weapon02.activeSelf == true)
        {
            Weapon01.SetActive(false);
        }
    }

    void WeaponSwap()
    {
        if (Weapon01.activeSelf == true)
        {
            Weapon02.GetComponent<Animation>().CrossFade("Swap02");
            Weapon01.SetActive(false);
            Weapon02.SetActive(true);
            
        }
        else
        {
            Weapon01.GetComponent<Animation>().CrossFade("Swap01");
            Weapon01.SetActive(true);
            Weapon02.SetActive(false);
            
        }
    }

}
