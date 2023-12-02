using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed;

    public bool facingRight = true;

    float moveX;

    void Start()
    {
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * speed;

        if (moveX > 0 && !facingRight){
            Flip();
        }
        if (moveX < 0 && facingRight){
            Flip();
        }
    }

    void FixedUpdate(){
        rb.velocity = new(moveX * speed, rb.velocity.y);
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
