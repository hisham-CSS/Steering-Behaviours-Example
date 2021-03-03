using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering
{
    public float angular; //rotation in degrees
    public Vector3 linear; //instatanious velocity

    public Steering()
    {
        angular = 0.0f;
        linear = new Vector3();
    }

}
