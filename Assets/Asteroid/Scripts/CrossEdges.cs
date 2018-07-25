using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class CrossEdges : MonoBehaviour
{
    void OnBecameInvisible()
    {
        //TODO fix: this behaviour is different from original game ???
        transform.position = transform.position * -1;
    }
}
