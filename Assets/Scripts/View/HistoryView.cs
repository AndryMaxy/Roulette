using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class HistoryView : MonoBehaviour
{
    public TextMeshProUGUI textPrefab;
    private HistoryRepository repository;
    private List<Number> shownNumbers;

    public void Start()
    {
        repository = HistoryRepository.GetInstance();
    }

    private Vector3 CreateVector3(int iteration)
    {
        RectTransform prefabRectTransform = textPrefab.GetComponent<RectTransform>();
        float prefabWidth = prefabRectTransform.rect.width;
        float prefabHeight = prefabRectTransform.rect.height;
        float halfPrefabWidth = prefabWidth / 2;
        float halfPrefabHeight = prefabHeight / 2;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        float halfWidth = width / 2;
        float halfHeight = height / 2;

        float widthCapacity = width / prefabWidth;

        float xMultiplyer = (iteration % widthCapacity + 1);
        float yMultiplyer = (Mathf.Floor(iteration / widthCapacity) + 1);

        float x = prefabWidth * xMultiplyer - halfPrefabWidth - halfWidth;
        float y = halfHeight - prefabHeight * yMultiplyer + halfPrefabHeight;

        Vector3 vector = new Vector3(x, y, 0);
        return vector;
    }


    public void Show()
    {
        Clear();
        shownNumbers = repository.GetLastHistoryNumbers(64);
        for (int i = 0; i < shownNumbers.Count; i++)
        {
            Number number = shownNumbers[i];
            TextMeshProUGUI text = Instantiate(textPrefab, gameObject.transform);
            text.transform.localPosition = CreateVector3(i);
            text.text = number.Value.ToString();
            text.faceColor = Utils.GetColor(number.Color.Value);
        };
    }

    private void Clear()
    {
        int childCount = gameObject.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
