using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer_Script : MonoBehaviour {

    private float CurrentTime, StartingTime;

    public Text Timer, ScoreUI;
    GameObject PlayerRef, GameUI;
    MoveAI_Script AI_Ref;
    Cabinet_Script CabinetRef;

    private void Start()
    {
        PlayerRef = GameObject.Find("Player_PF");
        AI_Ref = transform.parent.GetChild(1).gameObject.GetComponent<MoveAI_Script>();
        GameUI = transform.parent.GetChild(6).gameObject;
        CabinetRef = transform.parent.GetChild(0).gameObject.GetComponent<Cabinet_Script>();
    }

    private void Update()
    {
        if (PlayerRef.GetComponent<CharacterMovement>().HasEnteredGame && CabinetRef.beginGame)
        {
            UpdateTimer();
            UpdateScore();
        }
    }

    public void SetTimerValues()
    {
        switch (CabinetRef.SpawnRef.Minigame)
        {
            case 1:
                StartingTime = 120f;
                break;

            case 2:
                StartingTime = 50f;
                break;

            case 3:
                StartingTime = 120f;
                break;
        }
        CurrentTime = StartingTime;
    }


    void UpdateTimer()
    {
        CurrentTime -= 1 * Time.deltaTime;

        string minutes = ((int)CurrentTime / 60).ToString();
        string second = (CurrentTime % 60).ToString("0");

        if ((CurrentTime % 60) > 10)
        {
            Timer.text = "0" + minutes + ":" + second;
        }
        else
        {
            Timer.text = "0" + minutes + ":0" + second;
            if (CurrentTime <= 0 )
            {
                CurrentTime = 0;
                CabinetRef.beginGame = false;
                print("this is the problem");
                GameUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    void UpdateScore()
    {
        if (AI_Ref.score < 10)
        {
            ScoreUI.text = "000" + AI_Ref.score.ToString();
        }
        else if (AI_Ref.score > 10)
        {
            ScoreUI.text = "00" + AI_Ref.score.ToString();
        }
    }
}
