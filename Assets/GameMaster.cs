using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    private bool[] collectedinLevel = new bool[3];

    private bool[] gems = new bool[3];

    private bool[] levelCompleted = new bool[3];

    private bool[] levelsUnlocked = new bool[3];

    private Color selectedSkin = new Color (1, 1, 1, 1);

    private GameObject [] GMs;

    public bool keptLevelsGem(){

        return gems[levelNumber() - 1];

    }

    public void changeSkin(Color c){

        selectedSkin = c;
        
    }

    public Color getSkin(){

        return selectedSkin;
        
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        levelsUnlocked[0] = true;

        //levelsUnlocked[1] = true;
        //levelsUnlocked[2] = true;

        //gems[0] = true;
        //gems[1] = true;
        //gems[2] = true;

        
        SceneManager.LoadScene("Main Menu");

    }


    public bool levelUnlocked(int i){

        return levelsUnlocked[i];

    }

    public int getNumGems(){

    int count = 0;

    for (int i = 0; i < gems.Length; i++)
    {
        if(gems[i]){
            count++;
        }

    }

    return count;

    }
    
    public bool levelFinished(int i){

        return levelCompleted[i];

    }

    private int levelNumber(){

        string sceneName = SceneManager.GetActiveScene().name;

        int ad = (sceneName[sceneName.Length-1]) - '0';


        return ad;
    }

    public void isCollected(){

        collectedinLevel[levelNumber() - 1] = true;

    }

    public void leave(){

        collectedinLevel[levelNumber() - 1] = false;

        SceneManager.LoadScene("Main Menu");

    }

    public void finish(){

        if (collectedinLevel[levelNumber() - 1] == true){

            gems[levelNumber() - 1] = true;

        }

        levelCompleted[levelNumber() - 1] = true;

        if (levelCompleted.Length > levelNumber()){

            levelsUnlocked[levelNumber()] = true;
            SceneManager.LoadScene("LevelSelect");

        }

        else {

            SceneManager.LoadScene("EndScreen");

        }
        
    }


}
