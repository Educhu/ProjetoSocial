using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed = 50;
    public float minHeight = -4.3f;
    public float maxHeight = 0.0f;
    public float midPos = -2.3f;
    public int timer;
    public Rigidbody2D rb;

    public int flag1 = 0;
    public int flag2 = 0;

    public int health = 1;
    public int points = 0;

    public TMP_Text coinText;
    public Animator anim;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        PlayerMove();
        ScoreOfPoints();

        if (health <= 0)
            SceneManager.LoadScene("GameOver");

        if (rb.transform.position.y == -4.3f || rb.transform.position.y == 0.0f || rb.transform.position.y == -2.3f)
            anim.SetBool("isIdle", true);
    }

    public void PlayerMove()
    {
        //if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        //{
        //    anim.SetTrigger("Up");
        //    targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        //}
        //else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        //{
        //    anim.SetTrigger("Down");
        //    targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        //}

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (targetPos.y > maxHeight)
        {
            targetPos.y = maxHeight;
        }
        else if (targetPos.y < minHeight)
        {
            targetPos.y = minHeight;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject.FindGameObjectWithTag("Obstacles").GetComponent<Obstacle>().IncreaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject.FindGameObjectWithTag("Obstacles").GetComponent<Obstacle>().ReduceSpeed();
        }

        if (Input.GetAxis("VERTICAL0") == 1 && transform.position.y < maxHeight)
        {
            anim.SetTrigger("Up");
            anim.SetBool("isIdle", false);

            if (flag1 == 0) targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            flag1 = 1;
        }
        else flag1 = 0;

        if (Input.GetAxis("VERTICAL0") == -1 && transform.position.y > minHeight)
        {
            anim.SetTrigger("Down");
            anim.SetBool("isIdle", false);

            if (flag2 == 0) targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            flag2 = 1;
        }
        else flag2 = 0;

        if (Input.GetButtonDown("BRANCO0"))
        {
            GameObject.FindGameObjectWithTag("Obstacles").GetComponent<Obstacle>().IncreaseSpeed();
        }

        if (Input.GetButtonDown("AMARELO0"))
        {
            GameObject.FindGameObjectWithTag("Obstacles").GetComponent<Obstacle>().ReduceSpeed();
        }
    }

    public void AddPoint()
    {
        points += 1;

        coinText.text = points.ToString();
    }

    public void ScoreOfPoints()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timer;

        if (points >= 15 && timer < 7000 && SceneManager.GetActiveScene().name == "Fase1")
        {
            SceneManager.LoadScene("Fase2");
        }
        else if (timer > 7000)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(points >= 15 && timer < 7000 && SceneManager.GetActiveScene().name == "Fase2")
        {
            SceneManager.LoadScene("SceneFinal");
        }
    }
}
