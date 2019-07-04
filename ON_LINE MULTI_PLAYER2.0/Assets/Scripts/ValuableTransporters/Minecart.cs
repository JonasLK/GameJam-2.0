using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : ValuableTransporter
{
    public AudioClip unloadClip;

    public ParticleSystem unloadParticles;

    public Vector3 rotateAmount;
    // Start is called before the first frame update

    // Update is called once per frame

    public override IEnumerator Unload(GameObject objectToUnloadIn)
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().SwapSoundEffect(audioSource, unloadClip));
        Quaternion ogRotation = transform.rotation;

        Quaternion pointToRotateTo = transform.rotation;
        unloadParticles.Play();
        if (Vector3.Distance(transform.position + transform.forward, objectToUnloadIn.GetComponent<Collector>().interactPoint.position) < Vector3.Distance(transform.position - transform.forward, objectToUnloadIn.GetComponent<Collector>().interactPoint.position))
        {
            pointToRotateTo.eulerAngles += rotateAmount;
        }
        else
        {
            pointToRotateTo.eulerAngles -= rotateAmount;
        }
        while (transform.rotation != pointToRotateTo)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, pointToRotateTo, moveSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        objectToUnloadIn.GetComponent<Collector>().Collect(amountHolding * valueMultiplier);
        amountHolding = 0;
        valuableStack.SetActive(false);
        unloadParticles.Stop();
        StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().MuteSound(audioSource));
        while (transform.rotation != ogRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, ogRotation, moveSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(MoveToDestination());
    }
}
