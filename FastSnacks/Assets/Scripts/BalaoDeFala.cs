using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BalaoDeFala : MonoBehaviour
{
    public Image blocoDeFala;
    public List<string> textList;
    public Text speechText;
    public int index = 0;
    private float animationTextTimer;

    // Start is called before the first frame update
    void Start()
    {
        speechText.text = "";
        textList.Add("");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool AnimationText(int linha)
    {
        animationTextTimer += Time.deltaTime;
        if (animationTextTimer >= 0.08f)
        {
            if (!speechText.text.Equals(textList[linha]))
            {
                speechText.text += textList[linha][index];
                index++;
            }
            animationTextTimer -= animationTextTimer;
        }
        return false;
    }
}
