using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetAvgController : MonoBehaviour
{
    private const string url = "http://localhost/php/taxi_apocalipsis/piero/get_avg.php";

    public void Get(Action<AvgDataModel[]> callback)
    {
        StartCoroutine(GetAvgScore(callback));
    }

    private IEnumerator GetAvgScore(Action<AvgDataModel[]>callback)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if(www.downloadHandler.text == "There are no results")
            {
                Debug.Log("There are no results");
            }

           else if(www.result == UnityWebRequest.Result.Success)
            {
                AvgData avgData = JsonUtility.FromJson<AvgData>(www.downloadHandler.text);
                callback?.Invoke(avgData.data);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
