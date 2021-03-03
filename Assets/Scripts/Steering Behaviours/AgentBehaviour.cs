using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public float weight = 1.0f;

    public GameObject target;
    protected Agent agent;
    public Vector3 dest;

    public float maxSpeed = 50.0f;
    public float maxAccel = 50.0f;
    public float maxRotation = 5.0f;
    public float maxAngularAccel = 5.0f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        agent = gameObject.GetComponent<Agent>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        agent.SetSteering(GetSteering(), weight);
    }

    public virtual Steering GetSteering()
    {
        return new Steering();
    }
}
