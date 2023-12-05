using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    Vector3 playerPosition;

    Vector3 cameraOffset = new(0, 3, -7f);

    float timeSmoothing = 0.25f;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Transform player;
    void Start()
    {
    }

    void LateUpdate(){
        playerPosition = player.position + cameraOffset;
        Vector3 playerPosY = new(0, player.position.y, 0);
        
        //add offset +2 -2 so the camera is not focused on the player and only follows them if the player moves outside of +2 -2
        if (playerPosition.x - cameraOffset.x > 2){
            
        }
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, timeSmoothing);
    }
}
