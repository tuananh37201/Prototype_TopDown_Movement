using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EdgeGenerator
{
    public static void CreateEdge(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer){
        var basicEdgePositions = FindEdgesInDirection(floorPositions, Direction2D.cardinalDirectionsList);
        
        foreach  (var position in basicEdgePositions){
            tilemapVisualizer.PaintSingleBasicEdge(position);
        }
    }

    private static HashSet<Vector2Int> FindEdgesInDirection(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> edgePositions = new HashSet<Vector2Int>();

        // * Nếu ô ở cạnh một ô là ô trống thì đó là edge
        foreach (var position in floorPositions){
            foreach (var direction in directionsList){
                var neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition) == false){
                    edgePositions.Add(neighbourPosition);
                }
            }
        }
        return edgePositions;
    }
}
