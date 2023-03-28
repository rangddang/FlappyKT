using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float speed;
    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.position += Vector3.left * speed * 0.02f;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
