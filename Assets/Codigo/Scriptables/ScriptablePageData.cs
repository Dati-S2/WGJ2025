using DG.Tweening;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class PanelData
{
    public Sprite image;
    public Vector2 anchoredPosition;
    public Vector2 scale = Vector2.one;
    public AnimationType animationType;
    public float delay;
    public AudioClip sound;
}

[CreateAssetMenu(fileName = "NewComicPage", menuName = "Scriptable Objects/PageData")]
public class ScriptablePageData : ScriptableObject
{
    public List<PanelData> panels = new();
}
