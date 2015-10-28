/* Author: Max Sazhaev
 * File: PlayerController.cs
 * Creation Date: October 26th 2015
 * Description: This script controls the score
 */
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GUIText scoreText;
    private int score;
	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    // Shows format for updated score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
