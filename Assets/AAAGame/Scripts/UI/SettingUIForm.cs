using System;
using System.Collections.Generic;
using UnityEngine.UI;
public partial class SettingUIForm : UIFormBase
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        //Todo 设置音量
        varSlider_Music.onValueChanged.AddListener((value) =>
        {
            
        });
        varSlider_Design.onValueChanged.AddListener((value) =>
        {
            
        });
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        varSlider_Music.SetValueWithoutNotify(GF.Setting.GetFloat("Music"));
        varSlider_Design.SetValueWithoutNotify(GF.Setting.GetFloat("Design"));
    }

    protected override void OnClose(bool isShutdown, object userData)
    {
        base.OnClose(isShutdown, userData);
        GF.Setting.SetFloat("Music",varSlider_Music.value);
        GF.Setting.SetFloat("Design",varSlider_Design.value);
    }
}