using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5;

    public bool facingRight = true;

    void Start()
    {
        
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        Vector2 movement = new(moveX, 0);

        if (transform.position.x > -10){
            transform.Translate(movement * speed);
        }
        if (transform.position.x <= -10){
            transform.Translate(0.01f, 0, 0);
        }

        if (moveX > 0 && !facingRight){
            Flip();
        }
        if (moveX < 0 && facingRight){
            Flip();
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
