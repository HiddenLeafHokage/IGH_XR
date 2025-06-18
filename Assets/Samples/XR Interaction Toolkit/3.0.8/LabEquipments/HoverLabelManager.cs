using UnityEngine;
using TMPro;

public class HoverLabelManager : MonoBehaviour
{
    public GameObject labelPrefab;
    private GameObject currentLabel;

    void Start()
    {
        currentLabel = Instantiate(labelPrefab);
        currentLabel.SetActive(false);
    }

    public void ShowLabel(Transform target, string text)
    {
        currentLabel.transform.position = target.position + Vector3.up * 0.1f;
        currentLabel.GetComponentInChildren<TextMeshProUGUI>().text = text;
        currentLabel.SetActive(true);
    }

    public void HideLabel()
    {
        currentLabel.SetActive(false);
    }
}