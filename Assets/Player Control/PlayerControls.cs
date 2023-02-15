using System;
using System.Collections.Generic;
using Player_Control;
using UnityEngine;

/// <summary>
/// Contains all key binds that the player uses across the game
/// </summary>
public static class PlayerControls
{
    private static Dictionary<PlayerAction, KeyCode> _keyBinds = new();

    public static Dictionary<PlayerAction, KeyCode> KeyBinds => _keyBinds;

    /// <summary>
    /// TODO: Implement
    /// Loads key binds from file
    /// </summary>
    public static void LoadKeys()
    {
        // Change to a function call that returns a dict of the loaded keybinds
        // ie. from a JSON file
        var keybinds = new Dictionary<string, string>();
        foreach (var (k, v) in keybinds)
        {
            var key = PAFunctions.PlayerActionFromString(k);
            var val = PAFunctions.KeyCodeFromString(v);
            _keyBinds[key] = val;
        }
    }

    /// <summary>
    /// Sets the given action to the given keycode
    /// </summary>
    /// <param name="action">Action to set key bind</param>
    /// <param name="key">key bind</param>
    public static void ReplaceKey(PlayerAction action, KeyCode key)
    {
        _keyBinds[action] = key;
    }

    /// <summary>
    /// TODO: Implement
    /// Saves the current key binds, to a JSON file.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public static void SaveKeyBinds()
    {
        throw new NotImplementedException();
    }
}
