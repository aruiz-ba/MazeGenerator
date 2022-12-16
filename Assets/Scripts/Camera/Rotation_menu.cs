using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_menu : MonoBehaviour
{
    public float degreesPerSec = 360f;

    //Rotates the maze behind the menu
    void Update()
    {
        float rotAmount = degreesPerSec * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.y;
        transform.localRotation = Quaternion.Euler(new Vector3(90, curRot+rotAmount, 0));        
    }
}
