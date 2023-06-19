using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ray : MonoBehaviour
{
    [SerializeField] Color[] m_colors = default;
    Rigidbody2D m_rb2d;
    float x = 0;
    float scale = 1;
    bool found = false;

    private void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (found == false)
        {
            x += Time.deltaTime;
            m_rb2d.velocity = new Vector2(0, 0);

        }
        if(x >= 2)
        {
            transform.localScale = new Vector3(1,1,1);
            x = 0;
            scale = -1;
        }
        else if (x >=1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            scale = 1;
        }



        this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        Vector2 vector = this.gameObject.transform.position;
        Ray ray = new Ray(new Vector2(vector.x + scale * 3,vector.y), new Vector3(scale, 0, 0));
        

        //Rayの長さ
        float maxDistance = 20;

        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance);

        //なにかと衝突した時だけそのオブジェクトの名前をログに出す
        
        if (hit.collider != null)
        {
            found = false;
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log(hit.collider.gameObject.name);
                found = true;
                
            }
            else
            {
                found = false;
            }
        }
        else
        {
            found = false;
        }
        Debug.DrawRay(new Vector2(vector.x + scale * 3, vector.y), new Vector2(scale, 0), Color.red);

        if (found == true)
        {
            Material itemInfo = this.GetComponent<Renderer>().material;
            //itemInfo.color = Color.red;
            m_rb2d.velocity = new Vector2(scale * 4, 0);
        }
        else
        {
            Material itemInfo = this.GetComponent<Renderer>().material;
            //itemInfo.color = Color.black;
        }

        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);
        //Debug.Log(found);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Bullet")
        {
            Destroy(this.gameObject);
        }
    }

}

