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
            case NodeState.End:
                floor.material.color = Color.red;
                break;
            case NodeState.PickUp:
                floor.material.color = Color.yellow;
                break;
        }
    }
}
