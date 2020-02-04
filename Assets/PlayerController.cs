using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 10;
    public float jumpPow = 10f;
    public float swimSpeed = 15;
    public float maxSwimSpeed = 5f;
    public Rigidbody2D rgdb;
    bool underWater = false;
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (underWater) {
            Vector2 waterVelocity = new Vector2(x, y) * swimSpeed * Time.deltaTime;
            

            //rgdb.velocity = (waterVelocity);
            rgdb.AddForce(waterVelocity);
            Vector2.ClampMagnitude(rgdb.velocity, maxSwimSpeed);

        }
        else {
            Debug.Log(x);
            transform.Translate(Vector2.right * x * walkSpeed * Time.deltaTime);
            //rgdb.velocity = (Vector2.right * x * walkSpeed * Time.deltaTime);
        }




    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ocean")) {
            rgdb.gravityScale = .1f;
            underWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ocean")) {
            rgdb.gravityScale = 1f;
            underWater = true;
        }
    }
}
