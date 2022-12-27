using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// script for controlling character
public class Character : MonoBehaviour
{
	// for character movement
	private CharacterController characterController;
	private float speed = 5f;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float jumpHeight = 1f;
	private float gravityValue = -9.81f;
	private float turnSpeed = 1.5f;
	private Vector3 rotation;
	[SerializeField] private bool isActive = true; // should the character be allowed to move? (false when player reaches end zone)
	
	// game data
	private int score = 0; // number of orbs collected
	private float startTime;
	private GameManager gameManagerScript;
	
	// data for animations
	public Animator animator;
	private bool isJumping = false;
	private bool isWalkingForward = false;
	private bool isWalkingBackward = false;
	private bool isTurningLeft = false;
	private bool isTurningRight = false;
	
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
		this.startTime = Time.time;
		this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		this.gameManagerScript.incrementAttempts();
    }

    // Update is called once per frame
    void Update()
    {
		groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
		
		if(this.isActive)
		{
			// character X/Z movement
			this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * turnSpeed*100 * Time.deltaTime, 0);
 
			Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
			
			move = this.transform.TransformDirection(move);
			characterController.Move(move * speed);
			this.transform.Rotate(this.rotation);
			
			// character Y movement/jumping
			if (Input.GetButton("Jump") && groundedPlayer)
			{
				playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
				
				if(jumpHeight * -3.0f * gravityValue >= 0)
				{
					this.isJumping = true; // if character is moving upwards, show jump animation
					//animator.SetBool("isIdle", false);
				}
				//anim.CrossFade("Jump");
			}
			// setting variables for animations
			else if(groundedPlayer)
			{
				this.isJumping = false;
			}
			
			if(Input.GetAxisRaw("Horizontal") * turnSpeed*100 * Time.deltaTime < 0)
			{
				this.isTurningLeft = true;
				this.isTurningRight = false;
			}
			else if(Input.GetAxisRaw("Horizontal") * turnSpeed*100 * Time.deltaTime > 0)
			{
				this.isTurningLeft = false;
				this.isTurningRight = true;
			}
			else
			{
				this.isTurningLeft = false;
				this.isTurningRight = false;
			}
			
			if(Input.GetAxisRaw("Vertical") > 0)
			{
				this.isWalkingForward = true;
				this.isWalkingBackward = false;
			}
			else if(Input.GetAxisRaw("Vertical") < 0)
			{
				this.isWalkingForward = false;
				this.isWalkingBackward = true;
			}
			else
			{
				this.isWalkingForward = false;
				this.isWalkingBackward = false;
			}
			
			animator.SetBool("isJumping", false);
			animator.SetBool("isWalkingForward", false);
			animator.SetBool("isWalkingBackward", false);
			animator.SetBool("isTurningLeft", false);
			animator.SetBool("isTurningRight", false);
			animator.SetBool("isIdle", false);
			// deciding which animation will be played
			// jumping animation takes priority, followed by walking forward/backward,
			// followed by turning left/right, followed by idle
			if(this.isJumping)
			{
				animator.SetBool("isJumping", true);
			}
			else if(this.isWalkingForward)
			{
				animator.SetBool("isWalkingForward", true);
			}
			else if(this.isWalkingBackward)
			{
				animator.SetBool("isWalkingBackward", true);
			}
			else if(this.isTurningLeft)
			{
				animator.SetBool("isTurningLeft", true);
			}
			else if(this.isTurningRight)
			{
				animator.SetBool("isTurningRight", true);
			}
			else
			{
				animator.SetBool("isIdle", true);
			}
			
			playerVelocity.y += gravityValue*Time.deltaTime;
			if(this.isJumping && playerVelocity.y < 0)
			{
				animator.SetBool("isJumping", false);
				animator.SetBool("isIdle", true);
			}
			characterController.Move(playerVelocity*Time.deltaTime);
		}
		else
		{
			characterController.Move(Vector3.zero);
		}
    }
	
	// triggered when player enters end zone
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "EndZone")
		{
			this.EndZone();
		}
	}
	
	// when player reaches end zone, they are taken to the finish screen
	private void EndZone()
	{
		this.isActive = false;
		float totalTime = Time.time - this.startTime;
		
		this.gameManagerScript.setScore(this.score);
		this.gameManagerScript.setTime(totalTime);
		
		//SceneManager.LoadScene("EndScreen");
		this.gameManagerScript.EndZone();
	}
	
	public void IncrementScore()
	{
		this.score++;
	}
	
	private bool AnimPlaying()
	{
		return this.animator.GetCurrentAnimatorStateInfo(0).length > this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}
	
	private bool AnimPlaying(string stateName)
	{
		return AnimPlaying() && this.animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
	}
}
