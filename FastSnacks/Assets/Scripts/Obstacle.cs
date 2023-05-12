using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed = 7;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x <= -20)
            Destroy(gameObject);
    }

    public void ReduceSpeed()
    {
        if(Time.timeScale > 0.5f)
        {
            Time.timeScale = Time.timeScale - 0.5f;
            Debug.Log(Time.timeScale);
        }
    }

    public void IncreaseSpeed()
    {
        if(Time.timeScale < 2.5f)
        {
            Time.timeScale = Time.timeScale + 0.5f;
            Debug.Log(Time.timeScale);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log(other.GetComponent<PlayerController>().health);
            Destroy(gameObject);
        }
    }
}
