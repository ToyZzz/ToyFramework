using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text.RegularExpressions;

public class LogRedirect
{
#if UNITY_EDITOR
    private const string LogScriptName = "Log.cs";

    private const string LogDebugFuncStr = "Log:D";
    private const string LogErrorFuncStr = "Log:E";

    //双击控制台log重定向
    [UnityEditor.Callbacks.OnOpenAssetAttribute(0)]
	static bool OnOpenAsset(int instanceID, int line)
	{
		if (!EditorWindow.focusedWindow.titleContent.text.Equals("Console"))
			return false;

		string stackTrace = GetStackTrace();
		if (!string.IsNullOrEmpty(stackTrace) && (stackTrace.Contains(LogDebugFuncStr) || stackTrace.Contains(LogErrorFuncStr)))
		{
			Match matches = Regex.Match(stackTrace, @"\(at (.+)\)", RegexOptions.IgnoreCase);
			string pathline = "";
			while (matches.Success)
			{
				pathline = matches.Groups[1].Value;
				if (!pathline.Contains(LogScriptName))
				{
					int splitIndex = pathline.LastIndexOf(":");
					string path = pathline.Substring(0, splitIndex);
					line = System.Convert.ToInt32(pathline.Substring(splitIndex + 1));
					string fullPath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("Assets"));
					fullPath += path;
					UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(fullPath.Replace('/', '\\'), line);
					break;
				}
				matches = matches.NextMatch();
			}
			return true;
		}
		return false;
	}

	static string GetStackTrace()
	{
		var ConsoleWindowType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ConsoleWindow");
		var fieldInfo = ConsoleWindowType.GetField("ms_ConsoleWindow", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
		var consolewindowInstance = fieldInfo.GetValue(null);
		if (consolewindowInstance != null)
		{
			if ((object)EditorWindow.focusedWindow == consolewindowInstance)
			{
				var ListViewStateType = typeof(EditorWindow).Assembly.GetType("UnityEditor.ListViewState");
				fieldInfo = ConsoleWindowType.GetField("m_ListView", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
				var listView = fieldInfo.GetValue(consolewindowInstance);

				fieldInfo = ListViewStateType.GetField("row", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
				int row = (int)fieldInfo.GetValue(listView);

				fieldInfo = ConsoleWindowType.GetField("m_ActiveText", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
				string activeText = fieldInfo.GetValue(consolewindowInstance).ToString();
				return activeText;
			}
		}
		return "";
	}
#endif
}