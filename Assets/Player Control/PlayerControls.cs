using System;
using System.Collections.Generic;
using Player_Control;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Contains all key binds that the player uses across the game
/// </summary>
public static class PlayerControls
{
    private const string FileName = "keybinds.json";
    
    private static Dictionary<PlayerAction, KeyCode> _keyBinds = new();

    public static Dictionary<PlayerAction, KeyCode> KeyBinds => _keyBinds;

    /// <summary>
    /// Loads key binds from file
    /// </summary>
    public static void LoadKeys()
    {
        // Change to a function call that returns a dict of the loaded key binds
        // ie. from a JSON file
        var json = System.IO.File.ReadAllText(Application.persistentDataPath + "/" + FileName);
        _keyBinds = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<PlayerAction, KeyCode>>(json);
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
    /// Saves the current key binds, to a JSON file.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public static void SaveKeyBinds()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(_keyBinds);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + FileName, json);
    }
}
