using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public int positionDestroy = -7;
    public int timesBounced = 0;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.y < positionDestroy)
        {
            Destroy(this.gameObject);
        }

        if(timesBounced >= 3)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor"))
        {
            timesBounced ++;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Goal"))
        {
            gameManager.score += 10;
            Destroy(this.gameObject);
        }
    }
}
