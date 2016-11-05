using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class back : MonoBehaviour {

    public Button backText;
    // Use this for initialization
    void Start () {
        backText.GetComponent<Button>();
    }

    public void exitRun()
    {
        SceneManager.LoadScene("main_menu");
    }
    // Update is called once per frame
    void Update () {
	
	}
}
