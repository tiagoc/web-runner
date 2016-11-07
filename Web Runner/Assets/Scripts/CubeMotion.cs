using UnityEngine;
using System.Collections;

public class CubeMotion : MonoBehaviour {

    public static float fallingSpeed;
    private Rigidbody rb;


    void Start()
    {
        fallingSpeed = -5;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        /*float moveHorizontal = 1;

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);

        rb.AddForce(movement * fallingSpeed);*/
        rb.transform.Translate(0,0,fallingSpeed)

        /*if (rb.position.z < -50)
            Destroy(rb.gameObject);*/
    }
}
