using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

    public GameObject player;
    private Vector3 speed = Vector3.zero;
    public float smoothTime = 0.9f;

    private void LateUpdate()
    {
        Vector3 newPos = Vector3.SmoothDamp(this.gameObject.transform.position, Camera.main.transform.position, ref speed, smoothTime);
        transform.position = newPos;
    }
}