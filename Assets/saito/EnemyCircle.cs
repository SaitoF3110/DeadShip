using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircle : MonoBehaviour
{
    // Start is called before the first frame update
    int fac = 0;
    GameObject obj;
    Enemy move;
    void Start()
    {
        obj = transform.parent.gameObject;
        move = obj.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        fac = move.facting;
        if (fac == 0)
        {
            transform.localPosition = new Vector3(0, 2, 0);
        }
        if (fac == 2)
        {
            transform.localPosition = new Vector3(0, -2, 0);
        }
        if (fac == 1 || fac == 3)
        {
            transform.localPosition = new Vector3(-2,0,0);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           move.circle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move.circle = false;
        }
    }
}
