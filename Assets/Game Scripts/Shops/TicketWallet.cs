using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketWallet : MonoBehaviour {

    public static int CurrentTickets = 100;
    public int LocalTickets;
    public GameObject InventoryDisplay;
  


	// Update is called once per frame
	void Update ()
    {
        LocalTickets = CurrentTickets;
        InventoryDisplay.GetComponent<Text>().text = "Tickets: " + LocalTickets;
	}
}
