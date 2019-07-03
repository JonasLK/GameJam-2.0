using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip unloadClip;
    public AudioClip moveClip;

    public GameObject ores;
    public ParticleSystem unloadParticles;
    public Collector collector;
    public BaseDropper connectedMine;
    public float valueMultiplier = 1;
    public float moveSpeed;
    public float loadSpeed;
    public float unloadSpeed;
    public Vector3 rotateAmount;
    public List<OreHolder> oreHolder = new List<OreHolder>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToTarget());
    }

    // Update is called once per frame
    public void OnLoaded()
    {
        ores.SetActive(true);
    }
    void Update()
    {
        Unload();
    }
    public IEnumerator MoveToTarget()
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().SwapSoundEffect(audioSource, moveClip));
        while (Vector3.Distance(transform.position, connectedMine.dropPoint.position) > 0.2f)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, connectedMine.dropPoint.position, moveSpeed * Time.deltaTime);
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            yield return null;
        }
        StartCoroutine(connectedMine.StartLoading(gameObject, loadSpeed));
    }
    public IEnumerator MoveToOrigin()
    {
        while (Vector3.Distance(transform.position, collector.collectionPoint.position) > 0.2f)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, collector.collectionPoint.position, moveSpeed * Time.deltaTime);
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            yield return null;
        }
        StartCoroutine(Unload());
    }
    public IEnumerator Unload()
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().SwapSoundEffect(audioSource, unloadClip));
        Quaternion ogRotation = transform.rotation;

        Quaternion pointToRotateTo = transform.rotation;
        unloadParticles.Play();
        if (Vector3.Distance(transform.position + transform.forward, collector.collectionPoint.transform.position) < Vector3.Distance(transform.position - transform.forward, collector.collectionPoint.transform.position))
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
        float currencyToAdd = 0;
        foreach(OreHolder oreType in oreHolder)
        {
            currencyToAdd += oreType.value * oreType.amount;
        }
        currencyToAdd *= valueMultiplier;
        collector.Collect(currencyToAdd);
        ores.SetActive(false);
        unloadParticles.Stop();
        StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().MuteSound(audioSource));
        while (transform.rotation != ogRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, ogRotation, moveSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(MoveToTarget());
    }
    [System.Serializable]
    public class OreHolder
    {
        public GameObject oreHolding;
        public int amount;
        public float value;

        public OreHolder(GameObject ore, int amount_, float value_)
        {
            oreHolding = ore;
            amount = amount_;
            value = value_;
        }
    }
}
