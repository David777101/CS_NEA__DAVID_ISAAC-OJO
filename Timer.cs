using UnityEngine;
using TMPro; // uses TextMeshPro
using UnityEngine.UI; // uses unity's legacy UI system

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText; // outputs the time text on the player's screen
    [SerializeField] float remTime; // creates an input field for the remaining time
    
    public GameOverScreen GameOverScreen; // reference to the game object that has the GameOverScreen script
    public float score;

    // Update is called once per frame
    void Update()
    {
        if (remTime > 0) // checks if the remaining time is greater than 0
        {
            remTime -= Time.deltaTime; // continues decrementing remaining time
        }
        else if (remTime < 0) // checks if the remaining time is less than 0
        {
            remTime = 0; // sets remaining time to 0
            GameOver(); // calls the GameOver() function
            timerText.color = Color.red; // changes the colour of the time text to red
        }
        
        int minutes = Mathf.FloorToInt(remTime / 60); // calculates minutes
        int seconds = Mathf.FloorToInt(remTime % 60); // calculates seconds
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // converts the minutes and seconds to string and puts them in the 00:00 format
    }

    public void GameOver()
    {
        GameOverScreen.Setup(score); // carries out the GameOverScreen Setup logic which opens the end of game screen
        Time.timeScale = 0; // freezes the game
    }
}
