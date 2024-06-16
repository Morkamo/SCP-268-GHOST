using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;

using evArgs = Exiled.Events.Handlers.Player;

namespace SCP_268_GHOST
{
    [CustomItem(ItemType.SCP268)]
    public class item268g : CustomItem
    {
        public uint UserNetid;
        
        public override uint Id { get; set; } = 1;
        public override float Weight { get; set; } = 1f;
        public override string Name { get; set; } = "SCP-268-GHOST";
        public override string Description { get; set; } = "SCP-268-GHOST";
        public override SpawnProperties SpawnProperties { get; set; } = new();
        public override ItemType Type { get; set; } = ItemType.SCP268;
        public override Vector3 Scale { get; set; } = new (1f, 1f, 1f);
        
        protected override void SubscribeEvents()
        {
            evArgs.TriggeringTesla += OnTriggeringTesla;
            evArgs.UsingItemCompleted += OnUsedItem;
            evArgs.ChangingItem += OnChangeItem;
            evArgs.InteractingDoor += OnIteractDoor;
            evArgs.InteractingElevator += OnIteractElevator;
            evArgs.InteractingLocker += OnInteractLocker;
            
            base.SubscribeEvents();
        }
        
        protected override void UnsubscribeEvents()
        {
            evArgs.TriggeringTesla -= OnTriggeringTesla;
            evArgs.UsingItemCompleted -= OnUsedItem;
            evArgs.ChangingItem -= OnChangeItem;
            evArgs.InteractingDoor -= OnIteractDoor;
            evArgs.InteractingElevator -= OnIteractElevator;
            evArgs.InteractingLocker -= OnInteractLocker;
            
            base.UnsubscribeEvents();
        }
        
        internal void OnUsedItem(UsingItemCompletedEventArgs ev)
        {
            if (Check(ev.Usable) && ev.Usable.Type == ItemType.SCP268)
            {
                if (!ev.Player.IsEffectActive<MovementBoost>())
                    ev.Player.GetEffect(EffectType.MovementBoost).Intensity += 15;
                
                ev.Player.EnableEffect(EffectType.Ghostly);
                UserNetid = ev.Player.NetId;

                Timing.CallDelayed(15f, () =>
                {
                    if (ev.Player.NetId == UserNetid)
                    {
                        RemoveItemEffects(ev.Player);
                        UserNetid = 0;
                    }
                });
            }
        }
        
        internal void OnChangeItem(ChangingItemEventArgs ev)
        {
            if (ev.Player.NetId == UserNetid)
            {
                RemoveItemEffects(ev.Player);
                UserNetid = 0;
            }
        }
        
        internal void OnIteractDoor(InteractingDoorEventArgs ev)
        {
            if (ev.Player.NetId == UserNetid)
            {
                RemoveItemEffects(ev.Player);
                UserNetid = 0;
            }
        }
        
        internal void OnIteractElevator(InteractingElevatorEventArgs ev)
        {
            if (ev.Player.NetId == UserNetid)
            {
                RemoveItemEffects(ev.Player);
                UserNetid = 0;
            }
        }
        
        internal void OnInteractLocker(InteractingLockerEventArgs ev)
        {
            if (ev.Player.NetId == UserNetid)
            {
                RemoveItemEffects(ev.Player);
                UserNetid = 0;
            }
        }

        internal void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (ev.Player.NetId == UserNetid && ev.Player.IsEffectActive<Invisible>())
                ev.IsAllowed = false;
        }
        
        private void RemoveItemEffects(Player player)
        {
            player.DisableEffect(EffectType.Ghostly);
            player.GetEffect(EffectType.MovementBoost).Intensity -= 15;
        }
    }
}