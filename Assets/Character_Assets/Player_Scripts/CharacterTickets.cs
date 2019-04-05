using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTickets : MonoBehaviour
{
    public int Tickets = 0;
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
    
    }

    private void OnGUI()
    {
        //Displays a ticket counter on screen, adds tickets as collected.
        GUI.Label(new Rect (10,10,100,20), "Tickets: " + Tickets);
    }
}
