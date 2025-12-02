using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostLikeUserView : MonoBehaviour
{
    private PostLikeUserController controller;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private Button likeButton;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button menuButton;

    private void Awake()
    {
        controller = GetComponent<PostLikeUserController>();
        likeButton.onClick.AddListener(LikeButton);
        menuButton.onClick.AddListener(MenuScene);
    }

    private void LikeButton()
    {
        controller.Post(usernameInputField.text, ShowData);

    }
    private void ShowData(PostLikeUserDataModel[] postLikes)
    {
        foreach (Transform t in container.GetComponentInChildren<Transform>())
        {
            if (t != container.transform)
            {
                Destroy(t.gameObject);
            }

        }

        foreach (PostLikeUserDataModel postLikeUser in postLikes)
        {
            GameObject instance = Instantiate(prefab, container);
            instance.GetComponent<UserContaner>().SetUp(postLikeUser.name);
        }
    }

    private void MenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
