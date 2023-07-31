using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //ミッション2で指定している長押し時間
    public float _missionTimer = 10f;
    //ミッション2で長押し時間を計測するタイマー
    private float _missionCounter = 0;
    //ミッション2で長押しを判定する変数
    private bool _isPush = false;
    //ミッション2でクリアを判定する変数
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
