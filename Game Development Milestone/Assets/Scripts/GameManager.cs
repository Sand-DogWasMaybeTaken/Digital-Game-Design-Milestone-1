using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //variables//
    public GameObject player;
    public GameObject collectable;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    public int score;
    private int IngameTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //set the score to 0//
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //updates the time on the ui//
        timeText.text = "Time: " + IngameTime;
        IngameTime = (int)Time.timeSinceLevelLoad;
        //updates the score on the ui//
        if (score >= 0)
        {
            scoreText.text = "Score: " + score;
        }
        if (score >= 6)
        {
            scoreText.color = Color.gold;
        }
        else
        {
            scoreText.color = Color.silver;
        }
        // if the score is less than 0, set the score to 0//
        if (score < 0)
        {
            score = 0;
        }
        if (score >= 10)
        {
            endGame();
        }
    }

    public void endGame()
    {
        SceneManager.LoadScene("Win");
    }
    //function to respawn the collectable after being picked up by the player//
    public void Respawn()
    {
        //spawn a collectable at a random position//
        Instantiate(collectable, new Vector2(Random.Range(-8, 8), Random.Range(-3, 3)), collectable.transform.rotation);
    }
    public void RespawnPlayer()
    {
        //spawn the player at the starting position//
        player.transform.position = new Vector2(0, 0);
    }
}
