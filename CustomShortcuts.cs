using UnityEditor;
using System;
using System.Reflection;

static class CustomShortcuts
{
    // taken from: http://answers.unity3d.com/questions/282959/set-inspector-lock-by-code.html
    [MenuItem("Tools/Toggle Inspector Lock %r")] // Ctrl + L
    static void ToggleInspectorLock()
    {
        ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
        ActiveEditorTracker.sharedTracker.ForceRebuild();
    }

    [MenuItem("Tools/Clear Console &c")]
    static void ClearConsole()
    {
        // This simply does "LogEntries.Clear()" the long way:
        var logEntries = Type.GetType("UnityEditor.LogEntries,UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }
}
