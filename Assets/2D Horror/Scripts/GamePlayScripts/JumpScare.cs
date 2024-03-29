using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This script show any GameObject if player will walk into Trigger
public class JumpScare: MonoBehaviour {


	public GameObject ImageToShow;
	// Use this for initialization
	void Start () {
		//It makes GameObject invisible at start
		ImageToShow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(){
		//It makes visible GameObject when Player walk into trigger
		//Trigger is: EmptyObject with BoxCollider2D and marked: Is Trigger
		ImageToShow.SetActive (true);

	}

	void OnTriggerExit2D(){
		//When player leave Trigger it make GameObject invisible
		//and destroy GameObject so you can do it only once
		//if you want to make it repeatable delete: destroy line
		ImageToShow.SetActive (false);
		Destroy (gameObject);

	}
}
