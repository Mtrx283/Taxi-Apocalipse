using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RegisterView : MonoBehaviour
{
    [SerializeField] private Button registerButton;
    [SerializeField] private TMP_InputField nameText;
    [SerializeField] private TMP_InputField passwordText;

    private RegisterController controller;

    private void Awake()
    {
        controller = GetComponent<RegisterController>();
        registerButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        controller.Register(nameText.text, passwordText.text);
    }

}
