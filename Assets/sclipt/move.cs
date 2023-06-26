using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_speed = 10f;
    [SerializeField] GameObject m_shot = default;
    Rigidbody2D m_rb2d;
    private Animator anim = null;
    public int m_facingx = 0;
    public int m_facing = 0;

    public float x;
    public float y;


    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤー座標取得
        Vector2 vector2 = this.transform.position;
        x = vector2.x;
        y = vector2.y;

        // 水平方向の入力を検出する
        float h = Input.GetAxisRaw("Horizontal");
        float g = Input.GetAxisRaw("Vertical");
        // 入力に応じてパドルを水平方向に動かす
        
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        if (horizontalKey != 0 && verticalKey == 0) 
        {
            m_rb2d.velocity = new Vector2(h * m_speed, 0);
            if (horizontalKey >0) { m_facingx = 90; m_facing = 1; }
            else if (horizontalKey < 0) { m_facingx = 270; m_facing = 3; }
        }
        else if (verticalKey != 0 && horizontalKey == 0)
        {
            m_rb2d.velocity = new Vector2(0, g * m_speed);
        }
        else if (horizontalKey != 0 && verticalKey != 0)
        {

        }
        else
        {
            m_rb2d.velocity = new Vector2(0,0);
        }


        if (horizontalKey > 0)
        {
            anim.SetBool("run", true);
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else if (horizontalKey < 0)
        {
            anim.SetBool("run", true);
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        else
        {
            anim.SetBool("run", false);
        }

        if (verticalKey > 0)
        {
            anim.SetBool("up", true);
            m_facingx = 0; m_facing = 0;
        }
        else
        {
            anim.SetBool("up", false);
        }

        if (verticalKey < 0)
        {
            anim.SetBool("dawn", true);
            m_facingx = 180; m_facing = 2;
        }
        else
        {
            anim.SetBool("dawn", false);
        }
        //弾を撃つ
        bool shotKey = Input.GetKeyDown("space");
        if (shotKey)
        {
            Vector2 posi = this.transform.position;
            float x = posi.x;
            float y = posi.y;
            Instantiate(m_shot,new Vector2(x,y),Quaternion.Euler(0,0,m_facingx));
        }
    }
}
