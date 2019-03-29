using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//Trail object in children
	public GameObject trail;
	//Damage the bullet inflicts
	public int damage = 1;

	//The effect to be created on impact
	public GameObject impactGFX;
	//Can we hit objects tagged with Enemy?
	public bool hitEnemy = true;
	//Can we hit objects tagged with Player?
	public bool hitPlayer = true;

	//Will the bullet explode
	public bool explosive = false;
	//Radius of explosion
	public float radius = 0;

	void OnCollisionEnter (Collision collision) {
		if (!explosive) {
			//Apply damage to the correct targets
			if (collision.collider.gameObject.CompareTag("Enemy") && hitEnemy) {
				collision.collider.gameObject.SendMessageUpwards("ApplyDMG",damage, SendMessageOptions.DontRequireReceiver);
			}
			if (collision.collider.gameObject.CompareTag("Player") && hitPlayer) {
				collision.collider.gameObject.SendMessageUpwards("ApplyDMG",damage, SendMessageOptions.DontRequireReceiver);
			}
		}
		//Create the impact object, if there is one
		if (impactGFX != null) {
			Instantiate(impactGFX,collision.contacts[0].point,Quaternion.LookRotation(collision.contacts[0].normal));
		}

		Destroy();
	}

	void Destroy () {
		//Detatch the trail object and set it to auto destruct
		if (trail != null) {
			trail.transform.parent = null;
			trail.GetComponent<TrailRenderer>().autodestruct = true;
			trail = null;
		}

		if (explosive) {
			//Get all colliders within the explosion radius
			Collider[] co = Physics.OverlapSphere(transform.position,radius);
			//Send the appropriate message to each
			foreach (Collider c in co) {
				if (c.gameObject.CompareTag("Enemy") && hitEnemy)
					c.gameObject.SendMessageUpwards("ApplyDMG",damage, SendMessageOptions.DontRequireReceiver);
				if (c.gameObject.CompareTag("Player") && hitPlayer)
					c.gameObject.SendMessageUpwards("ApplyDMG",damage, SendMessageOptions.DontRequireReceiver);
			}
		}

		//Destroy the object
		Destroy(gameObject);
	}
}
