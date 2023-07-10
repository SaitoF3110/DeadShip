using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LayerMask _wallLayer = 0;
    [SerializeField] LayerMask _layer = 0;
    Vector3 _targets;
    Rigidbody2D rb;
    public float moveSpeed = 1;
    public float stayinterval = 5;
    public float moveinterval = 5;
    bool _isStan = false;//スタンしてるか
    private Animator anim = null;
    public int facting;
    public bool circle = false;
    int facx;
    int facy;
    float m_timer;
    float m_timer2;
    bool fact = false;
    bool wall = false;
    bool find = false;
    GameObject obj;
    public enemyasset _enemyData;//エネミーデータ呼び出し

    void Start()
    {
        obj = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
            if (_isStan == true)
        {
            if(facting == 0)
            {
                Instantiate(_enemyData.enemy1stanup, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
            else if (facting == 1)
            {
                Instantiate(_enemyData.enemy1stanright, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
            else if (facting == 2)
            {
                Instantiate(_enemyData.enemy1standown, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
            else if (facting == 3)
            {
                Instantiate(_enemyData.enemy1stanleft, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }



        move trans = obj.GetComponent<move>();
        _targets= new Vector3(trans.x,trans.y,0);

        Vector3 dir = (_targets - this.transform.position).normalized * moveSpeed;
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + new Vector2(dir.x,dir.y) * 4);
        RaycastHit2D hit = Physics2D.Linecast(start, start + new Vector2(dir.x, dir.y) * 4, _layer);
        Debug.DrawLine(start, start + new Vector2(facx, facy) * 2);
        RaycastHit2D movewall = Physics2D.Linecast(start, start + new Vector2(facx, facy) * 2, _wallLayer);
        find = false;

        if (hit.collider != null)
        {
            
            if (hit.collider.CompareTag("Player") && circle == true)
            {
                find = true;
                rb.velocity = new Vector2(0, 0);
                fact = false;
                anim.SetBool("stay", true);
            }
            else 
            {
                find = false;
            }
        }



        if (find == true)//プレイヤー発見時
        {
            m_timer2 += Time.deltaTime;
            anim.SetBool("stay", false);
            //this.transform.Translate(dir * Time.deltaTime);
            if (m_timer2 > 0.5)
            {
                if (dir.x * dir.x >= dir.y * dir.y)//左右移動
                {
                    if (dir.x >= 0)
                    {
                        facting = 1;
                    }
                    else
                    {
                        facting = 3;
                    }
                }
                if (dir.x * dir.x < dir.y * dir.y)//上下移動
                {
                    if (dir.y >= 0)
                    {
                        facting = 0;
                    }
                    else
                    {
                        facting = 2;
                    }
                }
                m_timer2 = 0;
            }

            
            MoveFacting();
            //Debug.Log("x" + dir.x + "/y" + dir.y);

        }
        

        if (find == false)
        {
            //敵の徘徊
            m_timer += Time.deltaTime;

            if (m_timer >= stayinterval)
            {
                anim.SetBool("stay", false);
                if (fact == false)
                {
                    facting = Random.Range(0, 4);//0:上 1:右 2:下 3:左
                    fact = true;
                }
                //壁に当たった時
                if (movewall.collider != null)
                {
                    facting = Random.Range(0, 4);
                }
                MoveFacting();
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                fact = false;
                anim.SetBool("stay", true);
            }

            
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            wall = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _isStan = true;
        }
    }
    void MoveFacting()
    {
        if (facting == 0)
        {
            anim.SetBool("back", true);
            anim.SetBool("front", false);
            anim.SetBool("side", false);
            facx = 0;
            facy = 1;
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(0, moveSpeed);
            if (m_timer >= stayinterval + moveinterval)
            {
                m_timer = 0;
            }
        }
        else if (facting == 1)
        {
            anim.SetBool("side", true);
            anim.SetBool("back", false);
            anim.SetBool("front", false);
            facx = 1;
            facy = 0;
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(moveSpeed, 0);
            if (m_timer >= stayinterval + moveinterval)
            {
                m_timer = 0;
            }
        }
        else if (facting == 2)
        {
            anim.SetBool("front", true);
            anim.SetBool("back", false);
            anim.SetBool("side", false);
            facx = 0;
            facy = -1;
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(0, -moveSpeed);
            if (m_timer >= stayinterval + moveinterval)
            {
                m_timer = 0;
            }
        }
        else if (facting == 3)
        {
            anim.SetBool("side", true);
            anim.SetBool("back", false);
            anim.SetBool("front", false);
            facx = -1;
            facy = 0;
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-moveSpeed, 0);
            if (m_timer >= stayinterval + moveinterval)
            {
                m_timer = 0;
            }
        }
    }
}
