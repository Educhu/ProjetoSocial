using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BalaoDeFala : MonoBehaviour
{
    public float timer = 0.0f;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;
    public GameObject frame5;
    public GameObject sapoTomate;


    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetKeyDown("space"))
        {
            sapoTomate.SetActive(true);
        }

        if (timer >= 25.0f)
        {
            frame1.SetActive(false);
            frame2.SetActive(true);

            if (timer >= 35.0f)
            {
                frame2.SetActive(false);
                frame3.SetActive(true);

                if(timer >= 50.0f)
                {
                    frame3.SetActive(false);
                    frame4.SetActive(true);

                    if (timer >= 60.0f)
                    {
                        frame4.SetActive(false);
                        frame5.SetActive(true);

                        if (timer >= 66.0f)
                        {
                            SceneManager.LoadScene("Fase1");
                        }
                    }
                }
            }
        }
    }
}
