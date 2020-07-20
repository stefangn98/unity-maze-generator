using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Maze mazePrefab;
    private Maze _mazeInstance;

    // Start is called before the first frame update
    void Start() {
        BeginGame();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RestartGame();
        }
    }

    private void BeginGame() {
        _mazeInstance = Instantiate(mazePrefab) as Maze;
        StartCoroutine(_mazeInstance.Generate());
    }

    private void RestartGame() {
        StopAllCoroutines();
        Destroy(_mazeInstance.gameObject);
        BeginGame();
    }
}