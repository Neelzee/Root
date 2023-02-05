using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.Serialization;

public class NavMeshBuilder : MonoBehaviour
{ 
    [SerializeField] private NavMeshSurface surface;
    
    // Start is called before the first frame update
    void Start()
    {
        surface.BuildNavMeshAsync();
    }
}
