using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    Vector3 cameraOffset = new(0, 3, -10f);

    float timeSmoothing = 0.25f;

    Vector3 velocity = Vector3.zero;

    [SerializeField]
    Transform player;
        void Start()
    {
        Application.targetFrameRate = 120;
    }

    void LateUpdate(){
        Vector3 playerPosition = player.position + cameraOffset;
        
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, timeSmoothing);
    }
}
