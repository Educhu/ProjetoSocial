using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapetingBackGround : MonoBehaviour
{
    public float speed;
    public float endX;
    public float startX;


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        Debug.Log("Move!");

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}
