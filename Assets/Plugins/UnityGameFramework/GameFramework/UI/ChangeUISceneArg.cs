using System;
using GameFramework;
using GameFramework.Event;

namespace GameFramework.UI
{
    public sealed class ChangeUISceneArg : GameEventArgs
    {
        public static readonly int EventId = typeof(ChangeUISceneArg).GetHashCode();

        public string SpriteName;

        public override int Id
        {
            get { return EventId; }
        }

        public ChangeUISceneArg()
        {
            SpriteName = string.Empty;
        }

        public ChangeUISceneArg Create(string spriteName)
        {
            ChangeUISceneArg changeUISceneArg = ReferencePool.Acquire<ChangeUISceneArg>();
            changeUISceneArg.SpriteName = spriteName;
            return changeUISceneArg;
        }

        public override void Clear()
        {
            SpriteName = string.Empty;
        }
    }
}