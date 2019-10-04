using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{

    public GameObject objectToEmit;
    public float timeBetweenEmits;
    public bool emitting;
    private float nextEmitTime;
    // Start is called before the first frame update
    
    void Start()
    {
        nextEmitTime = Time.time + timeBetweenEmits;
    }

    // Update is called once per frame
    void Update()
    {
        if(emitting)
        {
            if(nextEmitTime <= Time.time)
            {
                GameObject go = Instantiate(objectToEmit, transform);
                //                go.GetComponent<EmittedObject>().;
                nextEmitTime = Time.time + timeBetweenEmits;
            }
        }
    }
    public void TriggerToggle()
    {
        emitting = !emitting;
    }
}
