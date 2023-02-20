using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Player_Control
{
    public enum PlayerAction
    {
        None,
        Deselect,
        OpenMenu
    }

    public static class PAFunctions
    {
        /// <summary>
        /// Uses regex to convert string, to PlayerAction
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static PlayerAction PlayerActionFromString(string action)
        {
            var deselect = new Regex(@"(?i)\b\s*d\s*e\s*s\s*e\s*l\s*e\s*c\s*t\s*\b");

            if (deselect.IsMatch(action))
            {
                return PlayerAction.Deselect;
            }

            var openMenu = new Regex(@"(?i)\b\s*o\s*p\s*e\s*n\s*[_-]?\s*m\s*e\s*n\s*u\s*\b");

            return openMenu.IsMatch(action) ? PlayerAction.OpenMenu : PlayerAction.None;
        }

        /// <summary>
        /// Converts string to KeyCode
        /// </summary>
        /// <param name="keycode"></param>
        /// <returns></returns>
        public static KeyCode KeyCodeFromString(string keycode)
        {
            if (Enum.TryParse(typeof(KeyCode), keycode, out var res))
            {
                return (KeyCode)res;
            }

            return KeyCode.None;
        }
    }
}
