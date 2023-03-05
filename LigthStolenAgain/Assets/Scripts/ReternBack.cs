using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReternBack : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject visibalBoxPrefab;
    public bool _visibalBoxPrefabSpawned;
    private void Start()
    {
        Retern();
    }
    void Update()
    {
        
    }


    IEnumerator Retern()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
