using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

    public GameObject player; //assign this in the editor or find it in the start function.
    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        this.gameObject.transform.position = Vector3.SmoothDamp(this.gameObject.transform.position, Camera.main.transform.position, ref _velocity, 0.5f);
        //change the last value to the time you want to complete the movement.
    }
}
