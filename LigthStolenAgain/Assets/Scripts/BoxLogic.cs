using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxLogic : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject visibalBoxPrefab;
    public ReternBack reternBack;   



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Flashlight")
        {
            Destroy(boxPrefab);
            Debug.Log("DESTROY");
            reternBack._visibalBoxPrefabSpawned = true;
            Instantiate(visibalBoxPrefab, boxPrefab.transform.position, Quaternion.identity);


        }
    }


   
   
  
}
