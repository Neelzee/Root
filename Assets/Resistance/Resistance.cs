using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistance : MonoBehaviour
{
    /// <summary>
    /// Ranges from 0 to 1
    /// </summary>
    private static float _resistanceValue;

    /// <summary>
    /// The Resistance Value, ranges from 0 to 1
    /// </summary>
    public static float ResistanceValue => _resistanceValue;

    /// <summary>
    /// Adds the given value, to the resistance value
    /// <para>This functions ensures the resistance value is always between 0 and 1 after the given value is added</para>
    /// </summary>
    /// <param name="val"></param>
    public static void Add(float val)
    {
        _resistanceValue = Mathf.Clamp01(_resistanceValue + val);
    }

    /// <summary>
    /// <para>
    /// Scales the value based on the given percentage.
    /// </para>
    /// <para>
    /// ScaleValue(.5f) -> resistance val is increased with 50%
    /// </para>
    /// <para>
    /// ScaleValue(-0.5f) -> resistance val is decreased with 50%
    /// </para>
    /// </summary>
    /// <param name="percentage"></param>
    public static void ScaleValue(float percentage)
    {
        _resistanceValue = Mathf.Clamp01(percentage * _resistanceValue);
    }
}
