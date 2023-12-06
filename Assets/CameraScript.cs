using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    Vector3 playerPosition;

    Vector3 cameraOffset = new(0, 3, -7f);

    float timeSmoothing = 0.75f;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Transform player;
    void Start()
    {
    }

    void LateUpdate(){
        playerPosition = player.position + cameraOffset;
        
        //add offset +2 -2 so the camera is not focused on the player and only follows them if the player moves outside of +2 -2
        if (playerPosition.x - transform.position.x > 2 || player.position.x - transform.position.x < -2){
            transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, timeSmoothing);
        }
    }
}
