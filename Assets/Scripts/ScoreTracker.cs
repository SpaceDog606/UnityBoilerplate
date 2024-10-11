using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreTracker : MonoBehaviour
{
    public int score;
    public int storedScore;
    public int neededScore;
    public Text scoreText;
    public TextMeshPro storedScoreText;
    public TextMeshPro neededScoreText;
    public TextMeshPro winner;
    public int frameTracker;
    public GameObject inactiveFountain;
    public GameObject activeFountain;
    public bool deadPlayer;
    public bool dying;
    public GameObject deathAnimation;
    public GameObject deathCam;
    public GameObject player;
    public GameObject animation1;
    public GameObject animation2;
    public GameObject animation3;
    public GameObject animation4;
    public GameObject animation5;
    public GameObject camera;
    public int winTimer;
    public bool gameWon;


    // Start is called before the first frame update
    void Start()
    {
        deadPlayer = false;
        dying = false;
        addScore();
        storedScoreText.text = "0 / " + neededScore.ToString();
        frameTracker = 0;
        deathCam.SetActive(false);
        gameWon = false;
        winTimer = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (gameWon)
        {
            winTimer++;
        }
        if (winTimer >= 2000)
        {
            SceneManager.LoadScene(0);
        }
        frameTracker++;
        if (frameTracker >= 5000)
        {
            frameTracker = 0;
        }
        if (deadPlayer && dying)
        {
            frameTracker = 0;
            dying = false;
            deathCam.SetActive(true);
            if ((animation1.GetComponent<SpriteRenderer>().flipX == true))
            {
                deathAnimation.GetComponent<SpriteRenderer>().flipX = true;
            }
            Instantiate(deathAnimation, transform.position, transform.rotation);
            animation1.SetActive(false);
            animation2.SetActive(false);
            animation3.SetActive(false);
            animation4.SetActive(false);
            animation5.SetActive(false);
            camera.SetActive(false);
            deathCam.SetActive(false);
            Debug.Log("player dying");

            Debug.Log(deadPlayer);
        }
        if (frameTracker >= 1250 && deadPlayer) 
        {
            Debug.Log("Resetting...");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dropplet") && !deadPlayer)
        {
            Destroy(other.gameObject);
            addScore();
        }
        if (other.gameObject.CompareTag("Fountain") &&   (Input.GetKey("e")) && !deadPlayer)
        {
            if (frameTracker >= 5)
            {
                if (score > 0)
                {
                    subtractScore();
                    storedScore++;
                    storedScoreText.text = storedScore.ToString() + " / " + neededScore.ToString();
                }
                if (storedScore >= neededScore)
                {
                    storedScoreText.text = "you win!";
                    inactiveFountain.GetComponent<SpriteRenderer>().enabled = false;
                    activeFountain.GetComponent<SpriteRenderer>().enabled = true;
                    gameWon = true;
                }
                frameTracker = 0;
            }
        }
        if (other.gameObject.CompareTag("PlayerKiller"))
        {
            if (!deadPlayer)
            {
                deadPlayer = true;
                dying = true;
            }

        }
    }
    void addScore()
    {
        score++;
        scoreText.text = "Hallowed Drops: " + score.ToString();
    }
    void subtractScore()
    {
        score--;
        scoreText.text = "Hallowed Drops: " + score.ToString();
    }
    
}
