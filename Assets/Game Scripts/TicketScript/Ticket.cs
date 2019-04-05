using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    { // This makes the ticket spin.
        transform.Rotate(90 * Time.deltaTime, 0, 0);
	}

    //If characetr collides with object.
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            // Add 1 to Tickets.
           // other.GetComponent<CharacterTickets>().Tickets++;

            // Destroys Ticket on collection.
            Destroy(gameObject);

        }



    }


}
