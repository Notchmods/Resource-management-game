using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscripts : MonoBehaviour
{
    //Go to the game scene once the Play button is clicked
    public void Playgame()
    {
        SceneManager.LoadScene(1);
    }

    public void Loadgame()
    {
        SceneManager.LoadScene(2);
    }

    //Exit the button function, makes the game quit
    public void Exit()
    {
        Application.Quit();
    }
        
}
