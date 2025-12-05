using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class GetAvgPowerUpUsedController : MonoBehaviour
{
    [SerializeField] private string url = "http://localhost/Progra2025/Projecto2025/get_avg_power_up_used.php";

    public void Get(Action<PowerModel> callback)
    {
        StartCoroutine(SendRequest(callback));
    }
    private IEnumerator SendRequest(Action<PowerModel> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                callback?.Invoke(JsonUtility.FromJson<PowerModel>(www.downloadHandler.text));
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
