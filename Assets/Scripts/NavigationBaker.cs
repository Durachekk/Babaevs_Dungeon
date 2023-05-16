using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{

    public NavMeshSurface surfaces;

    public void UpdateBake()
    {
        surfaces.BuildNavMesh();
    }

}