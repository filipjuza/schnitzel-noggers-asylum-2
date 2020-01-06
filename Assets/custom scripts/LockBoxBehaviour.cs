using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;

public class LockBoxBehaviour : MonoBehaviour
{
    public bool isUnlocked;
    public bool claspButton1Active;
    public bool claspButton2Active;
    public GameObject clasp1;
    public GameObject clasp2;
    public GameObject handle;
    public GameObject chain;

    private HingeJoint claspHinge1;
    private HingeJoint claspHinge2;
    private InteractionBehaviour handleInteraction;
    private bool claspsUnlocked = false;
    private void Start()
    {
        claspHinge1 = clasp1.GetComponent<HingeJoint>();
        claspHinge2 = clasp2.GetComponent<HingeJoint>();
        handleInteraction = handle.GetComponent<InteractionBehaviour>();
        Debug.Log(claspHinge1);
        Debug.Log(claspHinge2);
    }

    private void Update()
    {
        if (!claspsUnlocked && claspButton1Active && claspButton2Active) {
            claspHinge1.useMotor = true;
            claspHinge2.useMotor = true;
            claspsUnlocked = true;
        }

        // After an object is destroyed, an equality check with null will return true
        if (!isUnlocked && claspsUnlocked && chain == null)
        {
            handleInteraction.ignoreGrasping = false;
            isUnlocked = true;
        }
    }

    public void claspButton1Press()
    {
        claspButton1Active = true;
    }

    public void claspButton1Unpress()
    {
        claspButton1Active = false;
    }

    public void claspButton2Press()
    {
        claspButton2Active = true;
    }

    public void claspButton2Unpress()
    {
        claspButton2Active = false;
    }
}
