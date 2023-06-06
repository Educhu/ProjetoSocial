using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Swap2 : MonoBehaviour
{
    public float timer = 0.0f;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 6.0f)
        {
            frame1.SetActive(false);
            frame2.SetActive(false);
            frame3.SetActive(true);

            if (timer >= 20.0f)
            {
                frame3.SetActive(false);
                frame4.SetActive(true);
                if(timer >= 45.0f)
                {
                    SceneManager.LoadScene("SceneFinal", LoadSceneMode.Single);
                }
            }
        }
    }
}
