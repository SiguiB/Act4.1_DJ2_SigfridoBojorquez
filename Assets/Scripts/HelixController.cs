using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPosition;
    private Vector3 startPosition;

    public Transform topTransform;
    public Transform metaTransform;

    public GameObject helixLevelPrefab;

    public List<Stage> allStages = new List<Stage>();
    public float helixDistancia;

    public List<GameObject> spawnLevels = new List<GameObject>();


    private void Awake()
    {
        startPosition = transform.localEulerAngles;
        helixDistancia = topTransform.localPosition.y - (metaTransform.localPosition.y + .1f);
        /*LoadStage(0);*/
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 currentTapPosition = Input.mousePosition;

            if(lastTapPosition == Vector2.zero)
            {
                lastTapPosition = currentTapPosition;
            }

            float distancia = lastTapPosition.x - currentTapPosition.x;
            lastTapPosition = currentTapPosition;

            transform.Rotate(Vector3.up * distancia);
        }

        if(Input.GetMouseButtonUp(0))
        {
            lastTapPosition = Vector2.zero;
        }
    }

    public void LoadStage(int stageNumber)
    {

    }
}
