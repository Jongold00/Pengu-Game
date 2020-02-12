using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 10;
    public float slideSpeed = 100;
    public float jumpPow = 10f;
    public float swimSpeed = 7;
    public float maxSwimSpeed = 5f;
    public float maxVel = 8;
    public Rigidbody2D rgdb;
    bool underWater = false;
    bool canJump = true;
    private bool sliding;
    // Start is called before the first frame update
    void Start()
    {
        sliding = false;
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
            rgdb.velocity = new Vector2(rgdb.velocity.x, rgdb.velocity.y - .02f);
            Vector2.ClampMagnitude(rgdb.velocity, maxSwimSpeed);

        }
        else {
            rgdb.velocity = Vector2.ClampMagnitude(rgdb.velocity, maxVel);
            sliding = Input.GetKey(KeyCode.S);
            if (sliding) {
                rgdb.AddForce(Vector2.right * x * slideSpeed);
                
            }
            else {
                //transform.Translate(new Vector2(x * walkSpeed/10 * Time.deltaTime, y));
                rgdb.velocity = new Vector2(x * walkSpeed * Time.deltaTime, rgdb.velocity.y);
            }
            
        }




    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ocean")) {
            rgdb.velocity = new Vector2(rgdb.velocity.x, rgdb.velocity.x * .5f);
            rgdb.gravityScale = 0f;
            underWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ocean")) {
            rgdb.gravityScale = 1f;
            underWater = false;
        }
    }


    private void delayGrav() {
        rgdb.gravityScale = 1f;
    }
}
