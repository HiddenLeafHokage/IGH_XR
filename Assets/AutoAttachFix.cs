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

        // Create attach transform if none assigned
        attachTransform = new GameObject("AutoAttachTransform").transform;
        attachTransform.SetParent(transform);
        attachTransform.localPosition = Vector3.zero;
        attachTransform.localRotation = Quaternion.identity;

        grab.attachTransform = attachTransform;

        // Hook grab event
        grab.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (args.interactorObject == null) return;

        // Update attachTransform to grab point
        attachTransform.position = args.interactorObject.GetAttachTransform(grab).position;
        attachTransform.rotation = args.interactorObject.GetAttachTransform(grab).rotation;
    }
}
