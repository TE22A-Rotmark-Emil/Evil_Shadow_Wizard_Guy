using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.EditorTools;
using UnityEngine;

public class Character_Selection : MonoBehaviour
{
    Transform theMan;

    float floatValue;

    [SerializeField]
    float floatValueValue;

    Renderer manColor;

    float LerpValue;

    bool isSelected;

    [SerializeField]
    float ColorReal;

    [SerializeField]
    Color initialColor;
    
    // Start is called before the first frame update
    void Start()
    {
        theMan = GetComponent<Transform>();
        manColor = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        floatValue = floatValueValue * Time.deltaTime;
        LerpValue = LerpC(3, theMan.transform.localScale.magnitude, 2);
        manColor.material.color = Color.Lerp(initialColor, Color.white, LerpValue);
        if (Input.GetKeyDown(KeyCode.Z) && isSelected == false){
            isSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.X)){
            isSelected = false;
        }
        if (isSelected == true){
            CharacterIsSelected();
        }
        if (theMan.transform.localScale.sqrMagnitude > 3 && isSelected == false){
            theMan.transform.localScale += new Vector3(-floatValue, -floatValue, 0);
        }
        if (Input.GetKeyDown(KeyCode.Z) && theMan.transform.localScale.sqrMagnitude >= 4 && isSelected == true){
            Debug.Log("kowabunga let's go");
        }
    }

    void CharacterIsSelected(){
        if (theMan.transform.localScale.sqrMagnitude < 4){
            theMan.transform.localScale += new Vector3(floatValue, floatValue, 0);
        }
    }

    float LerpC(float Float1, float Float2, float Value){
        return Float1 * (1-Value) + Float2 * Value;
    }
}
