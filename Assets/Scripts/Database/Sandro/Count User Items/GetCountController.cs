using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetCountController : MonoBehaviour
{
    private const string url = "http://localhost/php/taxi_apocalipsis/piero/get_count_item_user.php";

    public void Get(Action< List <CountDataModel>> callback)
    {
        StartCoroutine(GetCountTotalQuantity(callback));
    }

    private IEnumerator GetCountTotalQuantity(Action<List<CountDataModel>> callback)
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
                CountData countData = JsonUtility.FromJson<CountData>(www.downloadHandler.text);
                callback?.Invoke(countData.data);
                print(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
