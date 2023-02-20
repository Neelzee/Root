using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour {

    private GameObject selectedGameObject;
    private PlayerUnitMovement unitMovement;

    private void Awake() {
        selectedGameObject = transform.Find("Selected").gameObject;
        unitMovement = GetComponent<PlayerUnitMovement>();
        SetSelectedVisible(false);
    }

    public void SetSelectedVisible(bool visible) {
        selectedGameObject.SetActive(visible);
    }

    public void MoveTo(Vector3 targetPosition) {
        unitMovement.MoveTo(targetPosition);
    }

}
