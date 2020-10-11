using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class RespawnMenu : MonoBehaviour
{

    public mouselook lookAround;
    public CharacterController charController;
    public static bool PlayerIsDead = false;
    public Transform respawnTransform;

    void Start()
    {
        lookAround = (mouselook)GameObject.Find("Main Camera").GetComponent(typeof(mouselook));
        charController = (CharacterController)gameObject.GetComponent(typeof(CharacterController));
    }

    void Update()
    {
        if (PlayerIsDead)
        {
            lookAround.enabled = false;
            charController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (PlayerIsDead == false)
        {
            lookAround.enabled = true;
            charController.enabled = true;
        }
    }

    void OnGUI()
    {
        if (PlayerIsDead)
        {
            if (GUI.Button(new Rect(Screen.width/2-50, 200-20, 100, 40), "Respawn!"))
            {
                RespawnPlayer();
            }
            if (GUI.Button(new Rect(Screen.width/2-50, 230, 100, 40), "Menu"))
            {
                UnityEngine.Debug.Log("Returning to menu");
            }
        }
    }
    void RespawnPlayer()
    {
        UnityEngine.Debug.Log("Player Has Respawned!");
        transform.position = respawnTransform.position;
        transform.rotation = respawnTransform.rotation;
        PlayerIsDead = false;
        lookAround.enabled = true;
        charController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SendMessage("RespawnStatus");

    }
}
