using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadLeader : MonoBehaviour
{
    public GameObject target;
    public GameObject childPrefab;
    public List<GameObject> children;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<GameObject>();

        for (int i = 0; i < 12; i++)
        {
            Vector3 relativeSpawn = new Vector3(i % 4, 0.5f, i / 4);
            GameObject temp = Instantiate(childPrefab, transform.position + (relativeSpawn * 6.0f), transform.rotation);
            temp.GetComponent<StateMachine>().target = gameObject;
            children.Add(temp);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target.transform.position - transform.position).normalized * Time.deltaTime * 5.0f;
    }
}
