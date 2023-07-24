using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItemController : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.Find("Player");
            move move = player.GetComponent<move>();
            move._gunNumber++;
            Destroy(this.gameObject);
        }
    }
}
