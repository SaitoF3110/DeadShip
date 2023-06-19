using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Color[] m_colors = default;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Material itemInfo = this.GetComponent<Renderer>().material;
        itemInfo.color = Color.black;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Material itemInfo = this.GetComponent<Renderer>().material;
        itemInfo.color = Color.red;
    }
}
