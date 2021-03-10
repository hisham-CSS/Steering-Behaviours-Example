using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperation : Flee
{
    public float desiredSeperation = 5.0f;
    public List<GameObject> targets;

    public override Steering GetSteering()
    {
        Steering steer = new Steering();
        
        foreach (GameObject other in targets)
        {
            if (other != null)
            {
                float d = (transform.position - other.transform.position).magnitude;

                if ((d > 0) && (d < desiredSeperation))
                {
                    //get a vector pointing away from my neighbouring object
                    Vector3 reposition = (transform.position - other.transform.position).normalized;
                    reposition /= d;
                    steer.linear += reposition;
                }
            }
        }

        return steer;
    }


}
 


