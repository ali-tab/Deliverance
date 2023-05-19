using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemCollector : MonoBehaviour
{

    private GameMaster gm;

    private CanvasHandler levUI;

    private void Start(){
    
    gm = GameObject.Find("GameManager").GetComponent<GameMaster>();

    levUI = GameObject.Find("LevelUI").GetComponent<CanvasHandler>();

    }

    private void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.CompareTag("Gem"))
        {
            Debug.Log("Collected");
            gm.isCollected();

            if (gm.keptLevelsGem() == false){
            levUI.gemFoundInLevel();
            }

            Destroy(other.gameObject);

        }
        

    }
}
