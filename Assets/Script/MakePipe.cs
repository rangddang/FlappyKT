using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    public GameObject pipe;
    public GameObject Koin;
    public GameObject boy_KT;
    public float delay = 1;

    void Start()
    {
        StartCoroutine(MakeToPipe());
    }

    IEnumerator MakeToPipe()
    {
        while (!GameManager.gameOver)
        {
            yield return new WaitForSeconds(delay/2);
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = new Vector3(5, Random.Range(-1.7f, 4f), 0);
            Destroy(newPipe, 5.0f);
            yield return new WaitForSeconds(delay / 2);
            GameObject newKoin = Instantiate(Koin);
            newKoin.transform.position = new Vector3(5, Random.Range(-1.7f, 4f), 0);
            Destroy(newKoin, 5.0f);
        }
        yield return new WaitForSeconds(60f);
        GameObject newKT = Instantiate(boy_KT);
        newKT.transform.position = new Vector3(7, -2f, 0);
    }
}
