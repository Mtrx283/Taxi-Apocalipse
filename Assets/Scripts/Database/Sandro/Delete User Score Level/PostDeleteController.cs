
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PostDeleteController : MonoBehaviour
{
    private const string url = "http://localhost/php/taxi_apocalipsis/piero/post_delete.php";

    public void Post(string username, string levelname)
    {
        StartCoroutine(PostDelete(username, levelname));
    }

    private IEnumerator PostDelete(string username, string levelname)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("levelname", levelname);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
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
