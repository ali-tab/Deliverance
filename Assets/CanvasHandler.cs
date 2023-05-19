using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{

    public static bool GameIsPaused = false;

    [SerializeField] private Text gemStatus;

    private GameMaster gm;

    private PauseHandler pHandle;

    private void Start()
    {

        gm = GameObject.Find("GameManager").GetComponent<GameMaster>();

        if (gm.keptLevelsGem()){

            gemStatus.text =  "Gem already found";
        }

        else {

            gemStatus.text = "Gem not found";
        }

    }
    
    public void gemFoundInLevel(){

        gemStatus.text = "Gem found - complete level to keep!";

    }



}
