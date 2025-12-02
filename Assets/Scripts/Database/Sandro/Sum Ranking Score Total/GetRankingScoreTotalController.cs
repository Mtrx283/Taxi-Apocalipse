using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetRankingScoreTotalController : MonoBehaviour
{
    private const string url = "http://localhost/php/taxi_apocalipsis/piero/get_ranking_score_total.php";

    public void Get(Action<SumRankingDataModel[]> callback)
    {
        StartCoroutine(GetRankingScoreTotal(callback));
    }

    private IEnumerator GetRankingScoreTotal(Action<SumRankingDataModel[]> callback)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if(www.downloadHandler.text == "The ranking is empty")
            {
                Debug.Log("The ranking is empty");
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
