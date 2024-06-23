using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithms
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLenght){
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();
        path.Add(startPosition);
        var previosPosition = startPosition;

        for (int i = 0; i < walkLenght; i++)
        {
            var newPosition = previosPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previosPosition = newPosition;
        }
        return path;
    }
}

public static class Direction2D{
    public static List<Vector2Int> cardinalDirections = new List<Vector2Int>(){
        new Vector2Int(0, 1),   //UP
        new Vector2Int(1, 0),   //RIGHT
        new Vector2Int(0, -1),  //DOWN
        new Vector2Int(-1, 0)   //LEFT
    };

    public static Vector2Int GetRandomCardinalDirection(){
        return cardinalDirections[Random.Range(0, cardinalDirections.Count)];
    }
}
