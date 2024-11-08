using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 


public class Player : MonoBehaviour
{
    private float myTime = 0f;
    public TMP_Text timeText;
    public TMP_Text scoreText; 
    public TMP_Text timeText1;
    public TMP_Text scoreText1; 
    public TMP_Text bestText; 
    private Rigidbody2D rb;
    public int vyskaSkoku = 1;
    private bool gameOver;
    private int obstacleCount = 0;
    public static float gameTime;
    public static int gameScore;
    public GameObject PausePanel, Inventory, tapEffect;
    public static int Coin = 0;
    public static int CCoin = 0;
    public static int highestScore;
    

    void Start()
    {
        myTime = 0f;
        rb = GetComponent<Rigidbody2D>();
        gameOver = false;
        obstacleCount = 0;
        Coin = 0;
        
        UpdateScoreText();
    }

    void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex==0){
        if (!gameOver && Time.timeScale != 0)
        {
            Time.timeScale = 1;
            myTime = myTime + Time.deltaTime;
            timeText.text = "Time: " + myTime;
        }}if(currentSceneIndex==2){
            end();
        }if(currentSceneIndex==1){
            bestText.text = "Highest Score: " + highestScore;
        }
    }

    public void jump()
    {
        rb.AddForce(Vector2.up * vyskaSkoku, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.tag == "colizia")
    {
        gameOver = true;
        gameTime = myTime;
        gameScore = obstacleCount;
        CCoin = Coin;
        if (obstacleCount > highestScore) 
        {
            highestScore = obstacleCount;
        }
        SceneManager.LoadScene(2);
        Time.timeScale = 0;
    }
}


    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "obstacle") {
        obstacleCount++;
        if (obstacleCount > highestScore) {
            highestScore = obstacleCount;
        }
        Debug.Log("Obstacle count: " + obstacleCount);
        UpdateScoreText();
    }
    else if (other.gameObject.tag == "coin") {
        Coin++;
        obstacleCount += 5;
        if (obstacleCount > highestScore) {
            highestScore = obstacleCount;
        }
        UpdateScoreText();
        Destroy(other.gameObject);
    }
}


    void UpdateScoreText()
    {
        scoreText.text = "Score: " + obstacleCount;
    }
    public void end()
    {
        Time.timeScale = 1;
        scoreText1.text = "Score: " + gameScore + "\nHighest Score: " + highestScore + "\nCoin: " + CCoin;
        timeText1.text = "Time: " + gameTime.ToString("F2");
    }
    public void pause(){
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void repause(){
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        
    }
    public void restart(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
        
    }
    public void menu(){
        SceneManager.LoadScene(1);
    }
}
