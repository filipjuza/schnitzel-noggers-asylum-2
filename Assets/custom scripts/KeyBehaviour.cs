using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Leap.Unity.Interaction;

public class KeyBehaviour : MonoBehaviour
{
    private float minRotation = 250f;
    private float maxRotation = 290f;
    public bool inFinalRotation;
    public bool attached;
    private bool puzzleFinished = false;
    private Rigidbody keyRigidbody;
    private InteractionBehaviour interactionBehaviour;
    private AnchorableBehaviour anchorableBehaviour;

    private void Start()
    {
        inFinalRotation = false;
        attached = false;
        keyRigidbody = GetComponent<Rigidbody>();
        interactionBehaviour = GetComponent<InteractionBehaviour>();
        anchorableBehaviour = GetComponent<AnchorableBehaviour>();
    }

    private void Update()
    {
        if (!puzzleFinished && attached)
        {
            if (inFinalRotation)
            {
                anchorableBehaviour.anchorRotation = false;
                transform.eulerAngles = new Vector3(270, 180, 0);
                keyRigidbody.constraints = RigidbodyConstraints.FreezeAll;
                puzzleFinished = true;
            } else
            {
                var rotation = transform.rotation.eulerAngles.x;

                if (rotation >= minRotation && rotation <= maxRotation)
                {
                    inFinalRotation = true;
                    interactionBehaviour.ignoreGrasping = true;
                    SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
                    Debug.Log("Waduhek you win.");
                }
            }
        }
    }

    public void onKeyAttached()
    {
        if (!inFinalRotation)
        {
            Debug.Log("key attached");
            attached = true;
            keyRigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
