using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    
    void Update()
    {
        //Rotate propeller
        transform.Rotate(0, 0, 10);
    }
}
