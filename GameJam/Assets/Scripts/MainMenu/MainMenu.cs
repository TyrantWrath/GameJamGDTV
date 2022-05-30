using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadingNextScene()
    {
        SceneManager.LoadScene("Level1");

    }
    public void LoadLevel1UnlimitedHealth()
    {
        SceneManager.LoadScene("UnlimitedHealth");

    }
    public void LoadingCreditScene()
    {
        SceneManager.LoadScene("CreditScene");
    }
    public void LoadingMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
