using System.IO;
using UnityEditor;

public class DataTableImporter : AssetPostprocessor
{
	public static readonly string DataTableRootFolder = "Assets/DataTable/";

	static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFromAssetPaths)
	{
		foreach (var importAsset in imported)
		{
			Log.D(importAsset);
		}

		foreach (var moveAsset in moved)
		{
			Log.D(string.Format("moved -> {0}", moveAsset));
		}
		foreach (var moveFromAsset in movedFromAssetPaths)
		{
			Log.D(string.Format("moved From -> {0}", moveFromAsset));
		}
	}

	[MenuItem("Test/test1")]
	static void Debug()
	{
		Log.D(DebugType.IMPORTER,DataTableImporter.DataTableRootFolder);
		
	}
}
