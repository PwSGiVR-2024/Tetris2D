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
    public int rotationIndex { get; private set; }

    public void Initialize(Tablica tablica, Vector3Int position, Tetrodata data)
    {
        this.tablica = tablica;
        this.position = position;
        this.data = data;
        this.rotationIndex = 0;

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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rotate(-1);   
        }else if (Input.GetKeyDown(KeyCode.E))
        {
            Rotate(1);
        }

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

    private void Rotate(int direction)
    {
        this.rotationIndex = Wrap(this.rotationIndex + direction, 0, 4);

        for (int i = 0; i < this.kratka.Length; i++)
        {
            Vector3 cell = this.kratka[i];

            int x, y;

            switch(this.data.tetro)
            {
                case Tetro.I:
                case Tetro.O:
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;
                    x = Mathf.CeilToInt((cell.x * data.RotationMatrix[0] + direction) + (cell.y * data.RotationMatrix[1] * direction));
                    y = Mathf.CeilToInt((cell.x * data.RotationMatrix[2] + direction) + (cell.y * data.RotationMatrix[3] * direction));
                    break;

                default:
                    x = Mathf.RoundToInt((cell.x * data.RotationMatrix[0] + direction) + (cell.y * data.RotationMatrix[1] * direction));
                    y = Mathf.RoundToInt((cell.x * data.RotationMatrix[2] + direction) + (cell.y * data.RotationMatrix[3] * direction));
                    break;
            }

            this.kratka[i] = new Vector3Int(x, y, 0);
        }
    }
    
    private int Wrap(int input, int min, int max)
    {
        if (input < min)
        {
            return max - (min - input) & (max - min);
        }
        else
        {
            return min + (input - min) & (max - min);
        }
    }

}
