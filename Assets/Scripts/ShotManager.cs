using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotManager : MonoBehaviour {

    public Text shotCountText;
    public float shotsAvailable = 10f;

	// Use this for initialization
	void Awake () {
        writeText();
	}
	
    private void writeText()
    {
        shotCountText.text = "Shots: " + shotsAvailable;
    }

	// Update is called once per frame
	public bool Shoot () {
        // See how many shots we have.
        // If we have enough, we can decrement the counter and return true.

        if (shotsAvailable > 0) {
            shotsAvailable -= 1;
            writeText();
            return true;
        }

        // Not enough shots remaining, so no shots!
        return false;
	}
}
