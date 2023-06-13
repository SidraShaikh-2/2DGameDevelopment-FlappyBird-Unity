using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource pointAdd;
    public AudioSource die;
    public GameObject Bird;

    public float deadZone = -13;

    

    void Update(){
        
        Vector3 objectPosition = Bird.transform.position;
        Debug.Log("Bird position: " + objectPosition);
        
        if (objectPosition.y < deadZone)
        {
            gameOver();
        }
    }
 
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameOverScreen.activeSelf)
        {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        pointAdd.Play(0);
        }


    }
 
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    public void gameOver()
    {
        
  
            gameOverScreen.SetActive(true);
            die.Play(0);

        
    }

    public void goBack()
    {
        SceneManager.LoadScene(0);
    }



}