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
    private Vector3Int _lastCellPos;
    [SerializeField]
    private Tilemap tilemap;

    [SerializeField] private Tilemap highlightMap;

    [SerializeField] private Tile _highlight;

    private void Start()
    {
        
    }
    public void HoldTree(GameObject obj = null)
    {
        var newTree = Instantiate(obj, transform);
        _currentTree = newTree;
    }

    private GameObject CheckOccupied(Vector3Int cellPos)
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
    
    /*
     * Returns the info of the Tree which the user hovers and clicks on.
     */
    private TreeInfo SelectTree()
    {
        return null;
    }
    
    private void Update()
    {
        //Finds the mouse position and translate it
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var holdPos = new Vector3(mousePos.x, mousePos.y, 0);
        var cellPos = tilemap.WorldToCell(holdPos);
        bool isOccupied = CheckOccupied(cellPos);
        
        // For testing, this will be handled with an UI later.
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_currentTree != null)
            {
                Destroy(_currentTree);
            }
            HoldTree(treeType);
            _currentTree.transform.position = tilemap.GetCellCenterWorld(cellPos);;
            highlightMap.SetTile(cellPos, _highlight);
        }

        if (isOccupied)
        {
            _highlight.color = Color.red;
        }
        else
        {
            _highlight.color = Color.white;
        }
        
        // Places the tree if Mouse0 is pressed, change this to accomodate for keybinding options.
        if (_currentTree != null)
        {
            _currentTree.transform.position = tilemap.GetCellCenterWorld(cellPos);;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (CheckOccupied(cellPos) == null)
                {
                    _currentTree.transform.position = tilemap.GetCellCenterWorld(cellPos);
                    tilemap.SetTile(cellPos, _currentTree.GetComponent<TreeInfo>().getTile());
                    _currentTree.name = "Tree: " + cellPos;
                    _currentTree.GetComponent<SpriteRenderer>().enabled = false;
                    _currentTree = null;   
                    highlightMap.SetTile(_lastCellPos, null);
                }
            }
            else
            {
                if (cellPos != _lastCellPos)
                {
                    highlightMap.SetTile(_lastCellPos, null);
                    highlightMap.SetTile(cellPos, _highlight);
                    _lastCellPos = cellPos;
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Destroy(_currentTree);
                highlightMap.SetTile(_lastCellPos, null);
            }
        }
        else
        {   
            // Checks if the player clicks on a tile with a tree
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject selectedTree = CheckOccupied(cellPos);
            }
        }
    }
}
