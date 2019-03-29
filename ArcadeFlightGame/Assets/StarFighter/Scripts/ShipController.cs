using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	//Main camera
	public Camera cam;
	//The ship model
	public Transform graphic;

	//camRestPos is the camera's position in the game world, relative to the player
	public Vector3 camRestPos;
	//Offset will be used to move the camera when the player turns
	Vector3 camOffset;

	//The speed the camera rotates and moves
	public float camSpeed = 6;

	//Movement speeds
	public float forwardSpeed = 80;
	public float boostSpeed = 200;
	public float brakeSpeed = 50;
	//How fast the ship changes speed
	public float acceleration = 5;

	//How quickly the ship graphic will rotate when turning
	public float rollSpeed = 8;

	//How fast the graphic rotates during a dodge roll
	public float dodgeRollSpeed = 10;
	//How fast we move during a roll
	public float dodgeForce = 50;
	//Length of dodge in seconds
	public float dodgeTime = 1;
	//Time in seconds between dodges
	public float dodgeCooldown = 1;
	//Used to track how long the dodge has left
	float dodgeTimer;
	//Track how much time until we can dodge again
	float dodgeCool;

	//Camera field of view
	public float fov = 60;
	public float boostFov = 70;

	//Used to calculate the ship's speed
	float curSpeed;
	bool boosting = false;
	bool braking = false;

	//The time in seconds the camera will shake for
	float camShake;
	//Used to shake the camera
	Vector3 shakeVector;

	//The ship's rigidbody
	Rigidbody rb;

	//UI images for the target reticle
	public Image reticleFar;
	public Image reticleClose;

	//Heath UI
	public Text armourTxt;

	//Should the cursor be locked?
	bool lockCursor;

	//Used to calculate the player's input
	float xIn = 0;
	float yIn = 0;
	float zIn = 0;

	//Player's input sensitivity for steering the ship
	public float sensetivity = 10;

	//Ship's weapons
	public WeaponScript[] wpns;

	//Health
	public int armour = 15;
	//Maximum health
	public int armourMax = 15;

	//This is used for the demo to delay the player's respawn
	float deathTimer;

	void Start () {
		if (cam == null)
			cam = Camera.main;

		rb = gameObject.GetComponent<Rigidbody>();

		lockCursor = true;
	}

	void Update () {
		//Reduce the dodge cooldown timer by 1 per second ONLY if a dodge is not in progress
		if (dodgeCool > 0 && dodgeTimer <= 0)
			dodgeCool-=Time.deltaTime;

		if (armour <= 0) {
			Death();
		}
		armourTxt.text = "ARMOUR: " + armour + "/" + armourMax;
	}
	
	void FixedUpdate () {
		
		//Are we boosting or braking?
		if (Input.GetKey("space") || Input.GetKey(KeyCode.JoystickButton0)) {
			boosting = true;
			//Change the FOV when boosting
			cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,boostFov,Time.deltaTime);
		} else {
			boosting = false;
			//Change the FOV back
			cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,fov,Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.CapsLock) || Input.GetKey(KeyCode.JoystickButton1)) {
			braking = true;
		} else {
			braking = false;
		}

		//Should the cursor be locked?
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.JoystickButton7)) {
			lockCursor = !lockCursor;
		}

		//Lock or release the cursor
		if (lockCursor)
			Cursor.lockState = CursorLockMode.Locked;
		else
			Cursor.lockState = CursorLockMode.None;


		//-------------------------------
		//Target Reticle
		//-------------------------------
		//wantedPos will be used to get the final position for both reticles
		Vector3 wantedPos;

		//The UI images will be placed over positions 20 and 40 units in front of the ship
		if (reticleFar != null) {
			wantedPos = Camera.main.WorldToScreenPoint (transform.position+(transform.forward*100));
			reticleFar.transform.position = wantedPos;
		}
		if (reticleClose != null) {
			wantedPos = Camera.main.WorldToScreenPoint (transform.position+(transform.forward*20));
			reticleClose.transform.position = wantedPos;
		}

		//---------------------------
		//Camera Shake
		//---------------------------
		if (camShake > 0) {
			camShake -= Time.deltaTime;
			shakeVector = new Vector3 (Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f))*camShake;
		}

		//-------------------------------
		//Camera Rotation and Position
		//-------------------------------
		//camDir is the direction the camera faces. To begin, camDir is set to a Vector3 position 20 units in front of the ship
		Vector3 camDir = (transform.position + transform.forward*20);
		//Subtracting the camera's position provides the direction the camera should be facing
		camDir = camDir - cam.transform.position;
		//camDir is then converted into a Quaternion so the camera can be smoothly rotated to face that target position
		Quaternion newRot = Quaternion.LookRotation(camDir,transform.up);
		cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation,newRot,Time.deltaTime * camSpeed);

		//The camera is placed in a fixed position behind the ship
		camOffset = Vector3.Lerp(camOffset, new Vector3(Input.GetAxis("Horizontal")*3,-Input.GetAxis("Vertical")*3,0), Time.deltaTime * camSpeed);
		cam.transform.localPosition = camRestPos + camOffset;

		//Applying the camera shake effect needs to be done last to prevent the shake effect from being overridden by the camera placement
		cam.transform.localPosition += shakeVector;

		//-------------------------------
		//Roll
		//-------------------------------
		//Roll the graphic by rotating
		if (dodgeTimer <= 0)
			graphic.rotation = Quaternion.Slerp(graphic.rotation,Quaternion.LookRotation(transform.forward,transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal")*0.75f,1,0))), Time.deltaTime * rollSpeed);

		//-------------------------------
		//Steer ship
		//-------------------------------
		//Get the player's input and apply the Sensitivity setting. A higher sensitivity will make the ship turn faster.
		xIn = Mathf.Lerp(xIn,Input.GetAxis("Horizontal") * sensetivity,Time.deltaTime * 15);
		yIn = Mathf.Lerp(yIn,Input.GetAxis("Vertical") * sensetivity,Time.deltaTime * 15);
		zIn = Mathf.Lerp(zIn,Input.GetAxis("Mouse X") * -sensetivity,Time.deltaTime * 15);

		//Reduce the turing speed while boosting
		if (boosting) {
			xIn *= 0.5f;
			yIn *= 0.5f;
		}

		//Rotate the ship around each axis
		if (dodgeTimer <= 0) {
			transform.RotateAround(transform.position,transform.up,Time.deltaTime*xIn);
			transform.RotateAround(transform.position,transform.right,Time.deltaTime*yIn);
			transform.RotateAround(transform.position,transform.forward,Time.deltaTime*zIn);
		}
		
		//-------------------------------
		//Apply Movement
		//-------------------------------
		//The ship will be moved using the variable curSpeed. To smooth out the transitions between speeds, curSpeed is Lerped based on what
		if (boosting) 
			curSpeed = Mathf.Lerp (curSpeed,boostSpeed,Time.deltaTime * acceleration);
		else if (braking)
			curSpeed = Mathf.Lerp (curSpeed,brakeSpeed,Time.deltaTime * acceleration);
		else
			curSpeed = Mathf.Lerp (curSpeed,forwardSpeed,Time.deltaTime * acceleration);

		//Apply the final speed to the rigidbody
		rb.AddForce(transform.forward * curSpeed * Time.deltaTime,ForceMode.VelocityChange);

		//Check Input, and make sure we're not currently dodging and it has been long enough since the last dodge
		if (Input.GetKey("left shift") && dodgeTimer <= 0 && dodgeCool <= 0) {
			//Get the direction of the roll
			int dir = (int)Input.GetAxisRaw("Horizontal");

			//Only begin the roll if the player is holding a directional key
			if (dir != 0)
				StartCoroutine("DodgeRoll", dir);
		}
	}

	IEnumerator DodgeRoll (int d) {
		//Debug.Log ("Rolling!");
		dodgeTimer = dodgeTime;

		//Set the cooldown to prevent another dodge from immediately being used
		dodgeCool = dodgeCooldown;

		while (dodgeTimer > 0) {
			//Reduce the timer by 1 per second
			dodgeTimer-=Time.deltaTime;

			//Rotate the graphic around it's forward axis, making sure to multiply it by the direction
			graphic.Rotate(Vector3.forward * Time.deltaTime * dodgeRollSpeed * -d);

			//Move the rigidbody in the correct direction
			rb.AddForce(transform.right * d * dodgeForce * Time.deltaTime,ForceMode.VelocityChange);

			//Wait for the next frame. Without this the entire function will be executed in a single frame
			yield return null;
		}

		//Debug.Log ("Roll Over!");
	}

	void Death () {
		//This is for demo purposes
		//When the player dies their health is restored and they are placed back at the start
		armour = armourMax;
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
	}

	public void ApplyShake (float s) {
		//Camera shake is only added if the current shake amount is less than what is being applied
		//This stops the camera from shaling too wildly if there are multiple sources shaking the 
		//camera at a single time
		if (camShake < s)
			camShake = s;
		else
			camShake += s;
	}

	public void ApplyDMG (int d) {
		armour-=d;
	}

	void OnCollisionEnter (Collision col) {
		ApplyShake(0.25f);
	}
}
