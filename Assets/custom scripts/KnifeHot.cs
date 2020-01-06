using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHot : MonoBehaviour
{
     
    public bool hot = false;
    public bool done = false;
    public Material hotMaterial;
    public GameObject knifeBlade;

    private MeshRenderer bladeMeshRenderer;

    void Start()
    {
        bladeMeshRenderer = knifeBlade.GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (hot && !done)
        {
            bladeMeshRenderer.material = hotMaterial;
            done = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hot && collision.collider.gameObject.CompareTag("destroy"))
        {
            Destroy(collision.collider.gameObject);
        }

    }
}
