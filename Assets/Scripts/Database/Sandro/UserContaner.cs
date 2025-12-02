using TMPro;
using UnityEngine;

public class UserContaner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI avgText;

    public void SetUp(string text)
    {
        avgText.text = text;
    }
}
