using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public float defaultFadespeed;
    public IEnumerator FadeObject(bool fadeIn, float fadeSpeed, GameObject objectToFade, bool destroyOnFinish)
    {
        Material fadeMaterial = new Material(objectToFade.GetComponent<MeshRenderer>().material);
        objectToFade.GetComponent<MeshRenderer>().material = fadeMaterial;
        Color fadeColor = fadeMaterial.color;
        if (fadeIn)
        {
            objectToFade.SetActive(true);
            fadeColor.a = 0;
            fadeMaterial.color = fadeColor;
            while (fadeColor.a < 1)
            {
                yield return new WaitForSeconds(0.01f);
                fadeColor.a += fadeSpeed * Time.deltaTime;
                fadeColor.a = Mathf.Min(fadeColor.a, 1);
                fadeMaterial.color = fadeColor;
            }
        }
        else
        {
            while (fadeColor.a > 0)
            {
                yield return new WaitForSeconds(0.01f);
                fadeColor.a -= fadeSpeed * Time.deltaTime;
                fadeColor.a = Mathf.Max(fadeColor.a, 0);
                fadeMaterial.color = fadeColor;
            }
        }
        if (destroyOnFinish)
        {
            Destroy(gameObject);
        }
    }
    public void FadeObjectIn(GameObject objectToFadeIn)
    {
        StartCoroutine(FadeObject(true, defaultFadespeed, objectToFadeIn, false));
    }
    public void FadeObjectOut(GameObject objectToFadeOut)
    {
        StartCoroutine(FadeObject(false, defaultFadespeed, objectToFadeOut, true));
    }
    public IEnumerator ShakeObject(Transform objectTransform, float shakeIntensity, int shakeAmount, float shakeDuration)
    {
        Vector3 ogPos = objectTransform.position;
        float singleShakeDuration = shakeDuration / shakeAmount;
        for(int shakes = 0; shakes < shakeAmount; shakes++)
        {
            Vector3 modifyAmount = new Vector3(Random.Range(-shakeIntensity, shakeIntensity), Random.Range(-shakeIntensity, shakeIntensity));
            objectTransform.position = ogPos + modifyAmount;
            yield return new WaitForSeconds(singleShakeDuration);
        }
        objectTransform.position = ogPos;
    }
}
