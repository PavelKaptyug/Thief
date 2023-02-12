using System;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;

public class LocalRun :EditorWindow
{
    [MenuItem("Yandex/LocalStart")]
    public static void StartLocal()
    {
        string path = EditorUtility.OpenFolderPanel("Load png Textures", "", "");
		
    }
	[MenuItem("Yandex/HttpServer")]
	public static void Create()
	{
		var window = (LocalRun)EditorWindow.GetWindow(typeof(LocalRun));
		window.GameUrl = EditorPrefs.GetString(nameof(LocalRun) + "/GameUrl");
	}
	private int _Port = 8080;
	
	private HttpListener _httpListener;
	public string GameUrl;
	public string Path;
	private void Start()
	{
		
		_httpListener = new HttpListener();
		_httpListener.Prefixes.Add($"https://*:{_Port}/");
		_httpListener.Start();
		_httpListener.BeginGetContext(new AsyncCallback(OnGetCallback), null);
		 Application.OpenURL(GameUrl + "&game_url=https://localhost:"+_Port);

	}
	private async void OnGetCallback(IAsyncResult result)
	{
		
	}
    private void OnDestroy()
    {
		_httpListener.Stop();
    }
    private void OnGUI()
    {
		
		GUILayout.Label("Локальный тест яндекс игры");
		GUILayout.BeginHorizontal();
		GUILayout.Label("Url черновика");
		GameUrl = GUILayout.TextField(GameUrl);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Url черновика");
		Path = GUILayout.TextField(Path);
		if (GUILayout.Button("Browse"))
		{
			Path = EditorUtility.OpenFolderPanel("Load png Textures", "", "");
		}
		GUILayout.EndHorizontal();
		if (_httpListener == null)
        {
			GUILayout.Label("Суервер выключен");
			if(GUILayout.Button("Start"))
            {
				Start();
            }
			return;
		}
		if(_httpListener.IsListening)
        {
			GUILayout.Label("Сервер запущен");
			if (GUILayout.Button("Start"))
			{
				_httpListener.Stop();
			}
		}
		
		
	}
}
