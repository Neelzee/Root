using UnityEngine;

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

    public void SwitchState(CityBaseState state)
    {
	    _currentState.ExitState(this, _city);
	    _currentState = state;
	    state.EnterState(this, _city);
    }
}
