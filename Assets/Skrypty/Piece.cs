using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Piece : MonoBehaviour
{
    public Tablica tablica;
    public Tetrodata data;
    public Vector3Int position;
    public Vector3Int[] kratka;
    public Tilemap tilemap;
    public void Initialize(Tablica tablica, Vector3Int position, Tetrodata data)
    {
        this.tablica = tablica;
        this.position = position;
        this.data = data;
        if (this.kratka == null)
        {
            this.kratka = new Vector3Int[data.kratka.Length];
        }

        for (int i = 0; i < data.kratka.Length; i++)
        {
            this.kratka[i] = (Vector3Int)data.kratka[i];
        }

    }

    private void Update()
    {
        this.tablica.Clear(this);

        if ( Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2Int.down);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HardDrop();
        }
    }

    private void HardDrop()
    {
        while (Move(Vector2Int.down))
        {
            continue;
        }
    }

    private bool Move(Vector2Int translation)
    {
        Vector3Int newPosition = this.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;

        bool valid = this.tablica.IsValidPosition(this, newPosition);
        if (valid)
        {
            this.position = newPosition;
        }

        return valid;
    }

    
}
