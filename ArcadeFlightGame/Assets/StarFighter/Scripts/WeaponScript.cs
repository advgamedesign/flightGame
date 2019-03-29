using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour {

	//Can the weapon fire?
	public bool canShoot = true;

	//Projectile spread. Zero is commpletely accurate
	public float spread = 0.3f;

	//Used to moniter when we can shoot
	private float cooldown;

	//The time in seconds between shots
	public float shotCool;

	//How much the screen shakes when firing
	public float shake = 0;

	//Bullet prefab
	public GameObject projectile;

	//Speed of the projectile
	public float projSpeed;

	//How many projectiles are fired in a single shot
	public int shotCount;

	//Shooting sound
	public AudioClip shotSnd;
	
	public GameObject playerChar;
	public Camera mainCam;

	AudioSource au;

	//Used to determine whith input fires the weapon
	public bool secondary = false;

	void Awake () {
		au = gameObject.GetComponent<AudioSource>();
	}

	void Update () {
		if (mainCam == null)
			mainCam = Camera.main;
		if (playerChar == null)
			playerChar = GameObject.FindWithTag("Player");

		//Reduce the cooldown by 1 per second
		if (cooldown >= 0)
			cooldown-=Time.deltaTime;

		//Fire on click
		if (Time.timeScale > 0 && canShoot) {
			if (Input.GetKey(KeyCode.Mouse0) || Input.GetAxis("Fire1") < 0) {
				if (cooldown <= 0 && !secondary) {
					Shoot();

					cooldown = shotCool;
				}
			}

			if (Input.GetKey(KeyCode.Mouse1) || Input.GetAxis("Fire2") < 0) {
				if (cooldown <= 0 && secondary) {
					Shoot();
					
					cooldown = shotCool;
				}
			}
		}
	}
	
	void Shoot () {
		//Shake the camera
		if (shake > 0)
			playerChar.SendMessage("ApplyShake",shake);

		//For each projectile the weapon fires per shot
		for (int i = shotCount;i > 0;i--) {
			if (projectile != null) {
				//Create the bullet
				GameObject shot = (GameObject)Instantiate(projectile,transform.position-transform.forward,Quaternion.LookRotation(transform.forward));
				//Stop it from colliding with player
				Physics.IgnoreCollision(shot.GetComponent<Collider>(), playerChar.GetComponentInChildren<MeshCollider>());
				//Apply spread
				shot.transform.localEulerAngles += new Vector3(Random.Range(-spread,spread),Random.Range(-spread,spread),Random.Range(-spread,spread));
				//Move the bullet
				shot.GetComponent<Rigidbody>().velocity = shot.transform.TransformDirection(Vector3.forward*projSpeed);
			} else {
				Debug.Log("No projectile set!");
			}
		}
		//Play the sound
		au.PlayOneShot(shotSnd);
	}
}
