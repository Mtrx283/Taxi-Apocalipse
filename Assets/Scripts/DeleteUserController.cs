using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DeleteUserController : MonoBehaviour
{
    [SerializeField] private string url = "http://localhost/Progra2025/Projecto2025/delete_user.php";

    public void Delete(string name)
    {
        StartCoroutine(SendRequest(name));
    }

    private IEnumerator SendRequest(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);

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
}
