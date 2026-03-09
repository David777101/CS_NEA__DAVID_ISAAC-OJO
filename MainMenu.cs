using UnityEngine;
using UnityEngine.SceneManagement; // uses unity's scene management toolkit

public class MainMenu : MonoBehaviour
{
    
    public void PlayTheGame()
    {
        SceneManager.LoadSceneAsync("Gameplay"); // Loads the gameplay scene
    }

    public void ExitTheGame()
    {
        Application.Quit(); // shuts the game down
    }

}
