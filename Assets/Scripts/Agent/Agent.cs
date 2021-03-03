using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public float trueMaxSpeed;
    public float maxAccel = 30.0f;

    public float orentation;
    public float rotation;
    public Vector3 velocity;

    protected Steering steer;

    public float maxRotation = 45.0f;
    public float maxAngularAccel = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        steer = new Steering();
        trueMaxSpeed = maxSpeed;
        
    }

    public void SetSteering(Steering steer, float weight)
    {
        this.steer.linear += (weight * steer.linear);
        this.steer.angular += (weight * steer.angular);
    }

    // changing the transfrom based off of the last frame of steering
    public virtual void Update()
    {
        Vector3 displacement = velocity * Time.deltaTime;
        displacement.y = 0;

        orentation += rotation * Time.deltaTime;

        //limit the orentation to 0 - 360
        if (orentation < 0.0f)
        {
            orentation += 360.0f;
        }
        else if (orentation > 360.0f)
        {
            orentation -= 360.0f;
        }

        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orentation);
    }

    // Updating movement for the next frame
    public virtual void LateUpdate()
    {
        velocity += steer.linear * Time.deltaTime;
        rotation += steer.angular * Time.deltaTime;
        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }

        if (steer.linear.magnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }

        steer = new Steering();
    }

    public void SpeedReset()
    {
        maxSpeed = trueMaxSpeed;
    }
}
