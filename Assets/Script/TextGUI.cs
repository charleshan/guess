﻿using UnityEngine;
using System.Collections;

public class TextGUI : MonoBehaviour {
	static private string textFieldString = "";
	private string currentGuess;

	void Start(){
	}
	
	void OnGUI(){

		
		textFieldString = GUI.TextField (new Rect (600, 500, 100, 30), textFieldString, 25);
		
		GUI.Label (new Rect(600,475,100,100), "Guess: ");
	}

	public static string getText() {
		return textFieldString;
	}


}