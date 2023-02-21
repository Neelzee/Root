using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

/// <summary>
/// City State Manager, ensures correct starting state is entered, upon city initialization,
/// and that correct enter and exit methods are called when each state fulfill their requirements.
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
[RequireComponent(typeof(City))]
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
    private readonly CitySiege _cSiege = new();

    public CityBaseState CurrentState => _currentState;
	
    /// <summary>
    /// City that is occupied by the Military
    /// </summary>
    public CityMilitaryOccupied CMilitaryOccupied => _cMilitaryOccupied;

    /// <summary>
    /// City that is under hostile attack by the player
    /// </summary>
    public CityHostileTakeOver CHostileTakeOver => _cHostileTakeOver;

    /// <summary>
    /// City that is scared due to to player action (high Climate Awareness value)
    /// </summary>
    public CityScared CScared => _cScared;

    /// <summary>
    /// City that is being taken over by the player, stealthily
    /// </summary>
    public CityStealthTakeOver CStealthTakeOver => _cStealthTakeOver;

    /// <summary>
    /// City that is thriving
    /// </summary>
    public CityThriving CThriving => _cThriving;

    /// <summary>
    /// City that is occupied by the player
    /// </summary>
    public CityTreeOccupied CTreeOccupied => _cTreeOccupied;

    /// <summary>
    /// City that has military assistance, but under siege by the player
    /// </summary>
    public CitySiege CSiege => _cSiege;

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

    public void SwitchState(CityBaseState state, object args = null)
    {
	    _currentState.ExitState(this, _city);
	    _currentState = state;
	    state.EnterState(this, _city, args);
    }
}
