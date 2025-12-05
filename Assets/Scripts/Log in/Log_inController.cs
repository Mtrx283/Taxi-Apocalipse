using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Log_inController : MonoBehaviour
{
    [SerializeField] private string url = "http://localhost/Progra2025/Projecto2025/get_user.php";

    public void Log_in(string name, string password)
    {
        StartCoroutine(SendRequest(name, password));
    }

    private IEnumerator SendRequest(string name, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }

    private IEnumerator SendRequest2(string name, string password)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
