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
		//	HeatingEmissiveParts = new[]
        //    {
        //        "Emissive_Bling"
        //    },
			Emissives = new[]
            {
             Emissive(
                    EmissiveName: "EMPHeatUp",
                    Colors: new []
                    {
                        Color(0, 0, 0, 1),
                        Color(10, .01f, 0, 10),
                        Color(40, .02f, 0, 60),
                        Color(60, .04f, 0, 80),
                        Color(80, .1f, .08f, 120),
                    },
                    IntensityFrom:1, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:15,
                    CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: false,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive_Bling"
                    }
                ),
                Emissive(
                    EmissiveName: "EMPCoolDown",
                    Colors: new []
                    {
                         Color(80, .1f, .08f, 120),      
                        Color(60, .04f, 0, 80),
                        Color(40, .02f, 0, 60),
                        Color(10, .01f, 0, 10),
                        Color(0, 0, 0, 1),
						
						
						
						
                    },
                    IntensityFrom:1, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:15,
                    CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: false,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive_Bling"
                    }
                ),
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
			
			WeaponAnimationSets = new[]
            {
			new PartAnimationSetDef()
                {
                    SubpartId = Names("GatlingBarrel"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 30),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
                    TriggerOnce = Events(Firing,StopFiring),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        [Firing] =
                            new[] //Firing, Reloading, Overheated, Tracking, TurnOn, TurnOff, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 190, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = ExpoGrowth, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "EMPHeatUp",//name of defined emissive 
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
                        [StopFiring] =
                            new[] //Firing, Reloading, Overheated, Tracking, TurnOn, TurnOff, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 70, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = ExpoDecay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "EMPCoolDown",
                                    LinearPoints = new XYZ[0],
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },

                            },
                    }
                },
			}
        };
    }
}