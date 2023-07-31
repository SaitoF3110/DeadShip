using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //�~�b�V����2�Ŏw�肵�Ă��钷��������
    public float _missionTimer = 10f;
    //�~�b�V����2�Œ��������Ԃ��v������^�C�}�[
    private float _missionCounter = 0;
    //�~�b�V����2�Œ������𔻒肷��ϐ�
    private bool _isPush = false;
    //�~�b�V����2�ŃN���A�𔻒肷��ϐ�
    private bool _isClear = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(_isPush && Input.GetKey(KeyCode.M))
        {
            _missionCounter += Time.deltaTime;

            if(_missionCounter >= _missionTimer )
            {
                _isClear = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") _isPush = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isPush = false;
            _missionCounter = 0;
        }
    }
}
