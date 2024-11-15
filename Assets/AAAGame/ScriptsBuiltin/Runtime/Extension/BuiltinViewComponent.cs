﻿using System.Collections;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 内置的UI界面(热更之前)
/// </summary>
public class BuiltinViewComponent : GameFrameworkComponent
{
    [Header("Loading Progress:")]
    [SerializeField] GameObject loadingProgressNode = null;
    [SerializeField] private Image Icon;
    [SerializeField] private Slider loadSlider;

    [Space(20)]
    [Header("Tips Dialog:")]
    [SerializeField] GameObject tipsDialog = null;
    [SerializeField] TextMeshProUGUI tipsTitleText;
    [SerializeField] TextMeshProUGUI tipsContentText;
    [SerializeField] Button tipsPositiveBtn;
    [SerializeField] Button tipsNegativeBtn;
    //[Header("Waiting View:")]
    //[SerializeField] GameObject waitingView = null;

    //public void WaitAndShowVideoAd(float loadingOutTime, GameFrameworkAction onAdReady)
    //{
    //    adLoadingMask.SetActive(true);
    //    StopAllCoroutines();
    //    StartCoroutine(WaitAdLoading(loadingOutTime, onAdReady));
    //}
    //IEnumerator WaitAdLoading(float loadingOutTime, GameFrameworkAction onAdReady)
    //{
    //    float adLoadCd = 0;

    //    while (adLoadCd < loadingOutTime)
    //    {
    //        if (GFBuiltin.AD.IsRewardedAdReady())
    //        {
    //            onAdReady?.Invoke();
    //            break;
    //        }
    //        yield return new WaitForSeconds(0.2f);
    //        adLoadCd += 0.2f;
    //    }
    //    if (adLoadCd >= loadingOutTime)
    //    {
    //        GFBuiltin.AD.ShowToast("Loading failed! Please try again later.");
    //        //GFBuiltin.UserData.RecodEvent("missing_videoAd");
    //    }
    //    adLoadingMask.SetActive(false);
    //}
    private void Start()
    {
        ShowLoadingProgress();
        //waitingView.SetActive(false);
    }
    public void ShowLoadingProgress(float defaultProgress = 0)
    {
        loadingProgressNode.SetActive(true);
        StartIconAnim();
        SetLoadingProgress(defaultProgress);
    }
    public void SetLoadingProgress(float progress)
    {
        loadSlider.value = progress;
    }

    private void StartIconAnim()
    {
        this.Icon.transform.DOLocalRotate(new Vector3(0,0,-360), 2f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    public void HideLoadingProgress()
    {
        loadingProgressNode.SetActive(false);
    }

    public void ShowDialog(string title, string content, string yes_btn_title = "YES", string no_btn_title = "NO", UnityEngine.Events.UnityAction yes_cb = null, UnityEngine.Events.UnityAction no_cb = null)
    {
        tipsDialog.SetActive(true);
        if (yes_cb == null && no_cb == null)
        {
            yes_cb = HideDialog;
        }
        tipsNegativeBtn.gameObject.SetActive(no_cb != null);
        tipsNegativeBtn.GetComponentInChildren<TextMeshProUGUI>().text = no_btn_title;

        tipsPositiveBtn.gameObject.SetActive(yes_cb != null);
        tipsPositiveBtn.GetComponentInChildren<TextMeshProUGUI>().text = yes_btn_title;
        var dialog_bg = tipsDialog.transform.Find("DialogBG");
        tipsTitleText.text = title.ToUpper();
        tipsContentText.text = content;
        tipsNegativeBtn.onClick.RemoveAllListeners();
        tipsPositiveBtn.onClick.RemoveAllListeners();
        if (no_cb != null) tipsNegativeBtn.onClick.AddListener(() => { no_cb.Invoke(); HideDialog(); });
        if (yes_cb != null) tipsPositiveBtn.onClick.AddListener(() => { yes_cb.Invoke(); HideDialog(); });
    }

    public void HideDialog()
    {
        tipsDialog.SetActive(false);
    }
}
