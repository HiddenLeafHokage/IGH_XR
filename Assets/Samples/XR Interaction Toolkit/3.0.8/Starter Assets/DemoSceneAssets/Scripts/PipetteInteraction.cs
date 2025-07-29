using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PipetteInteraction : MonoBehaviour
{
    public GameObject bloodSample;
    public GameObject wellPlate;
    public GameObject pipetteTip;
    private bool hasBlood = false;
    private XRGrabInteractable pipetteInteractable;

    void Start()
    {
        pipetteInteractable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if (pipetteInteractable.isSelected && Input.GetKeyDown(KeyCode.Space)) // Use controller trigger in VR
        {
            if (!hasBlood && IsNearBloodSample())
            {
                ExtractBlood();
            }
            else if (hasBlood && IsNearWellPlate())
            {
                DepositBlood();
            }
        }
    }

    bool IsNearBloodSample()
    {
        float distance = Vector3.Distance(pipetteTip.transform.position, bloodSample.transform.position);
        return distance < 0.2f; // Adjustable proximity
    }

    bool IsNearWellPlate()
    {
        float distance = Vector3.Distance(pipetteTip.transform.position, wellPlate.transform.position);
        return distance < 0.3f; // Adjustable proximity
    }

    void ExtractBlood()
    {
        hasBlood = true;
        Debug.Log("Blood extracted into pipette!");
        // Visual cue: Change pipette color or add particle effect
        GetComponent<Renderer>().material.color = Color.red;
    }

    void DepositBlood()
    {
        if (hasBlood)
        {
            hasBlood = false;
            Debug.Log("Blood deposited into 96-well plate!");
            // Visual cue: Reset pipette color
            GetComponent<Renderer>().material.color = Color.white;
            // Simulate well filling (e.g., particle or animation on wellPlate)
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bloodSample && pipetteInteractable.isSelected)
        {
            ExtractBlood();
        }
    }
}