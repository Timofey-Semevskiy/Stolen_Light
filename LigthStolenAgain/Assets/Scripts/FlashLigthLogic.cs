using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlashLigthLogic : MonoBehaviour
{
    [SerializeField] public GameObject character;
    [SerializeField] private GameObject flashLigth;
    [SerializeField] PlayerMovment player;
    [SerializeField] private GameObject flashInHandPlayer;
    


    public float radius = 1f;
    [Range(0, 1)]
    public float angTresh = 0.5f;
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
    

    private void OnDrawGizmos()
    {
     
        Handles.DrawWireDisc(player.transform.position, Vector3.forward, radius);
        float p = angTresh;
        float x = Mathf.Sqrt(1 - p * p);

        Vector3 vRigth = transform.right * p + transform.up * (-x);
        Vector3 vDown = transform.right * p + transform.up * x;
        Gizmos.DrawRay(flashInHandPlayer.transform.position, vRigth);
        Gizmos.DrawRay(flashInHandPlayer.transform.position, vDown);

    }

    

}


