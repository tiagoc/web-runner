using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

    public GameObject obstacle;
    public int distMin, distMax, densMin, densMax, mult;
    public float radius;
    public Material[] materials;
    int i, imax, cubeAmmount;
    private float startTime, elapsedTime;
    // Use this for initialization
    void Start () {
        i = 0;
        startTime = Time.time;
        imax = Random.Range(distMin, distMax);
        cubeAmmount = Random.Range(densMin, densMax);
        PlaceCubes();
	}

    void PlaceCubes()
    {
        if (mult == -1 || (PlayerController.enableObstacles && mult == 1))
            for (int i = 0; i < cubeAmmount; i++)
            {
                float angle = Random.Range(0, 360);
                Quaternion rotation;
                if (obstacle.layer == 10)
                    rotation = Quaternion.Euler(180 - angle, 90, 0);
                else if (obstacle.layer == 11)
                {
                    rotation = Quaternion.Euler(90, 0, 0);
                    rotation *= Quaternion.Euler(0, angle - 90, 0);
                }
                else
                    rotation = Quaternion.Euler(0, 0, angle);
                float x, y;
                x = radius * Mathf.Cos(angle * Mathf.PI / 180);
                y = radius * Mathf.Sin(angle * Mathf.PI / 180);
                Vector3 position = new Vector3(x - (float) 2.3, y, 280);

                obstacle.GetComponent<Renderer>().sharedMaterial = materials[Random.Range(0, materials.Length)];
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
            imax = Random.Range(distMin - mult * (int)elapsedTime / 60, distMax - mult * (int)elapsedTime / 60);
            cubeAmmount = Random.Range(densMin + mult * (int)elapsedTime / 60, densMax + mult * (int)elapsedTime / 20);
            if (cubeAmmount < 1)
                cubeAmmount = 1;
            PlaceCubes();
        }
        if (Time.time - PlayerController.powerUpTime >= 10)
            PlayerController.enableObstacles = true;

    }
}
