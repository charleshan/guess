﻿using UnityEngine;
using System.Collections;

/* Timer.cs
 * This script manages guess timer functions.
 * Create an empty game object and attach this script to it.
 * Add associated GUIText object that displays the timer in the public GUIText field
 * This script counts doen from fixed time to 0, and does something when it hits zero (pending integration)
 */

public class Timer : MonoBehaviour {

	// Variables
	public GUIText timerGUI;
	public int startTimerValue;	// unit in seconds
	private float currentTimerValue;	// unit in seconds

	private bool timerStarted = false;

	public AudioClip timerTick;
	public AudioClip timerEnd;

	// Use this for initialization
	void Start () {
		if (timerGUI == null || startTimerValue == null) {
			Debug.LogError ("Null Variables in Timer.cs");
		}

		// Test code
		UnitTest ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timerStarted == true) {
			currentTimerValue -= Time.deltaTime;

			if (currentTimerValue <= 0) {
				currentTimerValue = 0;
			}

			// Update GUIText
			int timeInInt = (Mathf.FloorToInt (currentTimerValue)) ;
			string timerText = GetMinuteFromTotalTime(timeInInt) + ":" + GetSecondFromTotalTime(timeInInt);
			timerGUI.text = timerText;

			if (currentTimerValue == 0) {
				timerStarted = false;	// stop the timer
				OnTimerDone ();
			}
		}
	}

	public void StartTimer() {
		timerStarted = true;
		currentTimerValue = startTimerValue;
		this.gameObject.audio.clip = timerTick;
		this.gameObject.audio.loop = true;
		this.gameObject.audio.Play();
	}

	public void PauseTimer() {
		timerStarted = false;
		this.gameObject.audio.Pause();
	}

	public void UnpauseTimer() {
		timerStarted = true;
		this.gameObject.audio.Play ();
	}

	public void ResetTimer() {
		timerStarted = false;
		currentTimerValue = startTimerValue;
	}

	private void OnTimerDone() {
		Debug.Log ("Timer is done, do some stuff!");
		this.gameObject.audio.clip = timerEnd;
		this.gameObject.audio.loop = false;
		this.gameObject.audio.Play ();
	}

	static string GetMinuteFromTotalTime(int second) {
		return (second / 60).ToString ();
	}

	static string GetSecondFromTotalTime(int second) {
		int sec = second % 60;
		if (sec < 10) {
			return "0" + sec.ToString ();
		}
		else {
			return sec.ToString ();
		}
	}

	private void UnitTest() {
		StartTimer ();
	}
}