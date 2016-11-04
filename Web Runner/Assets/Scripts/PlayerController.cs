﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	void Start (){
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate (){
        float LeftRight = 0;

        if (Input.touchCount > 0)
        {
            // touch x position is bigger than half of the screen, moving right
            if (Input.GetTouch(0).position.x > Screen.width / 2)
                LeftRight = 1;
            // touch x position is smaller than half of the screen, moving left
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
                LeftRight = -1;
        }

        Vector3 Movement = new Vector3(LeftRight, 0, 0);

        //rb.AddForce(Movement * speed);

        rb.transform.Rotate(0f, 0f, 0f);
    }
}