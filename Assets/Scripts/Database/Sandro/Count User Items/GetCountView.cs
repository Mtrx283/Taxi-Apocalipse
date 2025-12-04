using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetCountView : MonoBehaviour
{
    private GetCountController getCountController;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private Button menuButton;

    
    
    void Awake()
    {
        getCountController = GetComponent<GetCountController>();
        getCountController.Get(ShowData);
        menuButton.onClick.AddListener(MenuScene);
    }

    private void ShowData(List<CountDataModel> countDataModels)
    {
        foreach (Transform t in container.GetComponentInChildren<Transform>())
        {
            if (t != container.transform)
            {
                Destroy(t.gameObject);
            }

        }

        foreach (CountDataModel countDataModel in countDataModels)
        {
            GameObject instance = Instantiate(prefab, container);
            instance.GetComponent<UserContaner>().SetUp ( countDataModel.name + "        " + countDataModel.total_quantity);
        }
    }

    private void MenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
