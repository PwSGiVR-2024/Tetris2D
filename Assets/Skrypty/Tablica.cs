using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tablica : MonoBehaviour
{
    public Tilemap tilemap;
    public Tetrodata[] tetrisy;
    private void Awake()
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        for (int i = 0; i < tetrisy.Length; i++)
        {
            this.tetrisy[i].Initialize();
        }
    }

    public void Start()
    {
        Spawnelement();
    }
    public void Spawnelement()
    {
        int random = Random.Range(0, this.tetrisy.Length);
        Tetrodata data = this.tetrisy[random];

    }

    public void Set()
    {

    }

}
