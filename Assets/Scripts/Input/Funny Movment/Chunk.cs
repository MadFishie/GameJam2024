using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Chunk 
{
    public Vector3 position;
    public Quaternion rotation;

    public Chunk(Vector3 pos, Quaternion rot) 
    {
        position = pos;
        rotation = rot;
    }

}
