using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHub : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResourceManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        // Testing Resource Management
        if(Input.GetKeyDown(KeyCode.A)) {
            // Add to resource
            ResourceManager.AddResourceAmount(Resource.Energy, 100);
            Debug.Log(ResourceManager.GetResourceAmount(Resource.Energy));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Try to spend resources (for example if you try to place a building)
            ResourceManager.TrySpendResourcesCost(Resource.Energy, 400);
            Debug.Log(ResourceManager.GetResourceAmount(Resource.Energy));
        }
    }
}
