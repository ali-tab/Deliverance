using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChecker : MonoBehaviour
{

    private GameMaster gm;
    [SerializeField] private Text numGems;
    [SerializeField] private GameObject preview;

    private void Start()
    
    {

    gm = GameObject.Find("GameManager").GetComponent<GameMaster>();

    for (int i = 0; i < this.gameObject.transform.childCount; i++){

        if (gm.getNumGems() >= i){
            
            this.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;

        }

    }

    numGems.text =  gm.getNumGems() + "/3" + " gems collected";

    preview.GetComponent<Image>().color = gm.getSkin();



    }


}
