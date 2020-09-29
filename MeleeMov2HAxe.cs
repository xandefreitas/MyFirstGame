using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMov2HAxe : MonoBehaviour
{
    public int TheDamage = 75;
    public float Distance;
    public float MaxDistance = 4f;
    public Transform TheAxe;
    public Transform TheSystem;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TheAxe.GetComponent<Animation>().CrossFade("AxeAttack01");
        }
        if (TheAxe.GetComponent<Animation>().isPlaying == false)
        {
            TheAxe.GetComponent<Animation>().CrossFade("AxeIdle");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            TheAxe.GetComponent<Animation>().CrossFade("AxeSprint");
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            TheAxe.GetComponent<Animation>().CrossFade("AxeIdle");
        }
    }
    void AttackDamage()
    {

        RaycastHit hit;

        if (Physics.Raycast(TheSystem.transform.position, TheSystem.transform.TransformDirection(Vector3.forward), out hit))
        {
            Distance = hit.distance;
            if (Distance < MaxDistance)
            {
                hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
