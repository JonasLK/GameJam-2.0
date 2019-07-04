using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool canInteract = true;
    public UnityEvent interactEvents;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Interact();
        }
    }
    public void Interact()
    {
        if (canInteract)
        {
            interactEvents.Invoke();
        }
    }
    public void Disable(float duration = 0)
    {
        StartCoroutine(DisableForDuration(duration));
    }
    public IEnumerator DisableForDuration(float duration_)
    {
        canInteract = false;
        yield return new WaitForSeconds(duration_);
        canInteract = true;
    }
}
