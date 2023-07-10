using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemystan : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] GameObject defa = default;
    [SerializeField] float _stanTime = 5;
    public enemyasset _enemyData;//エネミーアセットからプレハブ呼び出し
    float _timer;
    void Start()
    {
        
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
