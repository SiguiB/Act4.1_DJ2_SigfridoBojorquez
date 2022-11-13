using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPosition;
    private Vector3 startRotation;

    public Transform topTransform;
    public Transform metaTransform;

    public GameObject helixLevelPrefab;

    public List<Stage> allStages = new List<Stage>();
    public float helixDistancia;

    public List<GameObject> spawnLevels = new List<GameObject>();


    private void Awake()
    {
        startRotation = transform.localEulerAngles;
        helixDistancia = topTransform.localPosition.y - (metaTransform.localPosition.y + .1f);
        LoadStage(0);
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
        Stage stage = allStages[Mathf.Clamp(stageNumber,0,allStages.Count - 1)];
        if(stage==null)
        {
            Debug.Log("No stages");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;

        FindObjectOfType<PelotaController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stagePelotaColor;
   
        transform.localEulerAngles = startRotation;
        foreach (GameObject go in spawnLevels)
        {
            Destroy(go);
        }

        float levelDistancia = helixDistancia/stage.levels.Count;
        float spawnPosY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPosY -= levelDistancia;
            GameObject level = Instantiate(helixLevelPrefab, transform);
            level.transform.localPosition = new Vector3(0, spawnPosY, 0);
            spawnLevels.Add(level);

            int partstoDisable = 12 - stage.levels[i].partCount;
            List<GameObject> disableParts = new List<GameObject>();
            while (disableParts.Count<partstoDisable)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0,level.transform.childCount)).gameObject;
                if(disableParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disableParts.Add(randomPart);
                }
            }
            List<GameObject> leftParts = new List<GameObject>();
            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if(t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
            }
            List<GameObject> deathparts = new List<GameObject>();
            while (deathparts.Count < stage.levels[i].deathPartCount)
            {
                GameObject randomPart = leftParts[(Random.Range(0, leftParts.Count))];
                if(!deathparts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPart>();
                    deathparts.Add(randomPart);
                }
            }
        }
    }
}
