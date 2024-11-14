using DG.Tweening;
using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public partial class MainUIForm : UIFormBase
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
    }

    protected override void OnButtonClick(object sender, Button btSelf)
    {
        base.OnButtonClick(sender, btSelf);
        if (btSelf == SettingBtn)
        {
            GF.UI.OpenUIForm(UIViews.SettingPanel);
        }
    }
}
