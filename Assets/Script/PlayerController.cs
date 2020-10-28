using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float zLimit = 9.8f;
    float zLimit2 = 19.5f;
    float zLimit3 = 9.9f;
    float zLimit4 = 10.1f;
    float xLimit = 9.8f;
    float xLimit2 = 5.4f;
    float jumpcount = 0f;
    float jumpInit = 0f;
    float xLimit4 = 4.7f;
    float gravityModifier = 2.0f;

    

    //bool keypressed = false;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        if (transform.position.z < zLimit4)
        {
            Debug.Log("Plane A");
            //green plane
            if (transform.position.z < -zLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
            }
            else if (transform.position.z > zLimit2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
            }
            if (transform.position.x < -xLimit)
            {
                transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xLimit)
            {
                transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
            }
            //border
            if (transform.position.x < -xLimit2 && transform.position.z > zLimit3)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zLimit3);
            }
            else if (transform.position.x > xLimit2 && transform.position.z > zLimit3)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zLimit3);
            }
        }
        else if (transform.position.z > zLimit4)
        {
            //xLimit4 = 4.7f;
            //zLimit2 = 19.5f;
            //blue plane
            Debug.Log("Plane B");
            if (transform.position.x < -xLimit4)
            {
                transform.position = new Vector3(-xLimit4, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > xLimit4)
            {
                transform.position = new Vector3(xLimit4, transform.position.y, transform.position.z);
            }
            if (transform.position.z > zLimit2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zLimit2);
            }
        }
        Jumpplayer();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpInit = 0;
        }
    }
    private void Jumpplayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpInit < 1)
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            jumpcount++;
            jumpInit++;
            Debug.Log("jump count : " + jumpcount);
        }
    }

}
