using UnityEngine;
using UnityEngine.UI;

public class PostDeleteView : MonoBehaviour
{
    private PostDeleteController controller;
    [SerializeField] private string username;
    [SerializeField] private string levelname;
    [SerializeField] private Button deleteButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controller = GetComponent<PostDeleteController>();
        deleteButton.onClick.AddListener(DeleteButtonOnClick);


    }

    private void DeleteButtonOnClick()
    {
        controller.Post(username, levelname);
 
    }
}
