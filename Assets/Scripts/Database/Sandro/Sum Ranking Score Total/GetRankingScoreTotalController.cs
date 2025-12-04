using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetRankingScoreTotalController : MonoBehaviour
{
    private const string url = "http://localhost/php/taxi_apocalipsis/piero/get_ranking_score_total.php";

    public void Get(Action<List<SumRankingDataModel>> callback)
    {
        StartCoroutine(GetRankingScoreTotal(callback));
    }

    private IEnumerator GetRankingScoreTotal(Action< List<SumRankingDataModel>> callback)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.downloadHandler.text == "There are no results")
            {
                Debug.Log("There are no results");
            }
            else if(www.result == UnityWebRequest.Result.Success)
            {
                SumRankingData sumRankingData = JsonUtility.FromJson<SumRankingData>(www.downloadHandler.text);
                callback?.Invoke(sumRankingData.data);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
