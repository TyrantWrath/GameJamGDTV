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
    public void LoadingCreditScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
