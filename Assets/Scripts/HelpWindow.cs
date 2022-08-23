using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HelpWindow : MonoBehaviour
{
    [SerializeField]
    AnimationCurve curve;
    [Header("Fade Duration")]
    [SerializeField]
    float fadeIn = 0.15f;
    [SerializeField]
    float fadeOut = 0.1f;
    [SerializeField]
    CanvasGroup canvasGroup;

    bool isOpen;

    void OnValidate()
    {
        TryGetComponent(out canvasGroup);
    }

    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            canvasGroup.DOFade(1f, fadeIn).SetEase(curve);
            canvasGroup.blocksRaycasts = isOpen;
            canvasGroup.interactable = isOpen;
            //StartCoroutine(Fade(true));
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            //StartCoroutine(Fade(false));
            isOpen = false;
            canvasGroup.DOFade(0f, fadeOut).SetEase(curve);
            canvasGroup.blocksRaycasts = isOpen;
            canvasGroup.interactable = isOpen;
        }
    }

    //public IEnumerator Fade(bool isOpen)
    //{
    //    float time = 0f;
    //    float start = canvasGroup.alpha;
    //    float duration = isOpen ? fadeIn : fadeOut;
    //    float target = isOpen ? 1 : 0;

    //    this.isOpen = isOpen;
    //    canvasGroup.blocksRaycasts = isOpen;
    //    canvasGroup.interactable = isOpen;

    //    while (time < 1)
    //    {
    //        time += Time.deltaTime / duration;
    //        canvasGroup.alpha = Mathf.Lerp(start, target, curve.Evaluate(time));
    //        yield return null;
    //    }
    //}
    public void ForceFade(bool isOpen)
    {
        float target = isOpen ? 1 : 0;
        canvasGroup.alpha = target;
    }
}
