using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public int gameTime = 60;
    private bool coroutineStop = true;
    public GameObject highScoreText,scoreText,timeText;
    public Spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(highScore < score)
        {
            highScore = score;
        }

        highScoreText.GetComponent<TMP_Text>().SetText("HighScore: " + highScore);
        scoreText.GetComponent<TMP_Text>().SetText("Score: " + score);
        timeText.GetComponent<TMP_Text>().SetText("Time Left: " + gameTime);

        if(gameTime <= 0)
        {
            coroutineStop = false;
            spawner.instantiateBalls = false;
            
        }
    }

    IEnumerator TimeCoroutine()
    {
        while(coroutineStop == true)
        {
            yield return new WaitForSeconds(1f);
            gameTime--;
        }
    }
}
