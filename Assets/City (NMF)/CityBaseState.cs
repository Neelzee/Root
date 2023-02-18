/// <summary>
/// Abstract CityState, all City States inherit from this class.
/// <para>
/// <c>Author: Nils Michael</c>
/// </para>
/// </summary>
public abstract class CityBaseState
{
    /// <summary>
    /// Called when the City enters the state
    /// </summary>
    /// <param name="context"></param>
    /// <param name="city"></param>
    public abstract void EnterState(CityStateManager context, City city);
    
    /// <summary>
    /// Called every frame, in the Update function
    /// </summary>
    /// <param name="context"></param>
    /// <param name="city"></param>
    public abstract void UpdateState(CityStateManager context, City city);
    
    /// <summary>
    /// Called before the new state is entered.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="city"></param>
    public abstract void ExitState(CityStateManager context, City city);
}
