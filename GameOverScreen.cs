using UnityEngine;
using UnityEngine.UI; // uses unity's legacy UI system
using UnityEngine.SceneManagement; // uses unity's scene management tools

public class GameOverScreen : MonoBehaviour
{

    public Text pointsText;

    public void Setup(float score)
    {
        gameObject.SetActive(true); // activates the end of game screen
        pointsText.text = score.ToString() + " POINTS"; // converts the score to string to be displayed on the end screen
    }

    public void RestartIcon()
    {
        SceneManager.LoadScene("Gameplay"); // loads the gameplay scene which restarts gameplay
        Time.timeScale = 1; // unfreezes the game
    }

    public void ExitIcon()
    {
        SceneManager.LoadScene("MainMenu"); // returns the player to the main menu
        Time.timeScale = 1; // unfreezes the game
    }
}