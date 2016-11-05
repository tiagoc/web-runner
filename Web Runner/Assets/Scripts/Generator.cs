using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

    public GameObject obstacle;
    int i, imax, cubeAmmount;
    private float startTime, elapsedTime;
    // Use this for initialization
    void Start () {
        i = 0;
        startTime = Time.time;
        imax = Random.Range(20, 50);
        cubeAmmount = Random.Range(1 / 60, 2 / 20);
        PlaceCubes();
	}

    void PlaceCubes()
    {
        for (int i = 0; i < cubeAmmount; i++)
        {
            float angle = Random.Range(0, 360);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            float x, y;
            x = 4 * Mathf.Cos(angle * Mathf.PI / 180);
            y = 4 * Mathf.Sin(angle * Mathf.PI / 180);
            Vector3 position = new Vector3(x - (float) 2.3, y, 280);

            Instantiate(obstacle, position, rotation);
        }
    }

    // Update is called once per frame
    void Update () {

        elapsedTime = Time.time - startTime;
        i++;
        if (i > imax)
        {
            i = 0;
            imax = Random.Range(20 - (int)elapsedTime / 60, 50 - (int)elapsedTime / 60);
            cubeAmmount = Random.Range(1 + (int)elapsedTime / 60, 2 + (int)elapsedTime / 20);
            PlaceCubes();
        }
	}
}
