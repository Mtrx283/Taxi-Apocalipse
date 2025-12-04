using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetRankingScoreTotalView : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform container;
    [SerializeField] private Button menuButton;

    private GetRankingScoreTotalController controller;
    
    void Awake()
    {
        controller = GetComponent<GetRankingScoreTotalController>();
        controller.Get(ShowData);
        menuButton.onClick.AddListener(MenuScene);
    }

    private void ShowData( List <SumRankingDataModel> sumRankingDataModels)
    {
        foreach (Transform t in container.GetComponentInChildren<Transform>())
        {
            if (t != container.transform)
            {
                Destroy(t.gameObject);
            }
        }
        foreach (SumRankingDataModel data in sumRankingDataModels)
        {
            GameObject instance = Instantiate(prefab, container);
            instance.GetComponent<UserContaner>().SetUp(data.name + "                     " + data.total_score);
        }
    }

    private void MenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
