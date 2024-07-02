using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, edgeTilemap;
    [SerializeField]
    private TileBase floorTile, edgeTop;

    public void PaintFLoorTile(IEnumerable<Vector2Int> floorPositions){
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions){
            PaintSingleTile(tilemap, tile, position);
        }
    }

    internal void PaintSingleBasicEdge(Vector2Int position)
    {
        PaintSingleTile(edgeTilemap, edgeTop, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear(){
        floorTilemap.ClearAllTiles();
        edgeTilemap.ClearAllTiles();
    }
}
