using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    // Setting 
    float sensitivity = 5.0f, smoothing = 2.0f;
    // Control the Camera axis clam values set differently for each minigame
    float MinX, MinY, MaxX, MaxY;

    //Refrences to Other objects or variables in code
    GameObject character;
    Vector2 MouseLook, smoothV;
    public GameObject CabinetRef;

    // Use this for initialization
    void Start()
    {
        // The character is the cameras parent.
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates camera rotation
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // Lerp moves something smoothly one place to another rather than snapping to that point.
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 0.5f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 0.5f / smoothing);
        MouseLook += smoothV;

        // If the player enters game the camera look is disabled
        if (character.GetComponent<CharacterMovement>().HasEnteredGame == false)
        {
            MouseLook.y = Mathf.Clamp(MouseLook.y, -70, 80);

            // this rotates the camera based on values above
            transform.localRotation = Quaternion.AngleAxis(MouseLook.y, Vector3.right);
            character.transform.rotation = Quaternion.AngleAxis(MouseLook.x, character.transform.up);
        }
        else if(CabinetRef.GetComponent<Cabinet_Script>().SpawnRef.Minigame != 3)
        {
            // This checks the values needed to clamp the players camera
            Checkgame();
            // this is the mechanic that clamps the camera
            MouseLook.x = Mathf.Clamp(MouseLook.x, MinX, MaxX);
            MouseLook.y = Mathf.Clamp(MouseLook.y, MinY, MaxY);
            // this rotates the camera based on values above
            transform.localRotation = Quaternion.Euler(MouseLook.y, MouseLook.x, 0);
        }
    }

    private void Checkgame()
    {
        // this is not efficient right now but will think of a better way of calculating these values
        switch (CabinetRef.GetComponent<Cabinet_Script>().SpawnRef.Minigame)
        {
            case 1:
                MinX = -15;
                MinY = -25;

                MaxX = 15;
                MaxY = -5;
                break;
            case 2:
                MinX = -20;
                MinY = 0;

                MaxX = 20;
                MaxY = 10;
                break;
        }
    }
}