using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Emitter : MonoBehaviour
{
    
    public GameObject objectToEmit;
    public float timeBetweenEmits;
    public bool emitting;
    private float nextEmitTime;
    public GameObject emitterContainer;
    public bool debugging = false;
    
    // Start is called before the first frame update
    
    void Start()
    {
        nextEmitTime = Time.time + timeBetweenEmits;
    }

    // Update is called once per frame
    void Update()
    {
        emitting = SteamVR_Actions._default.GrabPinch.state;
        if (emitting || debugging)
        {
            if(nextEmitTime <= Time.time)
            {
                GameObject go = Instantiate(objectToEmit, emitterContainer.transform);
                //                go.GetComponent<EmittedObject>().;
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
                go.GetComponent<Rigidbody>().velocity = transform.forward * 5f;
                if (!debugging)
                {
                    go.GetComponent<EmittedObject>().force = SteamVR_Actions._default.BlowAir.GetAxis(SteamVR_Input_Sources.RightHand) * 50f;
                    //between 0 and 1, currently .2

                    timeBetweenEmits = 1 - SteamVR_Actions._default.BlowAir.GetAxis(SteamVR_Input_Sources.RightHand);
                    if(timeBetweenEmits < .02)
                    {
                        timeBetweenEmits = .02f;
                    }
                }
                    Debug.Log("Time Between Emits: " + timeBetweenEmits);

                nextEmitTime = Time.time + timeBetweenEmits;
            }
        }
    }
    public void TriggerToggle()
    {
        emitting = !emitting;
    }
}
