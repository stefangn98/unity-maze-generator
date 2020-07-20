using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MazeCellEdge : MonoBehaviour {
    public MazeCell cell, otherCell;

    public MazeDirection dir;

    public void Initialize(MazeCell cell, MazeCell otherCell, MazeDirection dir) {
        this.cell = cell;
        this.otherCell = otherCell;
        this.dir = dir;
        cell.SetEdge(dir, this);
        transform.parent = cell.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = dir.ToRotation();
    }
}