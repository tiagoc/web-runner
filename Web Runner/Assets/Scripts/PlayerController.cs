using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
    public Text scoreText;
    public Text healthText;
    public static bool enableObstacles = true;
    public static float powerUpTime;
    private int countScore;
    private int health;
    private Rigidbody rb;
    public AudioClip impact;
    private new AudioSource audio;

    void Start (){
		rb = GetComponent<Rigidbody>();
        countScore = 0;
        health = 100;
        SetCountText();
        audio = GetComponent<AudioSource>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
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
        healthText.text = "HP: " + health.ToString();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 9)
        {
            audio.PlayOneShot(impact, 0.9F);

            int newHighscore = this.countScore;
            int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
            if (newHighscore > oldHighscore)
                PlayerPrefs.SetInt("highscore", newHighscore);

            health -= 25;
            countScore -= 150;

            if (health <= 0)
                SceneManager.LoadScene("main_menu");
        }
        else if (col.gameObject.layer == 10)
        {
            health += 15;
            countScore += 42;
        }
        else if (col.gameObject.layer == 11)
        {
            enableObstacles = false;
            powerUpTime = Time.time;
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