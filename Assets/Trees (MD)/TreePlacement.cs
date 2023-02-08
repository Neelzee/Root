using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class TreePlacement : MonoBehaviour
{
    [SerializeField] 
    private GameObject treeType;
    private GameObject _currentTree;
    [SerializeField]
    private Tilemap tilemap;

    private void Start()
    {
        
    }
    private void HoldTree(GameObject obj = null)
    {
        var newTree = Instantiate(obj, transform);
        _currentTree = newTree;
    }

    private GameObject CheckForTree(Vector3Int cellPos)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            if (child.name == "Tree: " + cellPos)
            {
                return child;
            }
        }
        return null;
    }
    
    private void Update()
    {
        //Finds the mouse position and translate it
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var holdPos = new Vector3(mousePos.x, mousePos.y, 0);
        
        // For testing, this will be handled with an UI later.
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_currentTree != null)
            {
                Destroy(_currentTree);
            }
            HoldTree(treeType);
        }
        
        // Places the tree if Mouse0 is pressed, change this to accomodate for keybinding options.
        if (_currentTree != null)
        {
            _currentTree.transform.position = holdPos;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var cellPos = tilemap.WorldToCell(holdPos);
                if (CheckForTree(cellPos) == null)
                {
                    _currentTree.transform.position = tilemap.GetCellCenterWorld(cellPos);
                    tilemap.SetTile(cellPos, _currentTree.GetComponent<TreeInfo>().getTile());
                    _currentTree.name = "Tree: " + cellPos;
                    _currentTree.GetComponent<SpriteRenderer>().enabled = false;
                    _currentTree = null;   
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Destroy(_currentTree);
            }
        }
        else
        {   
            // Checks if the player clicks on a tile with a tree
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var cellPos = tilemap.WorldToCell(holdPos);
                GameObject selectedTree = CheckForTree(cellPos);
            }
        }
    }
}
