using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDelete : MonoBehaviour
{
    [SerializeField]
    GameObject ZTutorial;

    [SerializeField]
    GameObject XTutorial;

    void Start()
    {
        XTutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            ZTutorial.SetActive(false);
            XTutorial.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.X)){
            ZTutorial.SetActive(true);
            XTutorial.SetActive(false);
        }
    }
}
