using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1 : MonoBehaviour
{

    public float requiredHoldTime = 10.0f; // ���e���������邽�߂ɕK�v�Ȓ��������ԁi�b�j

    private bool isHolding = false; // �����������ǂ����𔻒肷��t���O
    private float holdStartTime = 0.0f; // ���������J�n��������


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �L�[�������ꂽ�u��
        if (Input.GetKeyDown(KeyCode.M))
        {
            isHolding = true;
            holdStartTime = Time.time;
        }

        // �L�[�������ꂽ�u�Ԃ܂��͕K�v�Ȓ��������Ԃ��o�߂����ꍇ
        if (Input.GetKeyUp(KeyCode.M) || (isHolding && Time.time - holdStartTime >= requiredHoldTime))
        {
            // ���W���[�������̏��������s
            if (isHolding)
            {
                Debug.Log("defused!");
                // �����Ƀ��W���[�������̋�̓I�ȏ������L�q


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
