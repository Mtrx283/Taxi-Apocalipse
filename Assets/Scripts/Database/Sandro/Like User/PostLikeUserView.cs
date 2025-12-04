using System.Collections.Generic;
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
        string trimmedInput = usernameInputField.text.Trim(); //Recortar espacios en blanco

        if (string.IsNullOrEmpty(trimmedInput)) // Verificar si el campo esta vacio
        {
            Debug.Log("Miskete");
        }

        else
        {
            controller.Post(usernameInputField.text, ShowData);
        }


    }
    private void ShowData( List <PostLikeUserDataModel> postLikes)
    {

        foreach (Transform t in container.GetComponentInChildren<Transform>()) //Eliminar los hijos anteriores
        {
           if (t != container.transform) // Evitar eliminar el contenedor
            {
                Destroy(t.gameObject);
           }

        }

        foreach (PostLikeUserDataModel postLikeUser in postLikes) // Crear nuevos elementos para cada usuario
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
