using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1 : MonoBehaviour
{
    [SerializeField]
    private float _requiredHoldTime = 10.0f; //発電機を起動させるために必要なキーを押す秒数

    private bool _isHolding = false;　//長押し中かを判定するフラグ
    private float _holdStartTime = 0.0f;　//長押しを開始した時間
    [SerializeField] Animator animator;
    private bool _isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
     void Update()
    {
        ////キーが押された瞬間
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    isHolding = true;
        //    holdStartTime = Time.time;
        //}

        //// キーが離された瞬間または必要な長押し時間が経過した場合
        //if (Input.GetKeyUp(KeyCode.M) || (isHolding && Time.time - holdStartTime >= requiredHoldTime))
        //{
        //    //発電機起動の処理実行
        //    if (isHolding)
        //    {
                
        //    }

        //    isHolding = false;
        //}

        if(_isHolding && Input.GetKey(KeyCode.M))
        {
            _holdStartTime += Time.deltaTime;
            if (_holdStartTime >= _requiredHoldTime)
            {
                _holdStartTime = 0.0f;

                Debug.Log("発電機の処理");
                _isHolding = false;
                animator.SetBool("_isActive", true);
            }
            
        }
        else
        {
            _holdStartTime = 0;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            _isHolding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit");
            _isHolding = false;
            _holdStartTime = 0;
        }
    }


}
