using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text actualScoreText;
    public Text mejorScoreText;

    public Slider slider;

    public Text actualLvl;
    public Text nextLvl;
    public Transform topTransform;
    public Transform metaTransform;
    public Transform pelota;

    void Update()
    {
        actualScoreText.text = "Score: " + GameManager.singleton.actualScore;
        mejorScoreText.text = "Best Score: " + GameManager.singleton.mejorScore;
        CambioSliderLevelAndProgress();
    }

    public void CambioSliderLevelAndProgress()
    {
        actualLvl.text = ""+(GameManager.singleton.actualLevel+1);
        nextLvl.text = ""+(GameManager.singleton.actualLevel+2);

        float totalDistancia = (topTransform.position.y - metaTransform.position.y);
        float distanciaQueda = totalDistancia - (pelota.position.y - metaTransform.position.y);
    
        float valor = (distanciaQueda / totalDistancia);
        slider.value = Mathf.Lerp(slider.value,valor,5);
    }
}
