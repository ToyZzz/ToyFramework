using System.IO;
using UnityEditor;

public class DataTableImporter : AssetPostprocessor
{
	public static readonly string DataTableRootFolder = "Assets/DataTable/";

	static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedFromAssetPaths)
	{
		foreach (var importAsset in imported)
		{
		    if (!importAsset.StartsWith(DataTableRootFolder))
		    {
                continue;
		    }
		    CreateDatatable(importAsset);
		}
	    foreach (var deletedAsset in deleted)
	    {
	        if (!deletedAsset.StartsWith(DataTableRootFolder))
	        {
	            continue;
	        }
	        DeleteDatatable(deletedAsset);
        }
        foreach (var moveAsset in moved)
        {
            if (!moveAsset.StartsWith(DataTableRootFolder))
            {
                continue;
            }
            CreateDatatable(moveAsset);
        }
		foreach (var moveFromAsset in movedFromAssetPaths)
		{
		    if (!moveFromAsset.StartsWith(DataTableRootFolder))
		    {
		        continue;
		    }
		    DeleteDatatable(moveFromAsset);
		}
	}

	[MenuItem("Test/test1")]
	static void Debug()
	{
		Log.D(DebugType.IMPORTER,DataTableImporter.DataTableRootFolder);
		
	}

    private static void CreateDatatable(string excelFilePath)
    {
        Log.D("a");
    }

    private static void DeleteDatatable(string excelFilePath)
    {
        Log.D("b");
    }
}
