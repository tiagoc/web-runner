using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
    public Text scoreText;
	private Rigidbody rb;
    private int countScore;
    public new AudioSource audio;

    void Start (){
		rb = GetComponent<Rigidbody>();
        countScore = 0;
        SetCountText();
    }

	void FixedUpdate (){
        float LeftRight = 0;

        if (Input.touchCount > 0)
        {
            // touch x position is bigger than half of the screen, moving right
            if (Input.GetTouch(0).position.x > Screen.width / 2)
                LeftRight = -speed;
            // touch x position is smaller than half of the screen, moving left
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
                LeftRight = speed;
        }

        LeftRight -= Input.acceleration.x * 6;

        //Vector3 Movement = new Vector3(LeftRight, 0, 0);
        //rb.AddForce(Movement * speed);

        rb.transform.Translate((float) 2.3, (float) 3.93, 0);
        rb.transform.Rotate(0f, 0f, LeftRight);
        rb.transform.Translate(- (float) 2.3, - (float) 3.93, 0);

        countScore++;
        SetCountText();
    }

    void SetCountText()
    {
        scoreText.text = "Score: " + countScore.ToString();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Finish") 
        {
            int newHighscore = this.countScore;
            int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
            if (newHighscore > oldHighscore)
                PlayerPrefs.SetInt("highscore", newHighscore);
            audio.Play();
            audio.Play(44100);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("main_menu");
        }
    }

}