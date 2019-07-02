using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    public Transform startPoint;
    public BaseDropper connectedMine;
    public float moveSpeed;
    public float loadSpeed;
    public float unloadSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator MoveToTarget()
    {
        while(Vector3.Distance(transform.position, connectedMine.dropPoint.position) > 0.2f)
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
        while (Vector3.Distance(transform.position, startPoint.position) > 0.2f)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            yield return null;
        }
        StartCoroutine(MoveToTarget());
    }
}
