using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour {
    public IntVector2 coordinates;
    private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.COUNT];
    private int initEdgeCount;
    public bool IsFullyInitialized => initEdgeCount == MazeDirections.COUNT;

    public MazeCellEdge GetEdge(MazeDirection dir) {
        return edges[(int) dir];
    }
    
    public void SetEdge(MazeDirection direction, MazeCellEdge edge) {
        edges[(int) direction] = edge;
        initEdgeCount += 1;
    }

    public MazeDirection RandomUninitDir {
        get {
            int skips = Random.Range(0, MazeDirections.COUNT - initEdgeCount);
            for (int i = 0; i < MazeDirections.COUNT; i++) {
                if (edges[i] == null) {
                    if (skips == 0) {
                        return (MazeDirection) i;
                    }
                    skips -= 1;
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
        }
    }

}