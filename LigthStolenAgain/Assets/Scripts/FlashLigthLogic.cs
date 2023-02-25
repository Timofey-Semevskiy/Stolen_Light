using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLigthLogic : MonoBehaviour
{
    [SerializeField] private GameObject flashLigth;
    [SerializeField] PlayerMovment player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PickUp(collision);
    }

    private void PickUp(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Flashlight")
        {
            Destroy(flashLigth);
            player.haveFlashLigth = true;
        }
    }
}
