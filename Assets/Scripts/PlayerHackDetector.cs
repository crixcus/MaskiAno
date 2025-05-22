//using UnityEngine;

//[RequireComponent(typeof(SphereCollider))]
//public class PlayerHackDetector : MonoBehaviour
//{
//    public float detectionRadius = 3f;
//    public Color normalColor = Color.white;
//    public Color buildingDetectedColor = Color.red;

//    private Renderer playerRenderer;
//    public BuildingHealth bldgHp;
//    public GameObject bldgHealth;

//    void Start()
//    {
//        // Setup the detection sphere
//        SphereCollider detector = GetComponent<SphereCollider>();
//        detector.isTrigger = true;
//        detector.radius = detectionRadius;
//        bldgHealth.SetActive(false);

//        // Grab Renderer to change material color as indicator
//        playerRenderer = GetComponent<Renderer>();
//        if (playerRenderer != null)
//            playerRenderer.material.color = normalColor;
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Building"))
//        {
//            Debug.Log("Building detected!");
//            bldgHealth.SetActive(true);
//            if (playerRenderer != null)
//                playerRenderer.material.color = buildingDetectedColor;
//            while (other.CompareTag("Building"))
//            {
//                bldgHp.Hacking();
//            }
//        }
//    }

//    void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Building"))
//        {
//            Debug.Log("Exited building detection zone.");
//            bldgHealth.SetActive(false);
//            if (playerRenderer != null)
//                playerRenderer.material.color = normalColor;
//        }
//    }
//}
