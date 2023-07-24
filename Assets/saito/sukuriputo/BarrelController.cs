using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    bool _playerIn = false;
    bool _enter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerIn && Input.GetKeyDown(KeyCode.Return))
        {
            _playerIn = false;
            GameObject player = GameObject.Find("Player");
            player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            player.tag = "Player";
            move move = player.GetComponent<move>();
            move._canMove = true;
        }
        else if (_enter &&  Input.GetKeyDown(KeyCode.Return) && !_playerIn)
        {
            _playerIn = true;
            GameObject player = GameObject.Find("Player");
            player.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            player.tag = "Hide";
            move move = player.GetComponent<move>();
            move._canMove = false;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enter = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enter = false;
        }
    }
}
