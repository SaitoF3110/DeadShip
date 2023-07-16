using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite _attack;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            _spriteRenderer.sprite = _attack;
        }
    }
}
