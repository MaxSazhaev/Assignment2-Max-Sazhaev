/* Author: Max Sazhaev
 * File: PlayerController.cs
 * Creation Date: October 26th 2015
 * Description: This script is controls the player's movement, sound of collision, and flipping image
 */
using UnityEngine;
using System.Collections;
[System.Serializable]
public class VelocityRange
{
    // Public instance variables
    public float vMin, vMax;

    // Constructor
    public VelocityRange(float vMin, float vMax)
    {
        this.vMin = vMin;
        this.vMax = vMax;
    }
}

public class PlayerController : MonoBehaviour {
    // Public instance variables
    public float speed = 10f;
    public float jump = 10f;

    public VelocityRange velocityRange = new VelocityRange(3f, 10f);

    // Private instance variables
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;

    private AudioSource[] _audioSources;
    private AudioSource _coinSound;
    private AudioSource _enemySound;

    private float _movingValue = 0;
    private bool _isFacingRight = true;
    private bool _isGrounded = true;

	// Use this for initialization
	void Start () {
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
        this._transform = gameObject.GetComponent<Transform> ();

        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._coinSound = this._audioSources[0];
        this._enemySound = this._audioSources[1];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	float forceX = 0f;
        float forceY = 0f;

        float absVelX = Mathf.Abs (this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs (this._rigidBody2D.velocity.y);

        this._movingValue = Input.GetAxis ("Horizontal"); // value is between -1 and 1

        // Check if player is moving

        if (this._movingValue != 0)
        {
            if (this._movingValue > 0)
            {
                if (absVelX < this.velocityRange.vMax)
                {
                    forceX = this.speed;
                    this._isFacingRight = true;
                    this._flip();
                }
            }
            else if (this._movingValue < 0)
            {
                // Moving left
                if (absVelX < this.velocityRange.vMax)
                {
                    forceX = -this.speed;
                    this._isFacingRight = false;
                    this._flip();
                }
            }
        }
        else if (this._movingValue == 0)
        {
            //idle
        }

        // Check if player is jumping

        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            // Check if the player is grounded
            if(this._isGrounded)
            {
                // Player is jumping
                if (absVelY < this.velocityRange.vMax)
                {
                    forceY = this.jump;
                    this._isGrounded = false;
                }
            }
        }

        this._rigidBody2D.AddForce(new Vector2(forceX, forceY));
	}

    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag ("Coin"))
        {
            
            this._coinSound.Play();
        }
        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            this._enemySound.Play();
        }
    }

    void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = true;
        }
    }

    private void _flip()
    {
        if (this._isFacingRight)
        {
            this._transform.localScale = new Vector3(1f, 1f, 1f); // flip back to normal
        }
        else
        {
            this._transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
