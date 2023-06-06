using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Introducao : MonoBehaviour
{
    public float timer = 0.0f;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;


    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetButtonDown("VERDE0") && timer >= 30)
            SceneManager.LoadScene("Fase0", LoadSceneMode.Single);

        timer += Time.deltaTime;

        if(timer >= 15.0f)
        {
            frame1.SetActive(false);
            frame2.SetActive(true);

            if (timer >= 30.0f)
            {
                frame2.SetActive(false);
                frame3.SetActive(true);
            }
        }
    }
}
