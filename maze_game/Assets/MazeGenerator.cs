using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_generator : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab; 
    [SerializeField] Vector2Int mazeSize;

    private void Start()
    { 
        startCoroutine(GenerateMaze(mazeSize));
    }

    IEnumerator GenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        //create notes
        for (int x = 0; x < size; x++)
        {
            for(int y = 0; y < size; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x/2f), 0, y - (size.y/2f));
                MazeNode newNode = Instantiate(modePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);

                yield return null;
            }
        }
    }
}
