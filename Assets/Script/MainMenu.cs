using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StarGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("keluar");
        Application.Quit();
    }
}
