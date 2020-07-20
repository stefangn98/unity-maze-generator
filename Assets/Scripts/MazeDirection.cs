using UnityEngine;

public enum MazeDirection {
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public static class MazeDirections {
    public const int COUNT = 4;

    public static MazeDirection RandomDirection => (MazeDirection) Random.Range(0, COUNT);

    // used to represent directions as integers
    private static IntVector2[] _vector2S = {
        new IntVector2(0, 1),
        new IntVector2(1, 0),
        new IntVector2(0, -1),
        new IntVector2(-1, 0)
    };

    private static MazeDirection[] opposites = {
        MazeDirection.South,
        MazeDirection.West,
        MazeDirection.North,
        MazeDirection.East
    };

    private static Quaternion[] rotations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 90f, 0f),
        Quaternion.Euler(0f, 180f, 0f),
        Quaternion.Euler(0f, 270f, 0f)
    };

    public static IntVector2 ToIntVector2(this MazeDirection direction) {
        return _vector2S[(int) direction];
    }

    public static MazeDirection GetOpposite(this MazeDirection direction) {
        return opposites[(int) direction];
    }

    public static Quaternion ToRotation(this MazeDirection direction) {
        return rotations[(int) direction];
    }
}