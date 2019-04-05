using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Script : MonoBehaviour
{
    public Text Score, Points, MG_Name;
    GameObject TrophyRef, PlayerRef, MiniGameReF, AI_Object, SpawnRef;
    private ScoreTimer_Script GameUI;

    private void Start()
    {
        SpawnRef = GameObject.Find("_GameManager");
        PlayerRef = GameObject.Find("Player_PF");
        MiniGameReF = this.transform.parent.GetChild(0).gameObject;
        AI_Object = this.transform.parent.GetChild(1).gameObject;
        GameUI = this.transform.parent.GetChild(5).gameObject.GetComponentInChildren<ScoreTimer_Script>();
    }

    private void Update()
    {
        MG_Name.text = MiniGameReF.name;
        Score.text = "Score : " + AI_Object.GetComponent<MoveAI_Script>().score.ToString();
    }
    // Start is called before the first frame update
    public void Replay()
    {
        Cursor.lockState = CursorLockMode.None;
        MiniGameReF.GetComponent<Cabinet_Script>().beginGame = true;
        PlayerRef.GetComponent<CharacterMovement>().HasEnteredGame = true;
        AI_Object.GetComponent<MoveAI_Script>().score = 0;
        GameUI.SetTimerValues();
        StartCoroutine(SpawnRef.GetComponent<SpawnController_Script>().ResetValuesGameAI());
        this.gameObject.SetActive(false);
    }
       
    public void ExitGame()
    {
        Cursor.lockState = CursorLockMode.None;
        MiniGameReF.GetComponent<Cabinet_Script>().beginGame = false;
        PlayerRef.GetComponent<CharacterMovement>().HasEnteredGame = false;
        this.gameObject.SetActive(false);
    }
}
