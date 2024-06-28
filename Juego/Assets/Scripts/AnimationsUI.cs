using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsUI : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject InitialGroup;

    private void Start()
    {
        LeanTween.moveX(logo.GetComponent<RectTransform>(),700 ,2f).setDelay(2f).setEase(LeanTweenType.easeInOutElastic)
        .setEase(LeanTweenType.easeOutBounce).setOnComplete(DownAlpha);
    }

    private void DownAlpha()
    {
        LeanTween.alpha(InitialGroup.GetComponent<RectTransform>(), 0f, 1f).setDelay(0.5f);
        InitialGroup.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

}
