using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CameraScript2 : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;

        float y = transform.position.y;

        if (transform.position.x > 6){
            transform.position = new(x, 6, 1);
        }
        if (transform.localScale.z < 1){
            transform.position = new(x, y, 1);
        }
    }
}
