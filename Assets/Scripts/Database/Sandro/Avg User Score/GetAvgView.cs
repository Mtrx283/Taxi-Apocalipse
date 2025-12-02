using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetAvgView : MonoBehaviour
{
    private GetAvgController getAvgController;

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private Button MenuButton;
    void Awake()
    {
        getAvgController = GetComponent<GetAvgController>();
        getAvgController.Get(ShowData);
        MenuButton.onClick.AddListener(MenuScene);
    }

    private void ShowData(AvgDataModel[] avgDataModels)
    {


        foreach (Transform t in container.GetComponentInChildren<Transform>())
        {
            if (t != container.transform)
            {
                Destroy(t.gameObject);
            }
            
        }


        foreach (AvgDataModel data in avgDataModels)
        {
            GameObject instance = Instantiate(prefab, container);
            instance.GetComponent<UserContaner>().SetUp(data.name + "                     " + data.total_average);
        }

    }

    private void MenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
