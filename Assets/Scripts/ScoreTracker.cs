using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    // Start is called before the first frame update
    void Start()
    {
        addScore();
        storedScoreText.text = "0 / " + neededScore.ToString();
        frameTracker = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        frameTracker++;
        if (frameTracker >= 100)
        {
            frameTracker = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dropplet"))
        {
            Destroy(other.gameObject);
            addScore();
        }
        if (other.gameObject.CompareTag("Fountain") &&   (Input.GetKey("e")))
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
                }
                frameTracker = 0;
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
