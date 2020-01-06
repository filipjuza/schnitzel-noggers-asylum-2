using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Clock : MonoBehaviour
{
    public GameObject knife;
    public GameObject microwave;
    private Text textClock;
    public bool started = false;
    float timeLeft = 20.0f;
    private Vector3 micropos;
    // Start is called before the first frame update
    void Start()
    {
        micropos = microwave.transform.position;
        textClock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {


                textClock.text = "00 : 00";
                timeLeft = 20.0f;
                started = false;
                var knifepos = knife.transform.position;
                var diff = micropos - knifepos;
                if (diff.sqrMagnitude < 1)
                {
                    knife.GetComponent<KnifeHot>().hot = true;
                }

            }
            else
            {

                textClock.text = "00 : " + timeLeft.ToString("00");
                
            }
        } else
        {
            timeLeft = 20.0f;
        }

        
    }
    public void btn1press()
    {
        started = true;
    }

}
