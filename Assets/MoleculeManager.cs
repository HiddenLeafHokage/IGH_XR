//using UnityEngine;
//using TMPro;
//using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.XR.Interaction.Toolkit.Interactables;

//public class MoleculeManager : MonoBehaviour
//{
//    [Header("UI Components")]
//    public TMP_Dropdown moleculeDropdown;

//    [Header("Molecule Prefabs")]
//    public GameObject[] moleculePrefabs;

//    [Header("Spawn Settings")]
//    public Transform spawnPoint;
//    private GameObject currentMolecule;

//    void Start()
//    {
//        // Clear existing options
//        moleculeDropdown.ClearOptions();

//        // Populate dropdown with molecule names
//        foreach (GameObject prefab in moleculePrefabs)
//        {
//            moleculeDropdown.options.Add(new TMP_Dropdown.OptionData(prefab.name));
//        }

//        // Refresh the dropdown to show the new options
//        moleculeDropdown.RefreshShownValue();

//        // Add listener for dropdown value change
//        moleculeDropdown.onValueChanged.AddListener(OnMoleculeSelected);

//        // Instantiate the first molecule by default
//        OnMoleculeSelected(0);
//    }

//    void OnMoleculeSelected(int index)
//    {
//        // Destroy the current molecule if it exists
//        if (currentMolecule != null)
//        {
//            Destroy(currentMolecule);
//        }

//        // Instantiate the selected molecule prefab at the spawn point
//        currentMolecule = Instantiate(moleculePrefabs[index], spawnPoint.position, spawnPoint.rotation);

//        // Ensure the molecule has the necessary components for VR interaction
//        if (!currentMolecule.GetComponent<XRGrabInteractable>())
//        {
//            currentMolecule.AddComponent<XRGrabInteractable>();
//        }

//        if (!currentMolecule.GetComponent<Rigidbody>())
//        {
//            Rigidbody rb = currentMolecule.AddComponent<Rigidbody>();
//            rb.useGravity = false;
//        }

//        if (!currentMolecule.GetComponent<Collider>())
//        {
//            currentMolecule.AddComponent<BoxCollider>();
//        }
//    }
//}
//old code 
//using UnityEngine;
//using TMPro;
//using UnityEngine.UI;
//using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.XR.Interaction.Toolkit.Interactables;

//public class MoleculeManager : MonoBehaviour
//{
//    [Header("UI Components")]
//    public TMP_Dropdown moleculeDropdown;
//    public Image labelImageUI;

//    [Header("Molecule Prefabs")]
//    public GameObject[] moleculePrefabs;

//    [Header("Label Images (match order with prefabs)")]
//    public Texture2D[] labelImages;

//    [Header("Spawn Settings")]
//    public Transform spawnPoint;
//    private GameObject currentMolecule;

//    void Start()
//    {
//        // Clear existing options
//        moleculeDropdown.ClearOptions();

//        // Populate dropdown with molecule names
//        foreach (GameObject prefab in moleculePrefabs)
//        {
//            moleculeDropdown.options.Add(new TMP_Dropdown.OptionData(prefab.name));
//        }

//        // Refresh the dropdown to show the new options
//        moleculeDropdown.RefreshShownValue();

//        // Add listener for dropdown value change
//        moleculeDropdown.onValueChanged.AddListener(OnMoleculeSelected);

//        // Instantiate the first molecule by default
//        OnMoleculeSelected(0);
//    }

//    void OnMoleculeSelected(int index)
//    {
//        // Destroy the current molecule if it exists
//        if (currentMolecule != null)
//        {
//            Destroy(currentMolecule);
//        }

//        // Instantiate the selected molecule prefab at the spawn point
//        currentMolecule = Instantiate(moleculePrefabs[index], spawnPoint.position, spawnPoint.rotation);

//        // Ensure the molecule has the necessary components for VR interaction
//        if (!currentMolecule.GetComponent<XRGrabInteractable>())
//        {
//            currentMolecule.AddComponent<XRGrabInteractable>();
//        }

//        if (!currentMolecule.GetComponent<Rigidbody>())
//        {
//            Rigidbody rb = currentMolecule.AddComponent<Rigidbody>();
//            rb.useGravity = false;
//        }

//        if (!currentMolecule.GetComponent<Collider>())
//        {
//            currentMolecule.AddComponent<BoxCollider>();
//        }

//        // Load the label image based on index and assign to UI
//        if (labelImages.Length > index && labelImages[index] != null && labelImageUI != null)
//        {
//            Texture2D tex = labelImages[index];
//            Sprite labelSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
//            labelImageUI.sprite = labelSprite;
//        }
//        else if (labelImageUI != null)
//        {
//            labelImageUI.sprite = null; // Clear if no image available
//        }
//    }
//}
//newcode

