using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManagment : MonoBehaviour
{
    [SerializeField]public List<Chunk> chunks=new List<Chunk>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateChunksLoaded();
    }

    public void UpdateChunksLoaded() 
    {
        chunks.Add(new Chunk(transform.position, transform.rotation));
    }

    public void ClearChunksLoaded()
    {
        chunks.Clear();
        chunks.Add(new Chunk(transform.position, transform.rotation));
    }


}
