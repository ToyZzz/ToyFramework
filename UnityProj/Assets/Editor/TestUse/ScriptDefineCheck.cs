using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptDefineCheck
{
	[MenuItem("MineTest/TestSimulateMarco")]
	public static void TestSimulateMarco()
	{
		List<string> defineSymbolsList = new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(';'));
		foreach (var item in defineSymbolsList)
		{
			Log.D(DebugType.COMMON,item);
		}
		defineSymbolsList.Add("TESTADD");
		PlayerSettings.SetScriptingDefineSymbolsForGroup(
			EditorUserBuildSettings.selectedBuildTargetGroup,
			string.Join(";", defineSymbolsList.ToArray())
			);
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	}
}
