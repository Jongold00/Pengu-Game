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
        float maxVel = 14;
        rgdb.velocity = Vector2.ClampMagnitude(rgdb.velocity, maxVel);
        Vector2 waterVelocity = new Vector2(x, y) * swimSpeed * Time.deltaTime;
        if (underWater) {
            //Vector2 waterVelocity = new Vector2(x, y) * swimSpeed * Time.deltaTime;
            

            //rgdb.velocity = (waterVelocity);
            rgdb.AddForce(waterVelocity);
            Vector2.ClampMagnitude(rgdb.velocity, maxSwimSpeed);

        }
        else {
            sliding = Input.GetKey(KeyCode.S);
            Debug.Log(x);

            rgdb.velocity = Vector2.ClampMagnitude(rgdb.velocity, maxVel);
            if (sliding) {
                rgdb.AddForce(Vector2.right * x * slideSpeed);
                
            }
            else {
                rgdb.velocity = new Vector2(1 * x * walkSpeed * Time.deltaTime, rgdb.velocity.y);
            }
            
        }




    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ocean")) {
            rgdb.velocity = new Vector2(rgdb.velocity.x * .5f, rgdb.velocity.x * .5f);
            rgdb.gravityScale = .1f;
            underWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ocean")) {
            Invoke("delayGrav", 0f);
            underWater = false;
        }
    }


    private void delayGrav() {
        rgdb.gravityScale = 1f;
    }
}
