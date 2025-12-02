using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PostLikeUserController : MonoBehaviour
{
    private const string url = "http://localhost/php/taxi_apocalipsis/piero/post_like_user.php";

    public void Post(string username, Action<PostLikeUserDataModel[]> callback)
    {
        StartCoroutine(PostLikeUser(username, callback));
    }

    private IEnumerator PostLikeUser(string username, Action<PostLikeUserDataModel[]> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        using(UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.downloadHandler.text == "There are no results")
            {
                Debug.Log("There are no results");
            }

            else if (www.result == UnityWebRequest.Result.Success)
            {
                PostLikeUserData postLikeUserData = JsonUtility.FromJson<PostLikeUserData>(www.downloadHandler.text);
                callback?.Invoke(postLikeUserData.data);
            }

            else
            {
                Debug.Log(www.error);
            }
        }
    }
}
