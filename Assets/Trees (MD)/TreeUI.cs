using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TreeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionMenu;

    [SerializeField] private GameObject openArrow;
    [SerializeField] private TextMeshProUGUI treeName;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleSelection()
    {
        selectionMenu.SetActive(!selectionMenu.activeSelf);
        openArrow.SetActive(!openArrow.activeSelf);
    }
    
    /**
     * This function, gets information about a tree, and displays it to the UI
     * it is used to view Tree stats, by selecting trees.
     */
    public void treeSelection(GameObject tree)
    {
        if (tree == null)
        {
            treeName.text = "";
        }
        else
        {
            treeName.text = tree.gameObject.GetComponent<TreeInfo>().treeName;
        }
    }
}
