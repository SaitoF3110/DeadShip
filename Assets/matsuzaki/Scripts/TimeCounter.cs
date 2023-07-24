using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{   
    //�������Ԃ̐ݒ�
    [SerializeField] int countdownMinutes = 5;
    //
    private float countdownSeconds;
    //
    GameObject TimerText = default;
    //
    GameObject BackGround = default;

    void Start()
    {
        //
        TimerText = GameObject.Find("Timer");
        //
        BackGround = GameObject.Find("BackGround");
        //
        Image img = BackGround.GetComponent<Image>();
        //
        img.color = Color.clear;
        //
        countdownSeconds = countdownMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {   
        //
        countdownSeconds -= Time.deltaTime;
        //
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        //
        TimerText.GetComponent<Text>().text = span.ToString(@"mm\:ss");

        //
        if (countdownSeconds <= 10)
        {
            // 0�b�ɂȂ����Ƃ��̏���
            BackGround.GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.1f);
        }
    }
}
