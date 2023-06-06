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
    public float timer;
    public Rigidbody2D rb;
    public GameObject sapoTomate;

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

        if (Input.GetKeyDown("space"))
            sapoTomate.SetActive(true);
    }

    public void PlayerMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        anim.SetBool("up", false);
        anim.SetBool("down", false);
        if (targetPos.y > maxHeight)
        {
            targetPos.y = maxHeight;
        }
        else if (targetPos.y < minHeight)
        {
            targetPos.y = minHeight;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject.FindGameObjectWithTag("Obstacles").GetComponent<Obstacle>().IncreaseSpeed();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject.FindGameObjectWithTag("Obstacles").GetComponent<Obstacle>().ReduceSpeed();
        }

        if (Input.GetAxis("VERTICAL0") == 1 && transform.position.y < maxHeight)
        {
            anim.SetBool("up", true);
            anim.SetBool("isIdle", false);

            if (flag1 == 0) targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            flag1 = 1;
        }
        else flag1 = 0;

        if (Input.GetAxis("VERTICAL0") == -1 && transform.position.y > minHeight)
        {
            anim.SetBool("down", true);
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

        if (points >= 10 && timer < 3600 && SceneManager.GetActiveScene().name == "Fase1")
        {
            SceneManager.LoadScene("TransitionScene1");
        }
        else if (timer > 3600)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (points >= 10 && timer < 3600 && SceneManager.GetActiveScene().name == "Fase2")
        {
            SceneManager.LoadScene("TransitionScene2");
        }
    }
}
