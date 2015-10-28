/* Author: Max Sazhaev
 * File: EnemyController.cs
 * Creation Date: October 26th 2015
 * Description: This script is controls the enemy's movement, and collision with the player
 */
using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
    // public instance variables
    public float speed = -1f;

    

    // private instance variables
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;
    
    

    private bool _isGrounded = false;

	// Use this for initialization
	void Start () {
        

        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(this._isGrounded)
        {
            this._rigidBody2D.velocity = new Vector2(this.speed, 0f);
        }
	}

    void OnCollisionStay2D (Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag ("Platform"))
        {
            this._isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            Destroy(otherCollider.gameObject);
            Destroy(gameObject);
        }
    }
}
