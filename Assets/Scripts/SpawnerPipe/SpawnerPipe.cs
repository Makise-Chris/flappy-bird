using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Spawner());
    }

    IEnumerator _Spawner()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 temp= pipeHolder.transform.position;
        temp.y = Random.Range(-2.5f, 2.5f);
        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(_Spawner());
    }
}
