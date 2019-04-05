using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabinet_Script : MonoBehaviour {

    //Public Variables
    public bool beginGame, PlayerOverlapped, NeedsReload;
    [HideInInspector]
    public int DuckID;

    // Refrences to other 
    [HideInInspector]
    public GameObject TargetPoint, GunRef, CameraRef, PlayerRef, EnterGameUI, GameUI;
    [HideInInspector]
    public SpawnController_Script SpawnRef;

    // Vector Refrences for Scale and Position 
    [HideInInspector]
    public Vector3 CabLocation, ScaleCab;

    // Use this for initialization
    void Start()
    {
        // sets the cabinets location for refrence
        CabLocation = transform.localPosition;
        // Setst he cabinets scale for future refrence
        ScaleCab = transform.localScale;
        //Sets gameoobject refrences
        PlayerRef = GameObject.Find("Player_PF");
        CameraRef = PlayerRef.transform.GetChild(0).gameObject;
        SpawnRef = GameObject.Find("_GameManager").GetComponent<SpawnController_Script>();
        EnterGameUI = GameObject.Find("GameInteraction_UI").transform.GetChild(0).gameObject;
        GameUI = transform.parent.GetChild(5).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerOverlapped && !PlayerRef.GetComponent<CharacterMovement>().HasEnteredGame && !beginGame)
        {
            if (Input.GetKeyDown("e"))
            {
                // Sets the player position relative to the basketball cabinet
                PlayerRef.transform.position = TargetPoint.transform.position;
                // Makes the player look at the game
                PlayerRef.transform.rotation = this.transform.parent.transform.rotation;
                CameraRef.transform.LookAt(this.transform.parent);
                // Sets the game to start
                PlayerRef.GetComponent<CharacterMovement>().HasEnteredGame = true;
                beginGame = true;
                // Sets the mini game number before spawning ball
                SetMiniGameNumber();
                GameUI.GetComponent<ScoreTimer_Script>().SetTimerValues();
                // Removes the GUI and starts the game
                EnterGameUI.SetActive(false);
                
            }
        }
        else if(beginGame)
        {
            if (SpawnRef.Minigame == 2)
            {
                // Get the refrence from the child actor
                GunRef = this.transform.parent.GetChild(2).gameObject;
                // Set the gun from the table to the camera position plus some values
                GunRef.transform.position = CameraRef.transform.GetChild(1).transform.position;
                GunRef.transform.rotation = CameraRef.transform.GetChild(1).transform.rotation;
                if (Input.GetButtonDown("Fire") && NeedsReload == false)
                {
                    ShootWeapon();
                }
                else if (Input.GetButtonDown("Reload"))
                {
                    NeedsReload = false;
                }
            } 
        }
    }

    // When player overlapps ui appears, ball overlapps then destroy it.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !beginGame && !PlayerRef.GetComponent<CharacterMovement>().HasEnteredGame)
        {
            EnterGameUI.SetActive(true);
            PlayerOverlapped = true;
        }
        if(other.CompareTag("Actor"))
        {
            StartCoroutine(SpawnRef.DestroySelf(0));
        }
    }

    // Removes the GUI from the players screen
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnterGameUI.SetActive(false);
            PlayerOverlapped = false;
        }
    }

    // Set the value of minigame relative to the name of the minigame
    void SetMiniGameNumber()
    {
        switch (this.transform.name)
        {
            case "Basketball_MG":
                SpawnRef.Minigame = 1;
                break;

            case "ShootingDucks_MG":
                SpawnRef.Minigame = 2;
                break;

            case "Skeeball_MG":
                SpawnRef.Minigame = 3;
                break;
        }
        SpawnRef.CabinetRef = this.transform.gameObject;
        StartCoroutine(SpawnRef.SpawnTime());
    }


    public void ShootWeapon()
    {
        // Spawns the ball at the correct place
        StartCoroutine(SpawnRef.SpawnTime());
        // set the ray location from the center of the camera to the location of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // this gets the values that come with the raycast 
        RaycastHit hit;

        SpawnRef.DuckClone = GameObject.FindGameObjectsWithTag("Duck");
        // check if the ray cast has collided with anything
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Duck"))
            {
                // this rotates the game object that the collider belongs to
                hit.collider.transform.localRotation = Quaternion.Euler(-90, 0, 0);
                // 
                hit.collider.gameObject.GetComponentInParent<MoveAI_Script>().score = hit.collider.gameObject.GetComponentInParent<MoveAI_Script>().score + 2;
                StartCoroutine(SpawnRef.ResetValuesGameAI());
            }
        }
        //
        NeedsReload = true;
        // Destroy the object once all this is done
        StartCoroutine(SpawnRef.DestroySelf(3));
    }
}