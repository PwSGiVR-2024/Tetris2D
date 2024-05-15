using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Tablica tablica;
    public Tetrodata data;
    public Vector3Int position;
    public Vector3Int[] kratka;
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
}
