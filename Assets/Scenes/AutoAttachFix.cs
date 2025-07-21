using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[DefaultExecutionOrder(-100)]
public class AutoAttachFix : MonoBehaviour
{
    private XRGrabInteractable grab;
    private Transform attachTransform;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        if (!grab) return;

        // Create attach transform ONCE at current object position
        attachTransform = new GameObject("FixedAttachPoint").transform;
        attachTransform.SetParent(transform);
        attachTransform.position = transform.position;  // Match molecule's current position
        attachTransform.rotation = transform.rotation;

        grab.attachTransform = attachTransform;

        // No need to change it again when grabbing
    }
}
