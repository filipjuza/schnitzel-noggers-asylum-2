using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWindow : MonoBehaviour
{
    public bool switch1;
    public bool switch2;
    public bool complete = false;
    public HingeJoint joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (switch1 && switch2)
        {
            complete = true;
        }
        if (complete)
        {
            joint.useMotor = true;
        }
        
    }
    public void btn1press()
    {
        switch1 = true;
    }
    public void btn1unpress()
    {
        switch1 = false;
    }
    public void btn2press()
    {
        switch2 = true;
    }
    public void btn2unpress()
    {
        switch2 = false;
    }
}
