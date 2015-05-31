using UnityEngine;
using UnityEditor;

public class TiledImporter : AssetPostprocessor
{
	public class Preferences
	{
		public EditorPrefsString tiled2UnityPath;
		public EditorPrefsFloat vertexScale;
		public EditorPrefsBool exitOnComplete;
		public EditorPrefsBool hideWindow;
		public EditorPrefsInt timeout;

		private const string PREFIX = "TiledImporter.";

		public Preferences()
		{
			tiled2UnityPath = new EditorPrefsString(PREFIX + "tiled2UnityPath", string.Empty);
			vertexScale = new EditorPrefsFloat(PREFIX + "vertexScale", 0.01f);
			exitOnComplete = new EditorPrefsBool(PREFIX + "exitOnComplete", true);
			hideWindow = new EditorPrefsBool(PREFIX + "hideWindow", true);
			timeout = new EditorPrefsInt(PREFIX + "timeout", 10000);
		}

		public void Save()
		{
			tiled2UnityPath.Save();
			vertexScale.Save();
			exitOnComplete.Save();
			hideWindow.Save();
		}
	}

	private const string TILED_EXTENSION = ".tmx";

	private static Preferences _preferences;
	
	public TiledImporter() : base()
	{
		_preferences = new Preferences();
	}

	[MenuItem("Tiled2Unity/Set Tiled2Unity Prefs")]
	private static void ShowPathWindow()
	{
		TiledImporterPreferencesWindow.Init(_preferences);
	}
	
	private static void OnPostprocessAllAssets(string[] importedAssets,
		string[] deletedAssets,
		string[] movedAssets,
		string[] movedFromAssetPaths)
	{
		foreach (string importedAsset in importedAssets)
		{
			string extension = System.IO.Path.GetExtension(importedAsset);

			if (extension == TILED_EXTENSION)
			{
				HandleTiledAsset(importedAsset, extension);
			}
		}
	}

	private static void HandleTiledAsset(string fullPath, string extension)
	{
		if (_preferences.tiled2UnityPath.Value == string.Empty)
		{
			TiledImporterPreferencesWindow.Init(_preferences, 
				() => RunTiled2UnityOnAsset(fullPath));
		}		
		else
		{
			RunTiled2UnityOnAsset(fullPath);
		}
	}
	
	private static void RunTiled2UnityOnAsset(string tiledAssetPath)
	{
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		process.StartInfo.FileName = _preferences.tiled2UnityPath.Value;
		process.StartInfo.Arguments = string.Format("\"{0}\" -s={1} {2} \"{3}\"", 
			tiledAssetPath, 
			_preferences.vertexScale.Value, 
			_preferences.exitOnComplete.Value ? "-a" : "",
			System.IO.Directory.GetCurrentDirectory());

		if (_preferences.hideWindow.Value)
		{
			process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		}

		process.Start();
		process.WaitForExit(_preferences.timeout.Value);
		AssetDatabase.Refresh();
	}
}
