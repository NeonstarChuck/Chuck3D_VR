using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HapticInteractable : MonoBehaviour
{
    [Range(0f, 1f)]
    public float intensity = 0.4f;
    public float duration = 0.1f;

    XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(TriggerHaptic);
    }

    void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseInputInteractor inputInteractor)
        {
            inputInteractor.SendHapticImpulse(intensity, duration);
        }
    }
}
