using UnityEditor;
using UnityEngine;

public class TiledImporterPreferencesWindow : EditorWindow
{
	private System.Action _callback = delegate { };
	private TiledImporter.Preferences _preferences;
	
	public static void Init(TiledImporter.Preferences preferences, System.Action callback = null)
	{
		TiledImporterPreferencesWindow window = EditorWindow.GetWindow<TiledImporterPreferencesWindow>();
		window._preferences = preferences;
		window._callback = callback == null ? delegate { } : callback;

		window.Show();
	}

	void OnGUI()
	{
		EditorGUILayout.BeginVertical();

		EditorGUILayout.BeginHorizontal();

		_preferences.tiled2UnityPath.Value = EditorGUILayout.TextField("Path", _preferences.tiled2UnityPath.Value);
		if (GUILayout.Button("..."))
		{
			_preferences.tiled2UnityPath.Value = EditorUtility.OpenFilePanel("Tiled2Unity executable", "", "exe");
		}

		EditorGUILayout.EndHorizontal();

		_preferences.vertexScale.Value = EditorGUILayout.FloatField("Vertex scale", _preferences.vertexScale.Value);

		_preferences.exitOnComplete.Value = EditorGUILayout.Toggle("Exit on complete", _preferences.exitOnComplete.Value);
		_preferences.hideWindow.Value = EditorGUILayout.Toggle("Hide Tiled2Unity window", _preferences.hideWindow.Value);

		_preferences.timeout.Value = EditorGUILayout.IntField("Export timeout", _preferences.timeout.Value);

		if (GUILayout.Button("OK"))
		{
			_callback();
			Close();
		}

		EditorGUILayout.EndVertical();
	}
}