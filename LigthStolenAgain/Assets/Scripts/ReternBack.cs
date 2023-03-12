using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReternBack : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject visibalBoxPrefab;
    public bool _visibalBoxPrefabSpawned = false;
   
    void Update()
    {
        if (_visibalBoxPrefabSpawned == true) {
            StartCoroutine(Retern());
            _visibalBoxPrefabSpawned = false;
        }
        
    }

    IEnumerator Retern()
    {
        
        yield return new WaitForSeconds(2);
        Instantiate(boxPrefab, visibalBoxPrefab.transform.position, Quaternion.identity);
        
        Destroy(visibalBoxPrefab, 1f);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
