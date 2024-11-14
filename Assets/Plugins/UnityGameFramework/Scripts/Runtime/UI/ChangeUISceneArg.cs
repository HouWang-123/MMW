using System;
using GameFramework;
using GameFramework.Event;

public sealed class ChangeUISceneArg : GameEventArgs
{
    public static readonly int EventId = typeof(ChangeUISceneArg).GetHashCode();

    public string SpriteName;
    
    public override int Id
    {
        get
        {
            return EventId;
        }
    }

    public ChangeUISceneArg Create(GameFramework.UI.ChangeUISceneArg e)
    {
        ChangeUISceneArg changeUISceneArg = ReferencePool.Acquire<ChangeUISceneArg>();
        changeUISceneArg.SpriteName = e.SpriteName;
        return changeUISceneArg;
    }
    
    public override void Clear()
    {
        SpriteName = string.Empty;
    }
}