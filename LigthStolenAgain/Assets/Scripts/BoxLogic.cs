using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject visibalBoxPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Flashlight")
        {
            Destroy(boxPrefab);
            Instantiate(visibalBoxPrefab,boxPrefab.transform.position,Quaternion.identity);
            
        }
    }


   
}
