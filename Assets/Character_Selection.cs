using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.EditorTools;
using UnityEngine;

public class Character_Selection : MonoBehaviour
{
    Transform theMan;

    Renderer manColor;

    float LerpValue;

    Color theColorWhichManWants;

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
        LerpValue = LerpC(1, 3/theMan.transform.localScale.sqrMagnitude, 1);
        manColor.material.color = Color.Lerp(Color.white, initialColor, LerpValue);
        if (Input.GetKeyDown(KeyCode.Z)){
            isSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.X)){
            isSelected = false;
        }
        if (isSelected == true){
            CharacterIsSelected();
        }
        if (theMan.transform.localScale.sqrMagnitude > 3 && isSelected == false){
            theMan.transform.localScale += new Vector3(-0.003f, -0.003f, 0);
        }
    }

    void CharacterIsSelected(){
        if (theMan.transform.localScale.sqrMagnitude < 4){
            theMan.transform.localScale += new Vector3(0.003f, 0.003f, 0);
        }
    }

    float LerpC(float Float1, float Float2, float Value){
        return Float1 * (1-Value) + Float2 * Value;
    }
}
