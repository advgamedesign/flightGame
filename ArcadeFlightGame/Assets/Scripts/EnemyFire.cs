using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    //Turret's target
    public Transform target;
    //Turret's projectile
    public GameObject proj;
    //Speed of the projectile
    public float projSpeed;
    //Time in seconds between shots
    public float cooldown;
    //Amount of projectiles fired per shot
    public int shotCount = 1;
    //Accuracy
    public float spread = 3;
    //Used to moniter the delay between shots
    float cool;
    //Within what rage the turret becomes active and can shoot
    public float range;
    //Speed at which the turret rotates
    public float rotateSpeed = 15;

    //The turret graphic. This is the part that will rotate to face the player.
    public Transform turret;

    //GameObject to be created when the turret is destroyed
    public GameObject deathEffect;

    //Health
    public int hpMax = 1;
    public int hp = 1;

    AudioSource au;

    //Sound played when a shot is fired
    public AudioClip shotSnd;

    //Used to tell if the turret can see the player or not
    //This should not include the player object's layer
    public LayerMask sceneMask;

    void Start()
    {
        //au = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        //Reduce the cooldown between shots by 1 per second
        if (cool > 0)
            cool -= Time.deltaTime;

        if (target != null)
        {
            //If the target is in range
            if (Vector3.Distance(target.position, turret.position) < range)
            {
                //Calculate which position the turret will aim at
                Vector3 targetPos = CalculateLead();

                //Get the direction to that position
                Vector3 targetDir = targetPos - turret.position;

                //New dir is the rotation the turret will use
                Quaternion newDir = Quaternion.LookRotation(targetDir, transform.up);
                //Rotate the turret to newDir by rotateSpeed
                turret.rotation = Quaternion.Slerp(turret.rotation, newDir, rotateSpeed * Time.deltaTime);

                //Get the angle between the turret and the target's direction
                float angleToTarget = Vector3.Angle(turret.forward, targetDir);

                //If we can shoot, can see the player and the angle to the target is low enough
                if (cool <= 0 && !Physics.Linecast(turret.position, target.position, sceneMask) && angleToTarget < 0.5f)
                {
                    //Shoot
                    Shoot();
                    cool = cooldown;
                }
            }
        }
        else
        {
            //Find target
            target = GameObject.FindWithTag("PlayerShip").transform;
        }

        if (hp <= 0)
            Die();
    }

    void Shoot()
    {
        //Get the direction the shot will move
        Vector3 direction = turret.forward;

        //For each shot the turret needs to fire
        for (int i = shotCount; i > 0; i--)
        {
            if (proj != null)
            {
                //Create the projectile
                GameObject shot = (GameObject)Instantiate(proj, turret.position - turret.forward, Quaternion.LookRotation(direction));
                //Disable collisions between the shot's collider and the turret's
                Physics.IgnoreCollision(shot.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
                //Apply the spread
                shot.transform.localEulerAngles += new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
                //Apply the nessecary force to the shot's rigidbody
                shot.GetComponent<Rigidbody>().velocity = shot.transform.TransformDirection(Vector3.forward * projSpeed);
            }
        }
        //Play the shot sound, if there is one
        //if (shotSnd != null)
           // au.PlayOneShot(shotSnd);
    }

    Vector3 CalculateLead()
    {
        //Get the distance between the turret and the target
        float dist = (turret.position - target.position).magnitude;
        //Time it should take for the projectile to reach the target. Time = distance/speed
        float timeToTarget = dist / projSpeed;
        //Get the speed of the target object
        float targetSpeed = target.gameObject.GetComponent<Rigidbody>().velocity.magnitude;

        //Predict the target's future position
        Vector3 newTargetPosition = target.position + (target.forward * targetSpeed) * timeToTarget;
        //Return it
        return newTargetPosition;
    }

    void ApplyDMG(int d)
    {
        //Apply incoming damage to health
        hp -= d;
    }

    void Die()
    {
        //Activate the death object
        deathEffect.SetActive(true);
        //Detach it from the turret
        deathEffect.transform.SetParent(null);

        //Destroy the turret
        Destroy(gameObject);
    }
}
