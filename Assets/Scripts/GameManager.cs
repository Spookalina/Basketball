using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;
    public int gameTime = 2;
    private bool coroutineStop = true;
    public GameObject highScoreText,scoreText,timeText,spacebar;
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
            spacebar.SetActive(true);
            coroutineStop = false;
            spawner.instantiateBalls = false;
            if(Input.GetKey(KeyCode.Space))
            {
                spacebar.SetActive(false);
                gameTime = 60;
                score = 0;
                coroutineStop = true;
                spawner.instantiateBalls = true;
                StartCoroutine(TimeCoroutine());
                StartCoroutine(spawner.InstantiateBalls());
            }
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
