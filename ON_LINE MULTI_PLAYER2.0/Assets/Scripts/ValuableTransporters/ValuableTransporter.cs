using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuableTransporter : MonoBehaviour
{
    public float loadSpeed;
    public float unloadSpeed;
    public GameObject valuableStack;

    public AIUsable[] destinations;
    public int currentWantedDestination = 1;
    public float valueMultiplier = 1;
    public float moveSpeed;

    public float amountHolding;

    public AudioSource audioSource;
    public AudioClip moveClip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToDestination());
    }

    public IEnumerator MoveToDestination()
    {
        if(currentWantedDestination == destinations.Length)
        {
            currentWantedDestination = 0;
        }
        StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().SwapSoundEffect(audioSource, moveClip));
        while (Vector3.Distance(transform.position, destinations[currentWantedDestination].interactPoint.position) > 0.2f)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, destinations[currentWantedDestination].interactPoint.position, moveSpeed * Time.deltaTime);
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            yield return null;
        }
        destinations[currentWantedDestination].Use(gameObject);
    }
    public void OnLoaded()
    {
        valuableStack.SetActive(true);
    }
    public virtual IEnumerator Unload(GameObject objectToUnloadIn)
    {
        yield return null;
    }
}
