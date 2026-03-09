using UnityEngine;
using UnityEngine.SceneManagement; // uses unity's scene management tools

public class Pausemenu : MonoBehaviour
{
    [SerializeField] GameObject pause_menu; // this is the visual pause menu on the player's screen

    public void Pause()
    {
        pause_menu.SetActive(true); // opens the pause menu
        Time.timeScale = 0; // freezes the game
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu"); // returns the player to the main menu
        Time.timeScale = 1; // gameplay unfreezes
    }

    public void Resume()
    {
        pause_menu.SetActive(false); // closes the pause menu
        Time.timeScale = 1; // gameplay unfreezes
    }

}
