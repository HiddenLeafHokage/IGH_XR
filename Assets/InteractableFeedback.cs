using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRBaseInteractable))]
public class InteractionFeedback : MonoBehaviour
{
    public Outline outline;
    public AudioClip hoverSound;
    public AudioClip selectSound;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.spatialBlend = 1f;
        audioSource.playOnAwake = false;

        var interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(OnHoverEnter);
        interactable.hoverExited.AddListener(OnHoverExit);
        interactable.selectEntered.AddListener(OnSelect);
    }

    void OnHoverEnter(HoverEnterEventArgs args)
    {
        if (outline) outline.enabled = true;
        if (audioSource && hoverSound) audioSource.PlayOneShot(hoverSound);
        SendHaptics(args, 0.2f, 0.1f);
    }

    void OnHoverExit(HoverExitEventArgs args)
    {
        if (outline) outline.enabled = false;
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        if (audioSource && selectSound) audioSource.PlayOneShot(selectSound);
        SendHaptics(args, 0.5f, 0.2f);
    }

    void SendHaptics(BaseInteractionEventArgs args, float intensity, float duration)
    {
        if (args.interactorObject is IXRInteractor interactor)
        {
            // Check if this interactor supports haptics
            if (interactor is XRBaseInputInteractor controllerInteractor)
            {
                controllerInteractor.SendHapticImpulse(intensity, duration);
            }
        }
    }
}
