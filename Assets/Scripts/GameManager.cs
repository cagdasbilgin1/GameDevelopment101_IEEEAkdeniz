using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BallDemo ball1;
    [SerializeField] BallDemo ball2;

    [SerializeField] TextMeshProUGUI ball1CounterTxt;
    [SerializeField] TextMeshProUGUI ball2CounterTxt;
    [SerializeField] int winConditionCount;
    [SerializeField] TextMeshProUGUI winnerText;

    int _color1Count;
    int _color2Count;

    public void UpdateColorCount(Material material, bool isPaintedBefore)
    {
        if (material.color.CompareRGB(ball1.Material.color))
        {
            _color1Count++;
            if (isPaintedBefore) _color2Count--;
        }
        else if(material.color.CompareRGB(ball2.Material.color))
        {
            _color2Count++;
            if(isPaintedBefore) _color1Count--;
        }

        ball1CounterTxt.text = _color1Count.ToString();
        ball2CounterTxt.text = _color2Count.ToString();

        CheckTheWinner();
    }

    void CheckTheWinner()
    {
        if(_color1Count >= winConditionCount)
        {
            winnerText.text = ball1.gameObject.name + " won";
            Time.timeScale = 0;
        }
        else if(_color2Count >= winConditionCount)
        {
            winnerText.text = ball2.gameObject.name + " won";
            Time.timeScale = 0;
        }
    }

    public void EliminateBall(BallDemo ball)
    {
        if (ball.Material.color.CompareRGB(ball1.Material.color))
        {
            winnerText.text = ball1.gameObject.name + " eliminated. " + ball2.gameObject.name + " won";
        }
        else if (ball.Material.color.CompareRGB(ball2.Material.color))
        {
            winnerText.text = ball2.gameObject.name + " eliminated. " + ball1.gameObject.name + " won";
        }

        Time.timeScale = 0;
    }
}
