using DG.Tweening;
using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using GameFramework.Fsm;
public partial class GameUIForm : UIFormBase
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
    }
    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        //Todo 这地方后面有可能要加音乐 先空着
    }

    protected override void OnButtonClick(object sender, Button btSelf)
    {
        base.OnButtonClick(sender, btSelf);
        if (btSelf == loginBtn)
        { 
            GF.UI.OpenUIForm(UIViews.UIScene);
            GF.UI.OpenUIForm(UIViews.MainPanel);
        }
    }
}