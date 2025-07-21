using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class PersistentGrabOrientation : MonoBehaviour
{
    private XRGrabInteractable grab;
    private Transform attachTransform;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();

        // Create and assign a stable attach transform at the center of this object
        GameObject attachGO = new GameObject("AttachPoint");
        attachTransform = attachGO.transform;
        attachTransform.SetParent(transform);
        attachTransform.localPosition = Vector3.zero;
        attachTransform.localRotation = Quaternion.identity;

        grab.attachTransform = attachTransform;

        // Important for preserving rotation
        grab.trackRotation = true;
        grab.useDynamicAttach = false;
    }

    void OnEnable()
    {
        grab.selectEntered.AddListener(OnGrab);
    }

    void OnDisable()
    {
        grab.selectEntered.RemoveListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        // When you grab it, don’t let it match the controller’s orientation
        // The grab will respect the current rotation of the object
        if (grab.attachTransform != null)
        {
            grab.attachTransform.position = transform.position;
            grab.attachTransform.rotation = transform.rotation;
        }
    }
}
