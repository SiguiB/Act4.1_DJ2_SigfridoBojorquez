using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassScorePoint : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
       GameManager.singleton.AgregaScore(1);
    
    }
}
