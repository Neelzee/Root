using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityStateManager : MonoBehaviour
{
    private CityBaseState _currentState;

    private City _city;

    private readonly CityMilitaryOccupied _cMilitaryOccupied = new();
    private readonly CityHostileTakeOver _cHostileTakeOver = new();
    private readonly CityScared _cScared = new();
    private readonly CityStealthTakeOver _cStealthTakeOver = new();
    private readonly CityThriving _cThriving = new();
    private readonly CityTreeOccupied _cTreeOccupied = new();

    public CityBaseState CurrentState => _currentState;

    public CityMilitaryOccupied CMilitaryOccupied => _cMilitaryOccupied;

    public CityHostileTakeOver CHostileTakeOver => _cHostileTakeOver;

    public CityScared CScared => _cScared;

    public CityStealthTakeOver CStealthTakeOver => _cStealthTakeOver;

    public CityThriving CThriving => _cThriving;

    public CityTreeOccupied CTreeOccupied => _cTreeOccupied;

    private void Start()
    {
	    _city = GetComponent<City>();
	    _currentState = _cThriving;
	    _currentState.EnterState(this, _city);
    }

    private void Update()
    {
	    _currentState.UpdateState(this, _city);
    }

    private void SwitchState(CityBaseState state)
    {
	    _currentState.ExitState(this, _city);
	    _currentState = state;
	    state.EnterState(this, _city);
    }
}