//code to add image 
using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MoleculeManager : MonoBehaviour
{
    [Header("UI Components")]
    public TMP_Dropdown moleculeDropdown;
    public Image labelImageUI;

    [Header("Molecule Prefabs")]
    public GameObject[] moleculePrefabs;

    [Header("Label Images (match order with prefabs)")]
    public Texture2D[] labelImages;

    [Header("Spawn Points (match order with prefabs)")]
    public Transform[] spawnPoints;

    private GameObject currentMolecule;

    void Start()
    {
        // Clear existing options
        moleculeDropdown.ClearOptions();

        // Populate dropdown with molecule names
        foreach (GameObject prefab in moleculePrefabs)
        {
            moleculeDropdown.options.Add(new TMP_Dropdown.OptionData(prefab.name));
        }

        moleculeDropdown.RefreshShownValue();
        moleculeDropdown.onValueChanged.AddListener(OnMoleculeSelected);

        // Spawn first one
        OnMoleculeSelected(0);
    }

    void OnMoleculeSelected(int index)
    {
        if (currentMolecule != null)
        {
            Destroy(currentMolecule);
        }

        // Get correct spawn transform
        Transform spawnTransform = spawnPoints[index];

        //// Instantiate prefab at specific position and rotation
        //currentMolecule = Instantiate(moleculePrefabs[index], spawnTransform.position, spawnTransform.rotation);

        //// Add VR components if missing
        //if (!currentMolecule.GetComponent<XRGrabInteractable>())
        //    currentMolecule.AddComponent<XRGrabInteractable>();

        //if (!currentMolecule.GetComponent<Rigidbody>())
        //{
        //    Rigidbody rb = currentMolecule.AddComponent<Rigidbody>();
        //    rb.useGravity = false;
        //}

        //if (!currentMolecule.GetComponent<Collider>())
        //{
        //    currentMolecule.AddComponent<BoxCollider>();
        //}






        // Instantiate prefab at specific position and rotation
        currentMolecule = Instantiate(moleculePrefabs[index], spawnTransform.position, spawnTransform.rotation);

        // Ensure interaction components
        XRGrabInteractable grab = currentMolecule.GetComponent<XRGrabInteractable>();
        if (!grab)
            grab = currentMolecule.AddComponent<XRGrabInteractable>();

        Rigidbody rb = currentMolecule.GetComponent<Rigidbody>();
        if (!rb)
        {
            rb = currentMolecule.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true; // Optional: helps prevent shake
        }

        Collider col = currentMolecule.GetComponent<Collider>();
        if (!col)
            currentMolecule.AddComponent<BoxCollider>();

        // === FIX: Stable grab orientation === //
        Transform attachPoint = currentMolecule.transform.Find("AttachPoint");
        if (attachPoint == null)
        {
            GameObject newAttach = new GameObject("AttachPoint");
            newAttach.transform.SetParent(currentMolecule.transform);
            newAttach.transform.localPosition = Vector3.zero;
            newAttach.transform.localRotation = Quaternion.identity;
            attachPoint = newAttach.transform;
        }

        grab.attachTransform = attachPoint;
        grab.movementType = XRBaseInteractable.MovementType.Kinematic;
        grab.trackPosition = true;
        grab.trackRotation = true;

        // Set label image
        if (labelImages.Length > index && labelImages[index] != null && labelImageUI != null)
        {
            Sprite sprite = Sprite.Create(labelImages[index], new Rect(0, 0, labelImages[index].width, labelImages[index].height), new Vector2(0.5f, 0.5f));
            labelImageUI.sprite = sprite;
        }
        else if (labelImageUI != null)
        {
            labelImageUI.sprite = null;
        }

    }
}


//Code to refactor it
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.XR.Interaction.Toolkit.Interactables;

//public class MoleculeManager : MonoBehaviour
//{
//    [Header("UI Components")]
//    public TMP_Dropdown moleculeDropdown;
//    public Image labelImageUI;

//    [Header("Molecule Prefabs")]
//    public GameObject[] moleculePrefabs;

//    [Header("Label Images (match order with prefabs)")]
//    public Texture2D[] labelImages;

//    [Header("Offsets (match order with prefabs)")]
//    public Vector3[] positionOffsets;
//    public Vector3[] rotationOffsets;

//    [Header("Spawn Point (Base Position)")]
//    public Transform spawnPoint;

//    private GameObject currentMolecule;

//    void Start()
//    {
//        // Clear and populate dropdown
//        moleculeDropdown.ClearOptions();

//        foreach (GameObject prefab in moleculePrefabs)
//        {
//            moleculeDropdown.options.Add(new TMP_Dropdown.OptionData(prefab.name));
//        }

//        moleculeDropdown.RefreshShownValue();
//        moleculeDropdown.onValueChanged.AddListener(OnMoleculeSelected);

//        OnMoleculeSelected(0); // Spawn first
//    }

//    void OnMoleculeSelected(int index)
//    {
//        if (currentMolecule != null)
//        {
//            Destroy(currentMolecule);
//        }

//        // Apply per-molecule position and rotation offsets
//        Vector3 spawnPosition = spawnPoint.position;
//        Quaternion spawnRotation = spawnPoint.rotation;

//        if (index < positionOffsets.Length)
//        {
//            spawnPosition += positionOffsets[index];
//        }

//        if (index < rotationOffsets.Length)
//        {
//            spawnRotation *= Quaternion.Euler(rotationOffsets[index]);
//        }

//        currentMolecule = Instantiate(moleculePrefabs[index], spawnPosition, spawnRotation);

//        // Add interaction components
//        if (!currentMolecule.GetComponent<XRGrabInteractable>())
//            currentMolecule.AddComponent<XRGrabInteractable>();

//        if (!currentMolecule.GetComponent<Rigidbody>())
//        {
//            Rigidbody rb = currentMolecule.AddComponent<Rigidbody>();
//            rb.useGravity = false;
//        }

//        if (!currentMolecule.GetComponent<Collider>())
//        {
//            currentMolecule.AddComponent<BoxCollider>();
//        }

//        // Set label image
//        if (labelImages.Length > index && labelImages[index] != null && labelImageUI != null)
//        {
//            Sprite sprite = Sprite.Create(labelImages[index], new Rect(0, 0, labelImages[index].width, labelImages[index].height), new Vector2(0.5f, 0.5f));
//            labelImageUI.sprite = sprite;
//        }
//        else if (labelImageUI != null)
//        {
//            labelImageUI.sprite = null;
//        }
//    }
//}
