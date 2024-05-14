using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Tetro //zdefiniowanie
{
    T,
    O,
    L,
    J,
    I,
    S,
    Z,
}

[System.Serializable]
public struct Tetrodata
{
    public Tetro tetro;
    public Tile tile;
    public Vector2Int[] kratka;
    public void Initialize()
    { this.kratka = Dane.kratka[this.tetro]; }
}