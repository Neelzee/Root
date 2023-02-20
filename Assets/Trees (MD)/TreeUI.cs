using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeUI : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionMenu;

    [SerializeField] private GameObject openArrow;
    
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
}
