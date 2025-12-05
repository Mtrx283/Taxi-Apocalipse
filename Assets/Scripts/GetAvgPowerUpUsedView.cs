using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetAvgPowerUpUsedView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PowerText;

    private GetAvgPowerUpUsedController controller;

    private void Awake()
    {
        controller = GetComponent<GetAvgPowerUpUsedController>();

    }

    private void Start()
    {
        controller.Get(OnResult);
    }

    private void OnResult(PowerModel model)
    {
        PowerText.text = $"{model.average_power_up_usage}";
    }
}
