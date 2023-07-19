using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1 : MonoBehaviour
{
    [SerializeField]
    private float _requiredHoldTime = 10.0f; //���d�@���N�������邽�߂ɕK�v�ȃL�[�������b��

    private bool _isHolding = false;�@//�����������𔻒肷��t���O
    private float _holdStartTime = 0.0f;�@//���������J�n��������

    private bool _isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
     void Update()
    {
        ////�L�[�������ꂽ�u��
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    isHolding = true;
        //    holdStartTime = Time.time;
        //}

        //// �L�[�������ꂽ�u�Ԃ܂��͕K�v�Ȓ��������Ԃ��o�߂����ꍇ
        //if (Input.GetKeyUp(KeyCode.M) || (isHolding && Time.time - holdStartTime >= requiredHoldTime))
        //{
        //    //���d�@�N���̏������s
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

                Debug.Log("���d�@�̏���");
                _isHolding = false;
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
