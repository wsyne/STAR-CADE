using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController_Script : MonoBehaviour {

    [HideInInspector]
    public GameObject Ball, CabinetRef, CameraRef, AIRef;

    // Set Array variable this holds the number of ball instances that are spawned
    [HideInInspector]
    public GameObject[] BallClone, DuckClone;
    
    // this holds the position of ball for where to spawn
    private Vector3 BallSpawnPos;

    [HideInInspector]
    public int clones, AI_clone, Minigame;
   

    private void Start()
    {
        CameraRef = GameObject.Find("Camera_PF");

    }

    // Update is called once per frame
    public IEnumerator DestroySelf(float Time)
    {
        // this will delay the following function for the time specified in the waitforseconds area
        yield return new WaitForSeconds(Time);
        // before destroying an object gather all the objects of the type actor(ball instance)
        BallClone = GameObject.FindGameObjectsWithTag("Actor");
        // this destroys the first instance that was spawned in the world
        DestroyImmediate(BallClone[0]);
    }

    // Spawns a new ball in the same place after a few seconds.
    public IEnumerator SpawnTime()
    {
        // The switch statement handles setting the position of the ball corresponding to their minigame
        switch (Minigame)
        {
            case 1:
                // Delays the spawning of the ball
                yield return new WaitForSeconds(1);
                // Set position of the ball to the position of the cameras child (this would be a target point)
                BallSpawnPos = CameraRef.transform.GetChild(0).transform.position;
                break;

            case 2:
                // Delays the spawning of the ball
                yield return new WaitForSeconds(0);
                // Set position of the ball relative to the muzzle of the gun refrence
                BallSpawnPos = CabinetRef.GetComponent<Cabinet_Script>().GunRef.transform.GetChild(1).transform.position;
                break;

            case 3:
                // Delays the spawning of the ball
                yield return new WaitForSeconds(2);
                // Set position of the ball to the position of the cameras child (this would be a target point)
                BallSpawnPos = CameraRef.transform.GetChild(0).transform.position;
                break;
        }
        BallClone = new GameObject[clones + 1];
        // Creates a ball in the same spawn they started with
        BallClone[clones] = Instantiate(Ball, BallSpawnPos, CameraRef.transform.rotation);
        BallClone[clones].transform.GetChild(Minigame).gameObject.SetActive(true);
        // sets the parent transform
        BallClone[clones].transform.parent = CabinetRef.transform.parent;
        // sets the ball that needs to be activated
        BallClone[clones].GetComponent<BallPhysics_Script>().HoldingBall = true;
    }

    public IEnumerator ResetValuesGameAI()
    {
        // this loop should reset the rotation of the  ducks
        for (var i = 0; i < DuckClone.Length; i++)
        {
            // this section checks if the duck has been rotated below 0 degree's in this case it would -90
            if (DuckClone[i].transform.localRotation.x < 0)
            {
                // this delays the following function
                yield return new WaitForSeconds(5);
                // rotates the duck back to its original values
                DuckClone[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}