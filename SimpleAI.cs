using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;



public class SimpleAI : MonoBehaviour
{
    public Transform EnemyEyes;
    public Transform Target;
    public CharacterController controller;
    public float Distance;
    public float lookAtDistance = 25.0f;
    public float chaseRange = 15.0f;
    public float attackRange = 2.0f;
    public float moveSpeed = 3.0f;
    public float Damping = 6.0f;
    public float attackRepeatTime = 1.0f;
    public float gravity = 20.0f;
    private float attackTime;
    private Vector3 MoveDirection = Vector3.zero;
    public float TheDamage = 10.0f;

    
    

    void Start()
    {
        attackTime = Time.time;
    }

    void Update()
    {
        if (RespawnMenu.PlayerIsDead == false)
        {
            Distance = Vector3.Distance(Target.position, transform.position);

            if (Distance < lookAtDistance)
            {
                lookAt();

            }
            if (Distance > lookAtDistance)
            {
                GetComponent<Renderer>().material.color = Color.blue;
                EnemyEyes.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (Distance < attackRange)
            {
                attack();
            }
            else if (Distance < chaseRange)
            {
                chase();

            }
        }
    }

    void lookAt()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        EnemyEyes.GetComponent<Renderer>().material.color = Color.yellow;
        Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }

    void chase()
    {
        GetComponent<Renderer>().material.color = Color.red;
        EnemyEyes.GetComponent<Renderer>().material.color = Color.red;
        MoveDirection = transform.forward;
        MoveDirection *= moveSpeed;
        MoveDirection.y -= gravity * Time.deltaTime;
        controller.Move(MoveDirection * Time.deltaTime);
    }

    void attack()
    {
      if (Time.time > attackTime)
        {
            Target.SendMessage("damagePlayer", TheDamage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("The Enemy has attacked!");
            attackTime = Time.time + attackRepeatTime;
        }  
    }

    void ApplyDamage()
    {
        chaseRange = 25;
        moveSpeed = 5;
        lookAtDistance = 30;
    }
}
