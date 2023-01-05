using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Available,
    Current,
    Completed,
    Start,
    PickUp,
    End
}

public class MazeNode : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] MeshRenderer floor;

    public void RemoveWall(int wallToRemove)
    {
        walls[wallToRemove].gameObject.SetActive(false);
    }

    public void setState(NodeState state)
    {
        switch(state)
        {
            case NodeState.Available:
                floor.material.color = Color.white;
                break;
            case NodeState.Current:
                floor.material.color = Color.yellow;
                break;
            case NodeState.Completed:
                floor.material.color = Color.blue;
                break;
            case NodeState.Start:
                floor.material.color = Color.red;
                break;
            case NodeState.End:
                floor.material.color = Color.green;
                break;
            case NodeState.PickUp:
                floor.material.color = Color.black;
                break;
        }
    }
}
