using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
     float size;
    // Start is called before the first frame update

    void Start()
    {
        size=  Camera.main.orthographicSize;
        Vector3 campos = new Vector3(size - .5f, size - .5f,-10);
        transform.localPosition = campos;
    }

    // Update is called once per frame
   
}
