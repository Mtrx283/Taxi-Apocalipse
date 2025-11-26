using System.Collections;
using System.Text;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class Ranking : MonoBehaviour
{
    struct Content
    {
        public LevelData data;
    }
    struct LevelData
    {
        public int Level;
    }

    //
    //LevelData
    //{
    //   Level: 1
    //}
    //

    private IEnumerator Start()
    {
        Content info = new Content();
        info.data.Level = 1;
        string json = JsonUtility.ToJson(info);

        using (UnityWebRequest web = UnityWebRequest.Get("google.com"))
        {
            //encabezado de informacion para la base de datos (php de la pagina)
            web.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            web.uploadHandler = new UploadHandlerRaw(bodyRaw);

            //permite el que se pueda descargar informacion del php
            web.downloadHandler = new DownloadHandlerBuffer();

            yield return web.SendWebRequest();

            if (web.result == UnityWebRequest.Result.Success)
            {
                string response = web.downloadHandler.text;
                PlayerInfo player = JsonUtility.FromJson<PlayerInfo>(response);
            }
        }
    }

    struct PlayerInfo
    {
        public PlayerData[] data;
    }
    struct PlayerData
    {
        public string name;
        public int score;
        public int time;
    }
}