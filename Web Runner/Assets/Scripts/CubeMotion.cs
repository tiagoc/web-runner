using UnityEngine;
using System.Collections;

public class CubeMotion : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = 1;

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);

        rb.AddForce(movement * speed);

        /*if (rb.position.z < -50)
            Destroy(rb.gameObject);*/
    }
}
