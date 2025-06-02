using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : StatisticsObject
{
    public float seconds;
    public GameObject Spawn;

    public GameObject TMP;


    void Start()
    {
        StartCoroutine(cloning());
    }

    IEnumerator cloning()
    {
        // Randomly pick a material
        int randomMaterial = Random.Range(0, 3);
        GameObject prefabToSpawn = null;
        string materialType = "";

        switch (randomMaterial)
        {
            case 0:
                prefabToSpawn = woodPrefab;
                materialType = "Wood";
                break;
            case 1:
                prefabToSpawn = metalPrefab;
                materialType = "Metal";
                break;
            case 2:
                prefabToSpawn = glassPrefab;
                materialType = "Glass";
                break;
        }

        GameObject clone = Instantiate(prefabToSpawn, Spawn.transform.position, Quaternion.identity);

    
        
        MaterialInfo info = clone.GetComponent<MaterialInfo>();
        Canvas Canvas = clone.GetComponentInChildren<Canvas>();
        // Apply random info
        if (info != null)
        {
            info.materialType = materialType;
            Canvas.worldCamera = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
        }

        Destroy(clone, seconds + 20f);
        yield return new WaitForSeconds(seconds);
        StartCoroutine(cloning());
    }
}
