using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Tablica : MonoBehaviour
{
    public Tilemap tilemap;
    public Tetrodata[] tetrisy;
    public Piece activePiece;
    public Vector3Int spawnPosition;
    public Vector2Int boardSize = new Vector2Int(10, 20);

    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-this.boardSize.x / 2, -this.boardSize.y / 2); 
            return new RectInt(position, this.boardSize);
        }
    }
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

    public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.kratka.Length; i++)
        {
            Vector3Int tilePosition = piece.kratka[i] + piece.position;
            this.tilemap.SetTile(tilePosition, null);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = this.Bounds;
        for (int i = 0; i < piece.kratka.Length; i++)
        {
            Vector3Int tilePosition = piece.kratka[i] + position;

            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }

        return true;
    }

}
