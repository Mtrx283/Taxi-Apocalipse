using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Log_inView : MonoBehaviour
{
    [SerializeField] private Button registerButton;
    [SerializeField] private TMP_InputField nameText;
    [SerializeField] private TMP_InputField passwordText;

    private Log_inController controller;

    private void Awake()
    {
        controller = GetComponent<Log_inController>();
        registerButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        controller.Log_in(nameText.text, passwordText.text);
    }
}
