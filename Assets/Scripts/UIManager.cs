using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text actualScoreText;
    public Text mejorScoreText;


    void Update()
    {
        actualScoreText.text = "Score: " + GameManager.singleton.actualScore;
        mejorScoreText.text = "Best Score: " + GameManager.singleton.mejorScore;
    }
}
