using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmittedObject : MonoBehaviour
{
    public float lifeTime;
    private float startTime;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        lifeTime = lifeTime + startTime;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * force;
        if(lifeTime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }
}
