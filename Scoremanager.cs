using UnityEngine;
using UnityEngine.UI; // uses unity's legacy UI system

public class Scoremanager : MonoBehaviour
{

    public static Scoremanager instance; // creates a reference to the script that can be called globally

    public Text scoreText; // this is text that will be displayed on the player's screen
    public Text highscoreText; // this is also text that will be displayed on the player's screen

    int score = 0; // stores the score
    int highscore = 0; // stores the player's highscore

    private void Awake()
    {
        instance = this; // assigns the script to the global shortcut
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0); // checks if there is a saved highscore, default value is 0
        scoreText.text = "Score : " + score.ToString() + " POINTS"; // converts score to string and carries out string concatenation
        highscoreText.text = "Highscore : " + highscore.ToString() + " POINTS"; // converts highscore to string and carries out string concatenation

    }

    public void Addpoint()
    {
        score += 1; // score increments by 1
        scoreText.text = "Score : " + score.ToString() + " POINTS"; // converts score to string and carries out string concatenation
        if (highscore < score) // checks if high score is less than score
            PlayerPrefs.SetInt("highscore", score); // saves the current score as the new highscore
    }

}
