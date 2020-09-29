using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 200.0f;

    void Update (){
        if (Health <= 0){
            Dead();
        }
    }

    void ApplyDamage(int TheDamage)
    {
        Health -= TheDamage;
    }

    void Dead (){
        Destroy (gameObject);
    }
}
