using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    // Public Variables
    float speed = 10.0F;
    [HideInInspector]
    public bool HasEnteredGame;

    // Use this for initialization
    void Start()
    {
        //Turn cursor off and lock.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Controls will be disabled upon entering the game
        if (HasEnteredGame != true)
        {
            // Setting variables
            float translation = Input.GetAxis("Vertical") * speed;
            float straffe = Input.GetAxis("Horizontal") * speed;

            // Moves character smoothly.
            translation *= Time.deltaTime;
            straffe *= Time.deltaTime;

            transform.Translate(straffe, 0, translation);
            // Disables the players collision so that the ball doesnt push the player back or collides with the player
            GetComponent<CapsuleCollider>().enabled = GetComponent<CapsuleCollider>().enabled;
            GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            // Disables the players collision so that the ball doesnt push the player back or collides with the player
            GetComponent<CapsuleCollider>().enabled = !GetComponent<CapsuleCollider>().enabled;
            GetComponent<Rigidbody>().useGravity = false;
        }
        // If escape is pressed turn cursor to default state. 
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}