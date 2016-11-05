using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menu_script : MonoBehaviour {
    
    public Button startText;
    public Button exitText;
    public Button tutorialText;
    public Text highscoreText;

    // Use this for initialization
    void Start () {

        SetCountText();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        tutorialText = tutorialText.GetComponent<Button>();
    }

    

    public void StartRun()
    {
        SceneManager.LoadScene("default");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
        SetCountText();
    }

    void SetCountText()
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "High Score: " + highscore.ToString();
    }
}
