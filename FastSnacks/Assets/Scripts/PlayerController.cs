using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed = 50;
    public float minHeight = -3.0f;
    public float maxHeight = 3.0f;
    public float midPos = 0.0f;

    public int flag1 = 0;
    public int flag2 = 0;

    public int health = 1;
    public int points = 0;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        PlayerMove();

        if (targetPos.y > maxHeight)
        {
            targetPos.y = maxHeight;
        }
        else if (targetPos.y < minHeight)
        {
            targetPos.y = minHeight;
        }

        if(points >= 40)
        {
            SceneManager.LoadScene("SceneFinal");
        }
    }

    public void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);

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
            if (flag1 == 0) targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            flag1 = 1;
        }
        else flag1 = 0;
        if (Input.GetAxis("VERTICAL0") == -1 && transform.position.y > minHeight)
        {
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

        Debug.Log(points);
    }
}
