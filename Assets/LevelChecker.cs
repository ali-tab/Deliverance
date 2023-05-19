using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChecker : MonoBehaviour
{


    private GameMaster gm;


    private void Start()
    {

    gm = GameObject.Find("GameManager").GetComponent<GameMaster>();

    for (int i = 0; i < this.gameObject.transform.childCount; i++){


        if (gm.levelUnlocked(i)){

            Debug.Log(i);
            this.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;

        }

        if (gm.levelFinished(this.gameObject.transform.childCount - 1)){

            Debug.Log("All levels finished!");
        }
    }


    }


}
