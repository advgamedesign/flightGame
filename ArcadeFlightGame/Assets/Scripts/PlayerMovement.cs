using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    //Plane Movement Speeds
    [SerializeField] private float forwardSpeed;
    //public float boostSpeed = 80;
    //public float brakeSpeed = 20;

    //How fast the ship changes speed
    //public float acceleration = 5;

    //Speed of Arrow Key movement
    [SerializeField] private float directionalSpeed;

    //Speed of Turn Rotation(A & D Keys)
    [SerializeField] private float turnSpeed;

    //Plane Roll Angle
    [SerializeField] private float roll;

    //Plane Pitch Value
    //public float pitch;

    //Set Minimum/Maximum Height
    [SerializeField] private float MaxHeight;
    [SerializeField] private float MinHeight;

    //----Bullet Info----
    public float fireTime = 1f;
    public GameObject bulletObject;

    public int amountOfBullets = 40;
    List<GameObject> bullets;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("PlayerMovement Script Added To: " + gameObject.name);

        //Instantiate all bullets
        bullets = new List<GameObject>();
        for(int i = 0; i < amountOfBullets; i++) {
            GameObject obj = (GameObject)Instantiate(bulletObject);
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }

    // Update is called once per frame
    void Update() {

        #region Arrow Movement
        //------------Setup Initial Arrow Flight Movement---------------

        if(transform.position.y > MaxHeight)
            transform.position = new Vector3(transform.position.x, MaxHeight, transform.position.z);
        if(transform.position.y < MinHeight)
            transform.position = new Vector3(transform.position.x, MinHeight, transform.position.z);

        //------Up Arrow Key------

        //When Up Arrow key is pushed down
        if(Input.GetKey(KeyCode.UpArrow)) {
            //Transform Position Z to Move Player Up
            transform.Translate(0, transform.up.y * directionalSpeed * Time.deltaTime, 0, Camera.main.transform);
        }

        /*//Rotation handling for Up Arrow
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.Rotate(-pitch, 0, 0);
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)) {
            transform.Rotate(pitch, 0, 0);
        }*/

        //------Down Arrow Key------

        //When Down Arrow key is pushed down
        if(Input.GetKey(KeyCode.DownArrow)) {
            //Transform Position Z to Move Player Down
            transform.Translate(0, transform.up.y * -directionalSpeed * Time.deltaTime, 0, Camera.main.transform);
        }

        /*//Rotation handling for Down Arrow
        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            transform.Rotate(pitch, 0, 0);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow)) {
            transform.Rotate(-pitch, 0, 0);
        }*/

        //------Right Arrow Key------

        //When Right Arrow key is pushed down
        if(Input.GetKey(KeyCode.RightArrow)) {
            //Transform Position Z to Move Player Right
            transform.position += Camera.main.transform.right * directionalSpeed * Time.deltaTime;
        }

        //Rotation handling for Right Arrow
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, -roll);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow)) {
            transform.Rotate(0, 0, roll);
        }

        //------Left Arrow Key------

        //When Left Arrow Key is pushed down
        if(Input.GetKey(KeyCode.LeftArrow)) {
            //Transform Position Z to Move Player Left
            transform.position += Camera.main.transform.right * -directionalSpeed * Time.deltaTime;
        }


        //Rotation handling for Left Arrow
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, roll);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow)) {
            transform.Rotate(0, 0, -roll);
        }

        #endregion

        #region Shooting
        if(Input.GetKey(KeyCode.Space)) {
            Fire();
        }
        #endregion
        //------TAKE OUT LATER-----
        //Turn Ship Left
        if(Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -turnSpeed, 0, Space.World);
        }

        //------TAKE OUT LATER-----
        //Turn Ship Right
        if(Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, turnSpeed, 0, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            
    }

    private void FixedUpdate() {


        #region Movement Speed (W & Left Shift Keys)

        /*//Apply the speed to the rigidbody
        if(rb != null) {
            Vector3 movement = new Vector3(0, 0, forwardSpeed);
            rb.AddForce(movement * Time.deltaTime, ForceMode.VelocityChange);
        }

        if(rb.velocity.magnitude > forwardSpeed) {
            rb.velocity = rb.velocity.normalized * forwardSpeed;
        }
        */

        transform.position += transform.forward * forwardSpeed * Time.deltaTime;

        #endregion
    }

    // Update is called once per frame
    public void Fire() {
        for(int i = 0; i < bullets.Count; i++) {
            if(!bullets[i].activeInHierarchy) {
                bullets[i].transform.position = transform.position;
                bullets[i].transform.rotation = transform.rotation;
                bullets[i].SetActive(true);
                break;
            }
        }
    }
}
