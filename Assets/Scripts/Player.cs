using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public bool flipSpriteHorizontally;

	[Header("Jump Variables")]
	public float maxJumpHeight = 4.5f;
	public float minJumpHeight = 1f;
	public float TimeToJumpApex;
	public float MoveSpeed = 6;

	[Header("")]
	public bool wallPhysics;

	[Header("Wall Physics Variables")]
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpLeap;
	public float wallSlideSpeedMax = 3f;
	public float wallStickTime;

	[Header("Acceleration")]
	public float accelerationTimeAirborne = 0.2f;
	public float accelerationTimeGrounded = 0.15f;
	

	public Sprite wallRest;

	float timeToWallUnstick;
	float delay = 1f;
	float velocityXSmoothing;
	float gravity = -20;
	float maxJumpForce = 10;
	float minJumpForce = 10;
	float jumpDelay;

	bool facingRight = true;

	SpriteRenderer spriteRenderer;


	[HideInInspector]
	public Vector2 public_input;

	Vector3 velocity;
	Controller2D controller;

	[HideInInspector]
	public Vector3 startPosition;

	void Start() {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * maxJumpHeight) / Mathf.Pow(TimeToJumpApex, 2);
		maxJumpForce = Mathf.Abs(gravity * TimeToJumpApex);
		minJumpForce = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
		spriteRenderer = GetComponent<SpriteRenderer>();

		startPosition = transform.position;
		jumpDelay = 0;
	}

	void Update () {

		bool onWall = false;
		

		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		public_input = input;

		if (flipSpriteHorizontally) {
			AutoFlip(input);
		}

		if (controller.collisions.below) {
			jumpDelay = 0.4f;
		}

		if ((controller.collisions.left || controller.collisions.right) && wallPhysics) {
			if (controller.collisions.left) {
				spriteRenderer.flipX = true;
			} else {
				spriteRenderer.flipX = false;
			}

			if (controller.collisions.below) {
				spriteRenderer.sprite = wallRest;
			} else {

			}
		} else {
			spriteRenderer.flipX = false;
		}

		int wallDirX = (controller.collisions.left)? -1 : 1;

		float targetVelocityX = input.x * MoveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && !controller.collisions.touchingSlippery && wallPhysics) {
			onWall = true;
			if (velocity.y < 0) {
				if (velocity.y < -wallSlideSpeedMax) {
					velocity.y = -wallSlideSpeedMax;
				}

				if (timeToWallUnstick > 0) {
					velocityXSmoothing = 0;
					velocity.x = 0;

					if (input.x != wallDirX && input.x != 0) {
						timeToWallUnstick -= Time.deltaTime;
					} else {
						timeToWallUnstick = wallStickTime;
					}
				} else {
					timeToWallUnstick = wallStickTime;
				}
			}
			
		}

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		
		if (Input.GetKey(KeyCode.UpArrow)) {
			delay = 1f;
			if (onWall && wallPhysics) {
				if (wallDirX == input.x) {
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
				} else if (wallDirX == -input.x) {
					velocity.x = -wallDirX * wallJumpLeap.x;
					velocity.y = wallJumpLeap.y;
				}
			}
			
			if (controller.collisions.below || jumpDelay > 0) {
				velocity.y = maxJumpForce;
			}
		} else {
			delay -= 0.3f;
			if (delay < -1) {
				delay = -1;
			}
		}

		if (Input.GetKeyUp(KeyCode.UpArrow)){
			if (velocity.y > minJumpForce) {
				velocity.y = minJumpForce;
			}
			
		}

		if (delay > 0 && wallDirX == input.x && onWall) {
			velocity.x = -wallDirX * wallJumpClimb.x;
			velocity.y = wallJumpClimb.y;
		} else if (delay > 0 && wallDirX == -input.x && onWall) {
			velocity.x = -wallDirX * wallJumpLeap.x;
			velocity.y = wallJumpLeap.y;
		}

		if (controller.collisions.touchingBad) {
			transform.position = startPosition;
		}

		
		
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		jumpDelay -= 0.1f;

	}

	void AutoFlip (Vector2 input) {
		if (!facingRight && input.x > 0) {
			Flip();
		} else if (facingRight && input.x < 0) {
			Flip();
		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}
}
