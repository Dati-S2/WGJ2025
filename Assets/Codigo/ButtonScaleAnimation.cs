using DG.Tweening;
using DG.Tweening.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

[RequireComponent(typeof(Button))]
public class ButtonScaleAnimation : MonoBehaviour
{
    [Header("Imagen que se va Escalar")]
    [SerializeField] RectTransform rectTransform;

    [Header("Que Tamaño Tendra")]
    [SerializeField] float width = 1.1f;
    [SerializeField] float height = 1.1f;

    [Header("Tipo de Animacion")]
    [SerializeField] Ease Type = Ease.OutBack;

    [Header("Tiempo Total de la Animacion")]
    [SerializeField] float TimeBetweenScale = 0.15f;

    [Header("Que va realizar luego de Terminar la Animacion")]
    [SerializeField] UnityEvent onCompleteAction;

    Button button;
    Vector3 upScale;
    Sequence sequence;
    bool isAnimating = false;

    private void Awake()
    {
        if (onCompleteAction == null) Debug.LogWarning("No onCompleteAction assigned.");
        upScale = new Vector3(width, height, 1);
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonLoad);
    }
    void ButtonLoad()
    {
        if (isAnimating) return;
        isAnimating = true;

        sequence?.Kill();
        sequence = DOTween.Sequence();
        sequence.SetUpdate(true);

        sequence.Append(rectTransform.DOScale(upScale, TimeBetweenScale/2).SetEase(Type));
        sequence.Append(rectTransform.DOScale(Vector3.one, TimeBetweenScale/2).SetEase(Type));

        sequence.OnComplete(() =>
        {
            isAnimating = false;
            onCompleteAction.Invoke();
        });
    }
}
