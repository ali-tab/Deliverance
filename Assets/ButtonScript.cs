using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private GameMaster gm;
    private CanvasHandler canv;

    private PauseHandler ph;

    public void enterLevelSelector(){

        SceneManager.LoadScene("LevelSelect");
    }

    public void enterMenu(){

        SceneManager.LoadScene("Main Menu");
    }

    public void loadLevel(){

        SceneManager.LoadScene("Level " + GetComponentInChildren<Text>().text);

    }

    public void enterShop(){

        SceneManager.LoadScene("Shop");
    }

    public void enterInstructions(){

        SceneManager.LoadScene("Instructions");
    }


    public void enterInstructions2(){

        SceneManager.LoadScene("Instructions2");
    }


    public void changeSkin(){

        gm = GameObject.Find("GameManager").GetComponent<GameMaster>();

        string skinName = gameObject.name;

        Debug.Log(GameObject.Find("SkinPreview").GetComponent<Image>().color);

        Debug.Log(gameObject.GetComponent<Image>().color);
        
        GameObject.Find("SkinPreview").GetComponent<Image>().color = gameObject.GetComponent<Image>().color;

        gm.changeSkin(gameObject.GetComponent<Image>().color);

    }

    public void quitGame(){

        Application.Quit();

    }


}