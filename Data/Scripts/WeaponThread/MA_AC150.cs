using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace WeaponThread {   
    partial class Weapons {
        // Don't edit above this line
        WeaponDefinition MA_AC150 => new WeaponDefinition {

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "MA_AC150",
                        AimPartId = "", //not used anymore
                        MuzzlePartId = "MA_AC150_3",
                        AzimuthPartId = "MA_AC150_2a",
                        ElevationPartId = "MA_AC150_3",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_150mm.dds"
                    },
                  
                    new MountPointDef {
                        SubtypeId = "MA_AC150_30",
                        AimPartId = "", //not used anymore
                        MuzzlePartId = "MA_AC150_3",
                        AzimuthPartId = "MA_AC150_2b",
                        ElevationPartId = "MA_AC150_3",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_150mm.dds"
                    },
                
                    new MountPointDef {
                        SubtypeId = "MA_AC150_45",
                        AimPartId = "", //not used anymore
                        MuzzlePartId = "MA_AC150_3",
                        AzimuthPartId = "MA_AC150_2c",
                        ElevationPartId = "MA_AC150_3",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_150mm.dds"
                    },					
   
                    
  
                },

                Barrels = new [] {
                    "muzzle_01",
                    "muzzle_02",
                  
                },
				Scope = "Scope", //Where line of sight checks are performed from must be clear of block collision
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Meteors, Grids, Characters,  // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                MaxTargetDistance = 2500,
                TopBlocks = 0, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef 
            {
                WeaponName = "Slinger AC150mm", // name of weapon in terminal
                DeviateShotAngle = 0.3f,
                AimingTolerance = .2f, // 0 - 180 firing angle
                AimLeadingPrediction = Accurate, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef {
                    RateOfFire = true,
                    DamageModifier = false,
                    ToggleGuidance = true,
                    EnableOverload =  false,
                },
                Ai = new AiDef {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = true,
                    LockOnFocus = false,
                },
                HardWare = new HardwareDef {
                   RotateRate = 0.015f,
                    ElevateRate = 0.015f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -10,
                    MaxElevation = 80,
                    FixedOffset = false,
                    InventorySize = .5f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = true,
                    Debug = false,
                },
                Loading = new LoadingDef {
                    RateOfFire = 60, //720= 12/sec, 5 ticks per shot
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, //heat generated per shot
                    MaxHeat = 400, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .6f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 10, //amount of heat lost per second
                    DegradeRof = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                    GiveUpAfterBurst = false,
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "",
                    FiringSound = "MA_Tiger_150shot", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "", //WepTurretGatlingRotate
                    BarrelRotationSound = "", //WepShipGatlingRotation
                },
                Graphics = new HardPointParticleDef {

                   Barrel1 = new ParticleDef {
                        Name = "MA150MuzzlePart", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 1000,
                            MaxDuration = 0,
                            Scale = 1f,
                        },
                    },
                    Barrel2 = new ParticleDef {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 0.5f),
                        Offset = Vector(x: 0, y: 0, z: -1),

                        Extras = new ParticleOptionDef {
                            Loop = true,
                            Restart = true,
                            MaxDistance = 500,
                            MaxDuration = 0,
                            Scale = 2f,
                        },
                    },
                },
            },
            Ammos = new [] {
                MA_150mm
            },
            Animations = MA_AC150_Animation,
            // Don't edit below this line
        };
		
		
 
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
    }
}