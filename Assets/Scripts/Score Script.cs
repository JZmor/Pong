using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    
    int _leftScore = 0;
    int _rightScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ChangeScore(bool which)
    {
        if (which)
        {
            _leftScore += 1;
        }
        else
        {
            _rightScore += 1;
        }

        leftText.text = $"Score: {_leftScore}";
        rightText.text = $"Score: {_rightScore}";
        if (_leftScore == 11)
        {
            leftText.color = Color.yellow;
        } 
        else if (_rightScore == 11)
        {
            rightText.color = Color.yellow;
        } 
        else if (_leftScore > _rightScore)
        {
            leftText.color = Color.green;
            rightText.color = Color.red;
        } 
        else if (_leftScore == _rightScore)
        {
            leftText.color = Color.white;
            rightText.color = Color.white;
        }
        else
        {
            leftText.color = Color.red;
            rightText.color = Color.green;
        }
    }

    public void ResetScore()
    {
        _leftScore = 0;
        _rightScore = 0;
        leftText.text = $"Score: {_leftScore}";
        rightText.text = $"Score: {_rightScore}";
        leftText.color = Color.white;
        rightText.color = Color.white;
    }
}
