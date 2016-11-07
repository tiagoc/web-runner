using UnityEngine;
using System.Collections;

public class PowerUpRotation : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private float startTime;


    void Start()
    {
        startTime = Time.time;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.transform.Translate(0, 0, Mathf.Sin((Time.time - startTime) * 1.5f *speed) / 10);
        rb.transform.Rotate(0, 0, speed);
    }
}
