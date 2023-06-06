using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Swap1 : MonoBehaviour
{
    public float timer = 0.0f;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;

    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetButtonDown("VERDE0") && timer >= 20)
            SceneManager.LoadScene("Fase2", LoadSceneMode.Single);

        timer += Time.deltaTime;

        if (timer >= 8.0f)
        {
            frame1.SetActive(false);
            frame2.SetActive(false);
            frame3.SetActive(true);

            if (timer >= 20.0f)
            {
                frame3.SetActive(false);
                frame4.SetActive(true);
            }
        }
    }
}
