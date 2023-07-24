using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_speed = 10f;
    [SerializeField] GameObject m_shot = default;
    [SerializeField] bool muteki = false;
    public int _gunNumber = 0;
    public bool _canMove = true;
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
        //�v���C���[���W�擾
        Vector2 vector2 = this.transform.position;
        x = vector2.x;
        y = vector2.y;

        // ���������̓��͂����o����
        float h = Input.GetAxisRaw("Horizontal");
        float g = Input.GetAxisRaw("Vertical");
        // ���͂ɉ����ăp�h���𐅕������ɓ�����
        
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");

        if (horizontalKey != 0 && verticalKey == 0 && _canMove == true) 
        {
            m_rb2d.velocity = new Vector2(h * m_speed, 0);
            if (horizontalKey >0) { m_facingx = 90; m_facing = 1; }
            else if (horizontalKey < 0) { m_facingx = 270; m_facing = 3; }
        }
        else if (verticalKey != 0 && horizontalKey == 0 && _canMove == true)
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


        if (horizontalKey > 0 && _canMove == true)
        {
            anim.SetBool("run", true);
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
        else if (horizontalKey < 0 && _canMove == true)
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
        //�e������
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_gunNumber == 0)
            {

            }
            else
            {
                Vector2 posi = this.transform.position;
                float x = posi.x;
                float y = posi.y;
                Instantiate(m_shot, new Vector2(x, y), Quaternion.Euler(0, 0, m_facingx));
                _gunNumber -= 1;
            }
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (muteki == false)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
