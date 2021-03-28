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
        WeaponDefinition MA_Tiger => new WeaponDefinition {

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "MA_Tiger",
                        AimPartId = "barrel", //not used anymore
                        MuzzlePartId = "barrel",
                        AzimuthPartId = "az",
                        ElevationPartId = "gimbal",
						DurabilityMod = 0.75f,
                        IconName = "filter_MA_150mm.dds"
                    },
  
   
                    new MountPointDef {
                        SubtypeId = "MA_Tiger_sm",
                        AimPartId = "barrel", //not used anymore
                        MuzzlePartId = "barrel",
                        AzimuthPartId = "az",
                        ElevationPartId = "gimbal",
						DurabilityMod = 0.75f,
                        IconName = "filter_MA_150mm.dds"
                    },
  
                },

                Barrels = new [] {
                    "muzzle_01",
                    "muzzle_02",
                    "muzzle_03",
                    "muzzle_04",
                    
                },
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
                ClosestFirst = false, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                MaxTargetDistance = 2500,
                TopBlocks = 0, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef 
            {
                WeaponName = "Tiger 150mm", // name of weapon in terminal
                DeviateShotAngle = 0.1f,
                AimingTolerance = .5f, // 0 - 180 firing angle
                AimLeadingPrediction = Basic, // Off, Basic, Accurate, Advanced
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
                    RotateRate = 0.01f,
                    ElevateRate = 0.01f,
                    MinAzimuth = -3,
                    MaxAzimuth = 3,
                    MinElevation = -5,
                    MaxElevation = 3,
                    FixedOffset = false,
                    InventorySize = .5f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef {
                    RateOfFire = 720, //720= 12/sec, 5 ticks per shot
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 340, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 10, //heat generated per shot
                    MaxHeat = 400, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .6f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 9, //amount of heat lost per second
                    DegradeRof = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 4,
                    DelayAfterBurst = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = true,
                    GiveUpAfterBurst = false,
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "",
                    FiringSound = "MA_Tiger_150shot", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "MA_Tiger_reload",
                    NoAmmoSound = "",
                    HardPointRotationSound = "", //WepTurretGatlingRotate
                    BarrelRotationSound = "", //WepShipGatlingRotation
                },
                Graphics = new HardPointParticleDef {

                    Barrel1 = new ParticleDef {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 50,
                            MaxDuration = 6,
                            Scale = 1f,
                        },
                    },
                    Barrel2 = new ParticleDef {
                        Name = "MA_Gatling_Flash",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 0.5f),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 1500,
                            MaxDuration = 6,
                            Scale = 7f,
                        },
                    },
                },
            },
            Ammos = new [] {
                MA_150mm
            },
            Animations = MA_Tiger_Animation,
            // Don't edit below this line
        };
		
		
        WeaponDefinition MA_Tiger_30_sm => new WeaponDefinition {

            Assignments = new ModelAssignmentsDef 
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "MA_Tiger_30_sm",
                        AimPartId = "barrel_30", //not used anymore
                        MuzzlePartId = "barrel_30",
                        AzimuthPartId = "az_30",
                        ElevationPartId = "gimbal_30",
						DurabilityMod = 0.75f,
                        IconName = "filter_MA_30mm.dds"
                    },
  
                },









                Barrels = new [] {
                    "muzzle_01",
                    "muzzle_02",
                    "muzzle_03",
                    "muzzle_04",
                    
                },
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
                ClosestFirst = false, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                MaxTargetDistance = 1500,
                TopBlocks = 0, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef 
            {
                WeaponName = "Tiger 30mm", // name of weapon in terminal
                DeviateShotAngle = 0.1f,
                AimingTolerance = .5f, // 0 - 180 firing angle
                AimLeadingPrediction = Basic, // Off, Basic, Accurate, Advanced
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
                    RotateRate = 0.01f,
                    ElevateRate = 0.01f,
                    MinAzimuth = -3,
                    MaxAzimuth = 3,
                    MinElevation = -5,
                    MaxElevation = 3,
                    FixedOffset = false,
                    InventorySize = .125f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef {
                    RateOfFire = 1200, //720= 12/sec, 5 ticks per shot
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 330, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 5, //heat generated per shot
                    MaxHeat = 500, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .6f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 5, //amount of heat lost per second
                    DegradeRof = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 4,
                    DelayAfterBurst = 15, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = true,
                    GiveUpAfterBurst = false,
                },
                Audio = new HardPointAudioDef {
                    PreFiringSound = "",
                    FiringSound = "MA_Tiger_30shot", // WepShipGatlingShot
                    FiringSoundPerShot = true,
                    ReloadSound = "MA_Tiger_30_reload",
                    NoAmmoSound = "",
                    HardPointRotationSound = "", //WepTurretGatlingRotate
                    BarrelRotationSound = "", //WepShipGatlingRotation
                },
                Graphics = new HardPointParticleDef {

                    Barrel1 = new ParticleDef {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 255, green: 0, blue: 0, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 50,
                            MaxDuration = 6,
                            Scale = 1f,
                        },
                    },
                    Barrel2 = new ParticleDef {
                        Name = "MA_Gatling_Flash",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 0.5f),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 1500,
                            MaxDuration = 5,
                            Scale = 1.5f,
                        },
                    },
                },
            },
            Ammos = new [] {
                MA_30mm
            },
            Animations = MA_Tiger_30_Animation,
            // Don't edit below this line
        };		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
    }
}