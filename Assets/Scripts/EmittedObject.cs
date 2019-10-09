using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmittedObject : MonoBehaviour
{
    public float lifeTime;
    public bool destroyOnContact;
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

        if (destroyOnContact)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * force;
        }
            if (lifeTime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destroyOnContact)
        {
            Destroy(this.gameObject,.1f);
        }
        }
}
