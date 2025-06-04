using TMPro;
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

    public GameObject player;

    public TextMeshProUGUI text;
    public Canvas Canvas;

    public Camera mainCamera;

   public string[] names = { "Crate", "Box", "Container", "Pallet", "Bundle" };
   public string[] destinations = { "Warehouse A", "Dock B", "Storage C", "Depot D", "Hangar E" };
   public string[] descriptions = {
        "Heavy item, handle with care.",
        "Fragile. Contains glass.",
        "Urgent delivery.",
        "Requires forklift.",
        "Valuable cargo."
    };

    void Start()
    {

        mainCamera = Camera.main;
        player = GameObject.FindWithTag("Player");

       text = GetComponentInChildren<TextMeshProUGUI>();


        // Randomize info
        objectName = names[Random.Range(0, names.Length)];
        destination = destinations[Random.Range(0, destinations.Length)];
        description = descriptions[Random.Range(0, descriptions.Length)];
        weight = Random.Range(10f, 100f);   // Random weight
        value = Random.Range(50f, 500f);    // Random value

         Canvas = GetComponentInChildren<Canvas>();
        Canvas.worldCamera = Camera.main;
        
    }
    private void Update()
{
    text.text = materialType + "\n" +
                objectName + "\n" +
                destination + "\n" +
                description + "\n" +
                weight + "\n" +
                value;
}

    void LateUpdate()
    {





        if (mainCamera != null)
        {

            RectTransform rectTransform = Canvas.GetComponent<RectTransform>();
            // Make the object face the camera
            rectTransform.LookAt(player.transform.position + mainCamera.transform.rotation * Vector3.back,
                             mainCamera.transform.rotation * Vector3.up);


            
        }
    }
}
