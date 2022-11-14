using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Popup : MonoBehaviour
{
    [SerializeField] private Button showButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private RectTransform[] rectsToUpdate;

    void Awake()
    {
        gameObject.SetActive(false);

        showButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(true);

            for (int i = 0; i < rectsToUpdate.Length; i++)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(rectsToUpdate[i]);
            }

            DOTween.Sequence().Append(gameObject.transform.DOScale(new Vector3(0.4f, 0.4f, 0.4f), 0))
            .Append(gameObject.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), .35f))
            .Append(transform.DOScale(new Vector3(1, 1, 1), .15f));
        });

        closeButton.onClick.AddListener(() =>
        {
            DOTween.Sequence().Append(gameObject.transform.DOScale(new Vector3(1, 1, 1), 0))
            .Append(gameObject.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), .15f))
            .Append(transform.DOScale(new Vector3(0.4f, 0.4f, 0.4f), .35f))
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        });
    }
}
