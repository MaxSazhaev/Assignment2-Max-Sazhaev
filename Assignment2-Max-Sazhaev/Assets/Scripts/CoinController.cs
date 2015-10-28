/* Author: Max Sazhaev
 * File: CoinController.cs
 * Creation Date: October 26th 2015
 * Description: This script is controls destroying the coin and adding score when colliding
 */

using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	// Use this for initialization
    public int scoreValue;
    private GameController gameController;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
        }
    }
}
