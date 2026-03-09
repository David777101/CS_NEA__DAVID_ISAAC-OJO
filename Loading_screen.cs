using UnityEngine;
using UnityEngine.SceneManagement; // uses unity's scene management tools

public class Loading_screen : MonoBehaviour
{

    public void LoadTheGame()
    {
        SceneManager.LoadScene("MainMenu"); // loads the main menu
    }

}
