using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float speed = 0f;
    float yspeed = 0f;
    float mass = 20f;
    float force = 500f;
    float acceleration;
    float gAcceleration;
    float drag = 1f;
    float gravity = -9.8f;
 

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed = acceleration * 1;
        gAcceleration = gravity / mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed *= (1-Time.deltaTime * drag);
        yspeed += gAcceleration * Time.deltaTime;
        transform.Translate(0, yspeed, Time.deltaTime * speed);
    }
}
