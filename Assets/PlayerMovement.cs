using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed = 3;

    [SerializeField]
    float cubeSize;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float groundRadius = 0.005f;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    Vector2 flightForce = new(0, 0.5f);

    [SerializeField]
    Vector2 jumpForce = new(0, 5f);

    [SerializeField]
    float flightMeter = 5f;

    public bool facingRight = true;

    float moveX;

    bool canFly = true;

    bool canJump = false;

    void Start()
    {
    }

    void Update(){
        moveX = Input.GetAxisRaw("Horizontal");

        if (moveX > 0 && !facingRight){
            Flip();
        }
        if (moveX < 0 && facingRight){
            Flip();
        }

        Vector3 cubeSize = makeGroundCheckSize();

        bool Grounded = Physics2D.OverlapBox(groundCheck.position, cubeSize, 0);

        //something about this breaks jumping and flight, will fix later
        if (Grounded == true){
            canFly = false;
            canJump = true;
        }
        else if (flightMeter > 0 && Grounded == false){
            canFly = true;
            canJump = false;
        }
        else{
            canJump = false;
            canJump = false;
        }

        if (Input.GetButtonDown("Jump") && canJump == true){
            rb.AddForce(jumpForce);
        }

        if (Input.GetButton("Jump") && canFly == true){
            rb.AddForce(flightForce);
            flightMeter -= 1*Time.deltaTime;
            Debug.Log(flightMeter);
        }

        Vector2 movement = new(moveX, 0);

        transform.Translate(movement * speed * Time.deltaTime);
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    private Vector3 makeGroundCheckSize() => new(cubeSize, groundRadius);

    private void OnDrawGizmos() {
        Gizmos.color = Color.grey;
        Vector3 cubeSize = makeGroundCheckSize();
        Gizmos.DrawWireCube(groundCheck.position, cubeSize);
    }
}
