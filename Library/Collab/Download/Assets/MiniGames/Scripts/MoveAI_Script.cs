using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI_Script : MonoBehaviour {

    // Ai movement side to side
    [HideInInspector]
    public float speed = 0.3f, MovementSpace, MinValue = 100, MaxValue = 1000, ThrowPower;
    [HideInInspector]
    public int score;

    // Refrences to Other scripts and objects
    private CharacterMovement PlayerRef;
    private Cabinet_Script CabinetRef;
    [HideInInspector]
    public GameObject BallRef, PointA, PointB, SpawnRef;

    // Variables for the 
    private Vector3 SelfLocation;

    // Use this for initialization
    void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        CabinetRef = this.transform.parent.GetChild(0).gameObject.GetComponent<Cabinet_Script>();
        SpawnRef = GameObject.Find("_GameManager");
        PointA = this.transform.parent.GetChild(3).gameObject;
        PointB = this.transform.parent.GetChild(4).gameObject;
        // Sets the location to the variable for refrence purpose
        SelfLocation = transform.localPosition;
        // sets new location on the same x value of the basketball cabinet
        SelfLocation.x = CabinetRef.CabLocation.x;
        // sets the new location to the vector3 value.
        transform.localPosition = SelfLocation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if game has started
        if (PlayerRef.HasEnteredGame && CabinetRef.beginGame)
        {
            // Calls upon this function
            Movement();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Actor"))
        {
            score = score + 2;
        }
    }

    public void Movement()
    {
        if (SpawnRef.GetComponent<SpawnController_Script>().Minigame != 3)
        {
            float pingPong = Mathf.PingPong(Time.time * speed, 1);
            transform.localPosition = Vector3.Lerp(PointA.transform.localPosition, PointB.transform.localPosition, pingPong);
            if (score > 10)
            {
                speed = 0.4f;
            }
            else if (score > 20)
            {
                speed = 0.5f;
            }
        }
        else
        {
            if (Input.GetButtonDown("Throw") == false)
            {
                Mathf.Lerp(MinValue, MaxValue, ThrowPower);

                ThrowPower += 0.5f * Time.deltaTime;

                if (ThrowPower > 1000)
                {
                    float temp = MaxValue;
                    MaxValue = MinValue;
                    MaxValue = temp;
                    ThrowPower = 0.0f;
                }

                print("this is the power bar level = " + ThrowPower);
            } 
        }
    }

    public void SetGameAsset()
    {
        switch (SpawnRef.GetComponent<SpawnController_Script>().Minigame)
        {
            case 1:
                // this will set the pingpong motion space point
                
                break;
            case 2:
                this.transform.parent.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:

                break;
        }
    }
}
