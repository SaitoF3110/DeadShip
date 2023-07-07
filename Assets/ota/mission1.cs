using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1 : MonoBehaviour
{

    public float requiredHoldTime = 10.0f; // 爆弾を解除するために必要な長押し時間（秒）

    private bool isHolding = false; // 長押し中かどうかを判定するフラグ
    private float holdStartTime = 0.0f; // 長押しを開始した時間


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // キーが押された瞬間
        if (Input.GetKeyDown(KeyCode.M))
        {
            isHolding = true;
            holdStartTime = Time.time;
        }

        // キーが離された瞬間または必要な長押し時間が経過した場合
        if (Input.GetKeyUp(KeyCode.M) || (isHolding && Time.time - holdStartTime >= requiredHoldTime))
        {
            // モジュール解除の処理を実行
            if (isHolding)
            {
                Debug.Log("defused!");
                // ここにモジュール解除の具体的な処理を記述


            }

            isHolding = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.M)) 
        {
            if ()
            {

            }
        }
    }
}
