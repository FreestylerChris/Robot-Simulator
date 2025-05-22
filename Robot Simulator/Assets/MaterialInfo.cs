using UnityEngine;

[System.Serializable]
public class MaterialInfo : MonoBehaviour
{
    public string materialType;
    public string objectName;
    public string destination;
    [TextArea]
    public string description;
    public float weight;
    public float value;

    string[] names = { "Crate", "Box", "Container", "Pallet", "Bundle" };
    string[] destinations = { "Warehouse A", "Dock B", "Storage C", "Depot D", "Hangar E" };
    string[] descriptions = {
        "Heavy item, handle with care.",
        "Fragile. Contains glass.",
        "Urgent delivery.",
        "Requires forklift.",
        "Valuable cargo."
    };

    void Start()
    {
        // Randomize info
        objectName = names[Random.Range(0, names.Length)];
        destination = destinations[Random.Range(0, destinations.Length)];
        description = descriptions[Random.Range(0, descriptions.Length)];
        weight = Random.Range(10f, 100f);   // Random weight
        value = Random.Range(50f, 500f);    // Random value

        gameObject.name = materialType + " - " + objectName;
    }
}
