using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public static class GameExtensions
{
    public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
    {
        var startEntity = cells[position];

        if (!startEntity.Has<TakenSign>())
        {
            return 0;
        }
        
        var startType = startEntity.Ref<TakenSign>().Unref().Sign;
        
        var horizontalLength = 1;
        horizontalLength = CheckLineLength(cells, startType, horizontalLength, new Vector2Int(-1, 0), position);
        horizontalLength = CheckLineLength(cells, startType, horizontalLength, new Vector2Int(1, 0), position);

        var verticalLength = 1;
        verticalLength = CheckLineLength(cells, startType, verticalLength, new Vector2Int(0, -1), position);
        verticalLength = CheckLineLength(cells, startType, verticalLength, new Vector2Int(0, 1), position);

        var leftDiagonalLength = 1;
        leftDiagonalLength = CheckLineLength(cells, startType, leftDiagonalLength, new Vector2Int(-1, -1), position);
        leftDiagonalLength = CheckLineLength(cells, startType, leftDiagonalLength, new Vector2Int(1, 1), position);
        
        var rightDiagonalLength = 1;
        rightDiagonalLength = CheckLineLength(cells, startType, rightDiagonalLength, new Vector2Int(-1, 1), position);
        rightDiagonalLength = CheckLineLength(cells, startType, rightDiagonalLength, new Vector2Int(1, -1), position);
        
        return Mathf.Max(verticalLength, horizontalLength, leftDiagonalLength, rightDiagonalLength);
    }

    private static int CheckLineLength(Dictionary<Vector2Int, EcsEntity> cells, SignType startType, int currentLength,
        Vector2Int direction, Vector2Int position)
    {
        var currentPosition = position + direction;
        
        while (cells.TryGetValue(currentPosition, out var entity))
        {
            if (!entity.Has<TakenSign>())
            {
                break;
            }

            var type = entity.Ref<TakenSign>().Unref().Sign;
            if (type != startType)
            {
                break;
            }

            currentLength++;
            currentPosition += direction;
        }

        return currentLength;
    }
}