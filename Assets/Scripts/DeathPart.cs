using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour
{
    public void OnEnable()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
