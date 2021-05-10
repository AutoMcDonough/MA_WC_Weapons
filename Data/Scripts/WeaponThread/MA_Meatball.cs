
using System.Collections.Generic;
using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.HardwareDef.ArmorState;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace WeaponThread {   
    partial class Weapons {
		// Don't edit above this line
        WeaponDefinition Meatball_Center => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_Meatball",
                        AimPartId = "",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_nato.dds"						
                    },

                },
                Barrels = new []
                {
                    "muzzle_01", "muzzle_02",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors, Characters, Grids, // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Offense, Thrust, Utility, Power, Production, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 1, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
				MaxTargetDistance = 1000,
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Meatball", // name of weapon in terminal
                DeviateShotAngle = 2f,
                AimingTolerance = .3f, // 0 - 180 firing angle
                AimLeadingPrediction = Accurate, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = true,
                    DamageModifier = false,
                    ToggleGuidance = true,
                    EnableOverload =  false,
                },
                Ai = new AiDef
                {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = true,
                    LockOnFocus = true,
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.03f,
                    ElevateRate = 0.03f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -20,
                    MaxElevation = 89,
                    FixedOffset = false,
                    InventorySize = 0.65f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 2,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 800,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 2,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 300, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 3, //heat generated per shot
                    MaxHeat = 2000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .2f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 13, //amount of heat lost per second
                    DegradeRof = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "WepShipGatlingShot", // subtype name from sbc
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "WepShipGatlingRotation",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "MA_Gatling_Flash",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),//offset is bugged right now
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = true,
                            MaxDistance = 600,
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
                MA_Gatling
            },
            Animations = MeatBallCenterAnimations,
            // Don't edit below this line
        };

        WeaponDefinition Meatball_Left => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_Meatball",
                        AimPartId = "",
                        MuzzlePartId = "Part3",
                        AzimuthPartId = "Base4",
                        ElevationPartId = "Part3",
                    },

                },
                Barrels = new []
                {
                    "muzzle_05", "muzzle_06",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors, Characters, Grids, // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Offense, Thrust, Utility, Power, Production, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 1, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Meatball Left Side", // name of weapon in terminal
                DeviateShotAngle = 2f,
                AimingTolerance = .3f, // 0 - 180 firing angle
                AimLeadingPrediction = Accurate, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = true,
                    DamageModifier = false,
                    ToggleGuidance = true,
                    EnableOverload =  false,
                },
                Ai = new AiDef
                {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = false,
                    LockOnFocus = true,
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.03f,
                    ElevateRate = 0.03f,
                    MinAzimuth = -160,
                    MaxAzimuth = 160,
                    MinElevation = -5,
                    MaxElevation = 85,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 2,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 800,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 2,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 300, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 31, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 3, //heat generated per shot
                    MaxHeat = 2000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .2f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 13, //amount of heat lost per second
                    DegradeRof = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "WepShipGatlingShot", //"WepTurretInteriorFire", // subtype name from sbc
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "WepShipGatlingRotation",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "MA_Gatling_Flash",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),//offset is bugged right now
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = true,
                            MaxDistance = 600,
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
                MA_Gatling
            },
            Animations = MeatBallLeftAnimations,
            // Don't edit below this line
        };  
		
        WeaponDefinition Meatball_Right => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_Meatball",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3",
                        ElevationPartId = "Part2",
                    },

                },
                Barrels = new []
                {
                    "muzzle_03", "muzzle_04",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors, Characters, Grids, // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Offense, Thrust, Utility, Power, Production, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 1, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Meatball Right Side", // name of weapon in terminal
                DeviateShotAngle = 2f,
                AimingTolerance = .3f, // 0 - 180 firing angle
                AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = true,
                    DamageModifier = false,
                    ToggleGuidance = true,
                    EnableOverload =  false,
                },
                Ai = new AiDef
                {
                    TrackTargets = true,
                    TurretAttached = true,
                    TurretController = true,
                    PrimaryTracking = false,
                    LockOnFocus = true,
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.03f,
                    ElevateRate = 0.03f,
                    MinAzimuth = -160,
                    MaxAzimuth = 160,
                    MinElevation = -5,
                    MaxElevation = 85,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 2,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 800,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 2,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 300, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 31, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 3, //heat generated per shot
                    MaxHeat = 2000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .2f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 13, //amount of heat lost per second
                    DegradeRof = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "WepShipGatlingShot", // subtype name from sbc
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "WepShipGatlingRotation",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "MA_Gatling_Flash",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),//offset is bugged right now
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = true,
                            MaxDistance = 600,
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
                MA_Gatling
            },
            Animations = MeatBallRightAnimations,
            // Don't edit below this line
        };  
				
 
		
		
		
    }
}