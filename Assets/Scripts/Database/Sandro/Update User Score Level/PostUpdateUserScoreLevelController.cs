using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PostUpdateUserScoreLevelController : MonoBehaviour
{
    private const string url = "http://localhost/php/taxi_apocalipsis/piero/post_update_select.php";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Post(string username, string levelname, int score, float time)
    {
        StartCoroutine(PostUpdateUserScoreLevel(username, levelname, score,time));
    }

    private IEnumerator PostUpdateUserScoreLevel(string username, string levelname, int score, float time)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("levelname", levelname);
        form.AddField("score", score);
        form.AddField("time", time.ToString());

        using(UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
