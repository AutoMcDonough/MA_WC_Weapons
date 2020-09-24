using System.Collections.Generic;
using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove;
namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        /// Possible Events ///
        
        //Reloading,
        //Firing,
        //Tracking,
        //Overheated,
        //TurnOn,
        //TurnOff,
        //BurstReload,
        //OutOfAmmo,
        //PreFire,
        //EmptyOnGameLoad,
        //StopFiring,
        //StopTracking

        private AnimationDef MA_EMP_Animations => new AnimationDef
        {
			HeatingEmissiveParts = new[]
            {
                "Emissive_Bling"
            },
            
            EventParticles = new Dictionary<PartAnimationSetDef.EventTriggers, EventParticle[]>
            {
                [Firing] = new[]{
                    new EventParticle
                    {
                        EmptyNames = Names("muzzle_projectile_001"),
                        MuzzleNames = Names("muzzle_projectile_001"),
                        StartDelay = 0, //ticks 60 = 1 second
                        LoopDelay = 0, //ticks 60 = 1 second
                        ForceStop = true,
                        Particle = new ParticleDef
                        {
                            Name = "ShipWelderArc",
                            Color = Color(red: 10, green: 20, blue: 20, alpha: 1),
                            Extras = new ParticleOptionDef
                            {
                                Loop = false,
                                Restart = false,
                                MaxDistance = 500, //meters
                                MaxDuration = 5, //ticks 60 = 1 second
                                Scale = 2,
                            }
                        }
                    },
                },
            },
        };
    }
}