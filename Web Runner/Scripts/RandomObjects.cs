using UnityEngine;
using System.Collections;

public class RandomObjects : MonoBehaviour {

    // Use this for initialization
    int i, randomInterval;
    int minX, minY, minZ;
    int maxX, maxY, maxZ;
    int x, y, z;
    void Start () {
		i = 0;
        randomInterval = 2;
		minX = 0;
		minY = 0;
		minZ = 0;
		maxX = 10;
		maxY = 10;
		maxZ = 10;
	}
	
	// Update is called once per frame
	void Update () {
        i++;
		if (i == randomInterval * 60) {
			i = 0;
            randomInterval = Random.Range(1, 5);
            x = Random.Range(minX, maxX);
            y = Random.Range(minY, maxY);
            z = Random.Range(minZ, maxZ);
            transform.position = new Vector3(x, y, z);
			Instantiate(gameObject, transform);
		}
	}
}
