using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ComicController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Pages")]
    public List<ScriptablePageData> allPages;
    private int currentPageIndex = 0;

    [Header("Setup")]
    public GameObject panelPrefab;
    public Transform panelParent;
    public AudioSource audioSource;

    private Coroutine currentRoutine;

    public void Start()
    {
        currentPageIndex = 0;
        ShowPage(currentPageIndex);
    }

    [ContextMenu("ShowNextPage")]
    public void ShowNextPage()
    {
        currentPageIndex++;
        if (currentPageIndex >= allPages.Count)
        {
            SceneManager.LoadScene("Menu");
            return;
        }

        ClearPanels();
        ShowPage(currentPageIndex);
    }

    void ShowPage(int index)
    {
        if (index < 0 || index >= allPages.Count) return;

        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(ShowPanels(allPages[index]));
    }

    IEnumerator ShowPanels(ScriptablePageData pageData)
    {
        foreach (PanelData panelData in pageData.panels)
        {
            yield return new WaitForSeconds(panelData.delay);

            GameObject go = CreatePanel(panelData);
            AnimatePanel(go, panelData);

            if (panelData.sound != null && audioSource != null)
                audioSource.PlayOneShot(panelData.sound);
        }
    }
    void AnimatePanel(GameObject go, PanelData data)
    {
        RectTransform rt = go.GetComponent<RectTransform>();
        CanvasGroup cg = go.GetComponent<CanvasGroup>();

        switch (data.animationType)
        {
            case AnimationType.PopLeve:
                rt.localScale = Vector2.zero;
                rt.DOScale(data.scale, 0.4f).SetEase(Ease.OutBack);
                break;

            case AnimationType.PopFuerte:
                rt.localScale = Vector2.zero;
                rt.DOScale(data.scale, 0.6f).SetEase(Ease.OutBounce);
                break;

            case AnimationType.SlideInLeft:
                rt.anchoredPosition = data.anchoredPosition + Vector2.left * 800;
                rt.DOAnchorPos(data.anchoredPosition, 0.5f).SetEase(Ease.OutExpo);
                break;

            case AnimationType.SlideInRight:
                rt.anchoredPosition = data.anchoredPosition + Vector2.right * 800;
                rt.DOAnchorPos(data.anchoredPosition, 0.5f).SetEase(Ease.OutExpo);
                break;

            case AnimationType.FadeIn:
                cg.DOFade(1, 0.5f);
                break;

            case AnimationType.Shake:
                rt.DOShakeAnchorPos(0.5f, 20, 10, 90, false, true);
                break;
        }
    }
    void ClearPanels()
    {
        foreach (Transform child in panelParent)
        {
            Destroy(child.gameObject);
        }
    }
    GameObject CreatePanel(PanelData data)
    {
        GameObject go = Instantiate(panelPrefab, panelParent);

        Image img = go.TryGetComponent(out Image image) ? image : go.AddComponent<Image>();
        CanvasGroup cg = go.TryGetComponent(out CanvasGroup group) ? group : go.AddComponent<CanvasGroup>();
        RectTransform rt = go.GetComponent<RectTransform>();

        SetupRectTransform(rt, data);
        img.sprite = data.image;
        cg.alpha = (data.animationType == AnimationType.FadeIn) ? 0 : 1;

        return go;
    }
    void SetupRectTransform(RectTransform rt, PanelData data)
    {
        rt.anchorMin = rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.localScale = data.scale;
        rt.sizeDelta = Vector2.one;
        rt.anchoredPosition = data.anchoredPosition;
    }
}
