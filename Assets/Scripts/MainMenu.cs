using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("FirstStage");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Lopetettiin peli");
    }
}