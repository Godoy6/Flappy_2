using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        scoreText.text = "POINTS: " + GameManager.Instance.score;
    }
}

