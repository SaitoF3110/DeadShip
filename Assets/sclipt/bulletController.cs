using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_interval = 1.0f;
    [SerializeField] float m_speed = 1.0f;
    Rigidbody2D m_rb2d;
    float m_timer;
    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();

        GameObject obj = GameObject.Find("Player");
        move playerscript = obj.GetComponent<move>();
        int m_fac = playerscript.m_facing;
        
        if (m_fac == 0) { m_rb2d.velocity = Vector2.up * m_speed * 10; }
        else if (m_fac == 1) { m_rb2d.velocity = Vector2.right * m_speed * 10; }
        else if (m_fac == 2) { m_rb2d.velocity = Vector2.down * m_speed * 10; }
        else if (m_fac == 3) { m_rb2d.velocity = Vector2.left * m_speed * 10; }



    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer > m_interval)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
