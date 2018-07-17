using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
	protected static T _instance = null;

	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.Log("todo");
			}

			return _instance;
		}
	}

	public static void CreateInstance(bool dontDestroyOnLoad, Transform fatherTrans = null)
	{
		if (_instance != null)
		{
			Debug.Log("todo");
			return;
		}

		GameObject go = new GameObject();
		if (fatherTrans)
		{
			go.transform.SetParent(fatherTrans, false);
			go.transform.localPosition = new Vector3(0, 0, 0);
		}

		_instance = go.AddComponent<T>();
		go.name = _instance.GetType().Name;
		if (dontDestroyOnLoad)
		{
			GameObject.DontDestroyOnLoad(go);
		}
	}

	public static void DestroyInstance()
	{
		if (_instance != null)
		{
			GameObject.Destroy(_instance.gameObject);
			_instance = null;
		}
	}
}