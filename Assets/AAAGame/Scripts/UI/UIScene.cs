using System;
using GameFramework;
using GameFramework.Event;
using UnityGameFramework.Runtime;
public partial class UIScene : UIFormBase
{
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        GF.Event.Subscribe(ChangeUISceneArg.EventId,OnChangeUIScene);
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
    }
    private void OnChangeUIScene(object sender, GameEventArgs e)
    {
        var args = e as ChangeUISceneArg;
        varUIScene.SetSprite(args?.SpriteName);
    }
}