using System.Collections;
using UnityEngine;

public class spawner : StatisticsObject
{
    public float seconds;
    public GameObject Spawn;

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

        // Apply random info
        MaterialInfo info = clone.GetComponent<MaterialInfo>();
        if (info != null)
        {
            info.materialType = materialType;
        }

        Destroy(clone, seconds + 20f);
        yield return new WaitForSeconds(seconds);
        StartCoroutine(cloning());
    }
}
