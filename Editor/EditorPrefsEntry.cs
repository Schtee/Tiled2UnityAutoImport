using UnityEditor;

public abstract class EditorPrefsEntry<T>
{
	protected string _key;
	private T _value;

	public T Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			Save();
		}
	}

	protected EditorPrefsEntry(string key, T defaultValue)
	{
		_key = key;
		_value = Load(defaultValue);
	}

	protected abstract T Load(T defaultValue);

	public abstract void Save();
}

public class EditorPrefsString : EditorPrefsEntry<string>
{
	public EditorPrefsString(string key, string defaultValue) :
		base(key, defaultValue)
	{
	}

	protected override string Load(string defaultValue)
	{
		return EditorPrefs.GetString(_key, defaultValue);
	}

	public override void Save()
	{
		EditorPrefs.SetString(_key, Value);
	}
}

public class EditorPrefsBool : EditorPrefsEntry<bool>
{
	public EditorPrefsBool(string key, bool defaultValue) :
		base(key, defaultValue)
	{
	}

	protected override bool Load(bool defaultValue)
	{
		return EditorPrefs.GetBool(_key, defaultValue);
	}

	public override void Save()
	{
		EditorPrefs.SetBool(_key, Value);
	}
}

public class EditorPrefsFloat : EditorPrefsEntry<float>
{
	public EditorPrefsFloat(string key, float defaultValue) :
		base(key, defaultValue)
	{
	}

	protected override float Load(float defaultValue)
	{
		return EditorPrefs.GetFloat(_key, defaultValue);
	}

	public override void Save()
	{
		EditorPrefs.SetFloat(_key, Value);
	}
}

public class EditorPrefsInt : EditorPrefsEntry<int>
{
	public EditorPrefsInt(string key, int defaultValue) :
		base(key, defaultValue)
	{
	}

	protected override int Load(int defaultValue)
	{
		return EditorPrefs.GetInt(_key, defaultValue);
	}

	public override void Save()
	{
		EditorPrefs.SetInt(_key, Value);
	}
}