using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1 : MonoBehaviour
{

    public float requiredHoldTime = 10.0f;

    private bool isHolding = false;
    private float holdStartTime = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    
     void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            isHolding = true;
            holdStartTime = Time.time;
        }
    

        if (Input.GetKeyUp(KeyCode.M) || (isHolding && Time.time - holdStartTime >= requiredHoldTime))
        {
            
            if (isHolding)
            {
                Debug.Log("defused!");
            }

            isHolding = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.M)) 
        {
           if(!isHolding)
            {

            }
        }
    }
}
