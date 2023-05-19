using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PauseHandler : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public static bool isPaused = false;

    private GameMaster gm;

    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused){
                Resume();

            }
            else{
                Pause();

            }

        }


    }

    void Pause(){

        pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;


    }

    public void Resume(){

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void loadMenu(){

        gm = GameObject.Find("GameManager").GetComponent<GameMaster>();

        Time.timeScale = 1f;
        gm.leave();
        


    }




}