using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShake : MonoBehaviour
{
    public int shakes;
    public float intensity;
    public float duration;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<EffectManager>().ShakeObject(cam, intensity, shakes, duration));
    }

}
