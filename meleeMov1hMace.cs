using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeMov1hMace : MonoBehaviour
{
    public int TheDamage = 50;
    public float Distance;
    public float MaxDistance = 3f;
    public Transform TheHammer;
    public Transform TheSystem;
    private bool Standing = true;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TheHammer.GetComponent<Animation>().CrossFade("HammerAttack01");
        }
        if(TheHammer.GetComponent<Animation>().isPlaying == false)
        {
            TheHammer.GetComponent<Animation>().CrossFade("HammerIdle");
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Standing = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)){
            Standing = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Standing)
        {
            TheHammer.GetComponent<Animation>().CrossFade("HammerSprint");
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            TheHammer.GetComponent<Animation>().CrossFade("HammerIdle");
        }
    }
    void AttackDamage()
    {
        
        RaycastHit hit;

        if (Physics.Raycast (TheSystem.transform.position, TheSystem.transform.TransformDirection(Vector3.forward), out hit))
        {
            Distance = hit.distance;
            if (Distance < MaxDistance)
            {
                hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

}
