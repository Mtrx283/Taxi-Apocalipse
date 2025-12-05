using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeleteUserView : MonoBehaviour
{
    [SerializeField] private Button deleteButton;
    [SerializeField] private TMP_InputField nameText;

    private DeleteUserController controller;

    private void Awake()
    {
        controller = GetComponent<DeleteUserController>();
        deleteButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        controller.Delete(nameText.text);
    }

}
