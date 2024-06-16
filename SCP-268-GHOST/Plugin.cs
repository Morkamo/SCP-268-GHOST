using System;
using Exiled.API.Features;
using Exiled.CustomItems.API;

namespace SCP_268_GHOST
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Author => "Morkamo";
        public override string Name => "SCP-268-GHOST";
        public override string Prefix => "SCP-268-GHOST";
        public override Version Version => new Version(1, 0, 0);

        internal item268g item268g;
        
        public override void OnEnabled()
        {
            Instance = this;
            item268g = new item268g();
            
            Config.Item268G.Register();
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            
            Config.Item268G.Unregister();
            
            base.OnDisabled();
        }
    }
}