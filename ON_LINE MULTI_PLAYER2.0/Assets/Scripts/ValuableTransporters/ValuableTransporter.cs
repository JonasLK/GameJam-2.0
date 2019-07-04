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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
