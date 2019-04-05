using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI_Script : MonoBehaviour
{

    public Image Crosshair;
    public Canvas PlayerUI;
    public GameObject CabinetRef;
    CharacterMovement PlayerRef;

    // Start is called before the first frame update
    void Start()
    {
        // This calls upon the player and gets refrence 
        PlayerRef = GetComponent<CharacterMovement>();
        // disables the crosshair to re-enable upon playing shooting dsucks minigame
        Crosshair.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRef.HasEnteredGame)
        {
            if(CabinetRef.GetComponent<Cabinet_Script>().SpawnRef.Minigame == 2)
            {
                Crosshair.enabled = true;
            }
        }
        else
        {
            Crosshair.enabled = false;
        }

        // Sets the tickets value to the ui
        //Tickets.text = (CabinetRef.transform.parent.GetChild(2).GetComponent<MoveAI_Script>().score / 2).ToString();
    }
}
