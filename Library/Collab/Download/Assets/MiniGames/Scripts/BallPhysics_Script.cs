using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics_Script : MonoBehaviour
{
    // Sets Public Variables that control ball movement
    [HideInInspector]
    public Vector3 throwingBallForce = new Vector3(600, 50, 0);

    [HideInInspector]
    public bool HoldingBall, HoldingGun;

    private int Minigame;

    private GameObject BallPos;

    public SpawnController_Script SpawnRef;

    private void Start()
    {
        //Disable Gravity on begin
        GetComponent<Rigidbody>().useGravity = false;
        // Finds and Sets the script for Spawning and Destroying Self
        SpawnRef = GameObject.Find("_GameManager").GetComponent<SpawnController_Script>();
        // Sets the ball position 
        BallPos = SpawnRef.CameraRef.transform.GetChild(0).gameObject;
    }

    // Sets the gravity to false
    public void Update()
    {
        if (HoldingBall)
        {
            Minigame = SpawnRef.Minigame;
            CheckGame();
            if (Minigame != 2)
            {
                transform.position = BallPos.transform.position;
                if (Input.GetButtonDown("Throw"))
                {
                    ThrowBall();
                }
            }
            else
            {
                transform.position = this.transform.parent.GetChild(2).GetChild(1).transform.position;
                transform.rotation = this.transform.parent.GetChild(2).transform.rotation;
                if (Input.GetButtonDown("Fire"))
                {
                    ShootWeapon();
                }

            }
        }
    }

    // Function that throws the ball
    public void ThrowBall()
    {
        // enable gravity
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().AddRelativeForce(throwingBallForce);
        HoldingBall = false;
        if (this.transform.parent.GetChild(0).GetComponent<Cabinet_Script>().beginGame)
        {
            // Spawns the ball at the correct place
            StartCoroutine(SpawnRef.SpawnTime());
            StartCoroutine(SpawnRef.DestroySelf(5));
        }
    }

    public void ShootWeapon()
    {
        // Spawns the ball at the correct place
        StartCoroutine(SpawnRef.SpawnTime());
        // enable gravity
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().AddRelativeForce(throwingBallForce);
        HoldingBall = false;
        StartCoroutine(SpawnRef.DestroySelf(1));
    }

    public void CheckGame()
    {
        switch (Minigame)
        {
            case 1:
                throwingBallForce = new Vector3(0, 300, 400);
                break;

            case 2:
                throwingBallForce = new Vector3(0, 0, 1500);
                break;

            case 3:
                throwingBallForce = new Vector3(0, 50, 560);
                break;
        }
        // Sets the ball active depending on the mini game value.
        this.transform.GetChild(Minigame).gameObject.SetActive(true);
    }
}
