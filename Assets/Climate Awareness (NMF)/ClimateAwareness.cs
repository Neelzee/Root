using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClimateAwareness
{
    /// <summary>
    /// Ranges from 0 to 1
    /// </summary>
    private static float _caValue;

    /// <summary>
    /// The Climate Awareness Value, ranges from 0 to 1
    /// </summary>
    public static float ClimateAwarenessValue => _caValue;

    /// <summary>
    /// Adds the given value, to the climate awareness value
    /// </summary>
    /// <param name="val"></param>
    public static void Add(float val)
    {
        _caValue = Mathf.Clamp01(_caValue + val);
    }

    /// <summary>
    /// <para>
    /// Scales the value based on the given percentage.
    /// </para>
    /// <para>
    /// ScaleValue(1.5f) -> CA val is increased with 50%
    /// </para>
    /// <para>
    /// ScaleValue(0.5f) -> CA val is decreased with 50%
    /// </para>
    /// </summary>
    /// <param name="percentage"></param>
    public static void ScaleValue(float percentage)
    {
        _caValue = Mathf.Clamp01(percentage * _caValue);
    }
}
