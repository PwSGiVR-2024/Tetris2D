using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tablica : MonoBehaviour
{
    public Tilemap tilemap;
    public Tetrodata[] tetrisy;
    public Piece activePiece;
    public Vector3Int spawnPosition;
    private void Awake()
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();
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
        this.activePiece.Initialize(this, this.spawnPosition, data);
        Set(this.activePiece);
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.kratka.Length; i++)
        {
            Vector3Int tilePosition = piece.kratka[i] + piece.position;
            this.tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }


}
