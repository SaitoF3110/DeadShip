using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemystan : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] GameObject defa = default;
    [SerializeField] float _stanTime = 5;
    AudioSource _audioSource;
    public enemyasset _enemyData;//�G�l�~�[�A�Z�b�g����v���n�u�Ăяo��
    float _timer;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _stanTime)
        {
            Instantiate(_enemyData.enemy1,this.transform.position,this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
