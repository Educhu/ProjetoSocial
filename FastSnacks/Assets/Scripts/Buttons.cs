using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public void GoToScene1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void GoToScene2()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void GoToIntroduction()
    {
        SceneManager.LoadScene("Introducao");
    }

    public void OnButtonExit()
    {
        Application.Quit();
    }
}
