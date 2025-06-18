using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverHandler : MonoBehaviour
{
    public HoverLabelManager labelManager;

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        VirusLabel label = args.interactableObject.transform.GetComponent<VirusLabel>();
        if (label != null)
        {
            labelManager.ShowLabel(label.transform, label.labelText);
        }
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        labelManager.HideLabel();
    }
}