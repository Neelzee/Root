using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowTreeStats : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject statWindow;
    private int treeCost = 30;
    void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Is Over!");
        statWindow.SetActive(true);
        Rect windowSize = statWindow.GetComponent<RectTransform>().rect;
        statWindow.transform.position = new Vector3(transform.position.x, transform.position.y-(windowSize.height/1.2f), 0);
        statWindow.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Cost:" + treeCost;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exited ui");
        statWindow.SetActive(false);
    }

}
