using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum UnitStates
    {
        Idle,
        Flee,
        Seek
    }

    public Agent agentScript;

    public Seek seekScript;
    public Flee fleeScript;

    public float maxSpeed;

    public GameObject target;

    public UnitStates currentState;


    // Start is called before the first frame update
    void Start()
    {
        agentScript = gameObject.AddComponent<Agent>();

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentState)
            {
                case UnitStates.Idle:
                    ChangeState(UnitStates.Flee);
                    break;
                case UnitStates.Flee:
                    ChangeState(UnitStates.Seek);
                    break;
                case UnitStates.Seek:
                    ChangeState(UnitStates.Idle);
                    break;

            }
        }
    }


    public void ChangeState(UnitStates newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case UnitStates.Idle:
                DestroyImmediate(fleeScript);
                DestroyImmediate(seekScript);
                break;
            case UnitStates.Flee:
                fleeScript = gameObject.AddComponent<Flee>();
                fleeScript.target = target;
                fleeScript.enabled = true;
                DestroyImmediate(seekScript);
                break;
            case UnitStates.Seek:
                seekScript = gameObject.AddComponent<Seek>();
                seekScript.target = target;
                seekScript.enabled = true;
                DestroyImmediate(fleeScript);
                break;
        }
    }
}
