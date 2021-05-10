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
        WeaponDefinition MA_PDX => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_PDX",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = .25f,
                        IconName = "filter_energy.dds"
                    },
 

                    new MountPointDef {
                        SubtypeId = "MA_PDX_sm",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				
				
					
                },				
				
                Barrels = new []
                {
                    "muzzle_projectile_001",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors, Grids, Characters,  // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Offense, Thrust, Utility, Power, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "PDX", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = true,
                    ToggleGuidance = false,
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
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 90, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, //10 heat generated per shot
                    MaxHeat = 1200, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .5f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 60, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = true,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_1
            },
            Animations = PDX_Animations,
            // Don't edit below this line
        };



        WeaponDefinition MA_PDX_T2 => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_T2PDX",
                        AimPartId = "",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = .25f,
                        IconName = "filter_energy.dds"
                    },
 
                   new MountPointDef {
                        SubtypeId = "MA_T2PDX_Slope",
                        AimPartId = "",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = .25f,
                        IconName = "filter_energy.dds"
                    },

                   new MountPointDef {
                        SubtypeId = "MA_T2PDX_Slope2",
                        AimPartId = "",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = .25f,
                        IconName = "filter_energy.dds"
                    },				
					
                },				
				
                Barrels = new []
                {
                    "muzzle_projectile_001",
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
                    Offense, Thrust, Utility, Power, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "T2PDX", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = true,
                    ToggleGuidance = false,
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
                    RotateRate = 0.015f,
                    ElevateRate = 0.015f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -20,
                    MaxElevation = 89,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 90, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, //10 heat generated per shot
                    MaxHeat = 500, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .5f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 25, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_5
            },
            Animations = PDX_Animations,
            // Don't edit below this line
        };


        WeaponDefinition MA_Gimbal_Laser => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                   new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored_Slope",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds" 
 },


                   new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored_Slope2",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                  new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored_Slope45",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                  new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },

		
					
                },				
				
                Barrels = new []
                {
                    "muzzle_projectile_001",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors, Grids, Characters,  // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Offense, Thrust, Utility, Power, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Gimbal Laser", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = true,
                    ToggleGuidance = false,
                    EnableOverload =  true,
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
                    MinElevation = 45,
                    MaxElevation = 90,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = true,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 90, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 0, //10 heat generated per shot
                    MaxHeat = 1200, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .5f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 45, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = true,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_1
            },
            //Animations = PDX_Animations,
            // Don't edit below this line
        };





        WeaponDefinition MA_Gimbal_Laser_T2 => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_T2_Armored",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                   new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_T2_Armored_Slope",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds" 
 },


                   new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_T2_Armored_Slope2",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                  new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_T2_Armored_Slope45",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                  new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_T2",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },

		
					
                },				
				
                Barrels = new []
                {
                    "muzzle_projectile_001",
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
                    Offense, Thrust, Utility, Power, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Gimbal Laser T2", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = true,
                    ToggleGuidance = false,
                    EnableOverload =  true,
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
                    RotateRate = 0.02f,
                    ElevateRate = 0.02f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = 45,
                    MaxElevation = 90,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = true,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 90, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, //10 heat generated per shot
                    MaxHeat = 500, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .5f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 25, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_5
            },
            //Animations = PDX_Animations,
            // Don't edit below this line
        };



        WeaponDefinition MA_Gimbal_Laser_small => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {

                     new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored_sb",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				

 
                     new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored_Slope_sb",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				

 
                     new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored_Slope2_sb",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				


                     new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_Armored_Slope45_sb",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				


                     new MountPointDef {
                        SubtypeId = "MA_Gimbal_Laser_sb",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				


					
                },				
				
                Barrels = new []
                {
                    "muzzle_projectile_001",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors, Grids, Characters,  // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Offense, Thrust, Utility, Power, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Gimbal Laser Small", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Advanced, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = true,
                    ToggleGuidance = false,
                    EnableOverload =  true,
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
                    RotateRate = 0.1f,
                    ElevateRate = 0.1f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = 45,
                    MaxElevation = 90,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = true,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, //10 heat generated per shot
                    MaxHeat = 1200, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .5f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 60, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 60,
                    DelayAfterBurst = 240, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = true,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_1
            },
            //Animations = PDX_Animations,
            // Don't edit below this line
        };
		
       WeaponDefinition MA_PDT => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_PDT",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds" 
					},
				    new MountPointDef {
                        SubtypeId = "MA_PDT_sm",
                        AimPartId = "MissileTurretBarrels",
                        MuzzlePartId = "MissileTurretBarrels",
                        AzimuthPartId = "MissileTurretBase1",
                        ElevationPartId = "MissileTurretBarrels",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },

                },
                Barrels = new []
                {
                    "muzzle_projectile_001",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors,// threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Thrust, Utility, Offense, Power, Production, Any, // subsystems the gun targets
                },
                ClosestFirst = false, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 0, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "PDT", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = false,
                    ToggleGuidance = false,
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
                    RotateRate = 0.10f,
                    ElevateRate = 0.10f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = -20,
                    MaxElevation = 89,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 6, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 0, //heat generated per shot
                    MaxHeat = 1, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .95f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 1, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_3
            },
            //Animations = AdvancedAnimation,
            // Don't edit below this line
        };		

        WeaponDefinition MA_Fixed_Laser => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_Fixed_000",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                   new MountPointDef {
                        SubtypeId = "MA_Fixed_001",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                   new MountPointDef {
                        SubtypeId = "MA_Fixed_002",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                  new MountPointDef {
                        SubtypeId = "MA_Fixed_003",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },


                  new MountPointDef {
                        SubtypeId = "MA_Fixed_004",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },
                  new MountPointDef {
                        SubtypeId = "MA_Fixed_005",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },
                  new MountPointDef {
                        SubtypeId = "MA_Fixed_006",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },
                  new MountPointDef {
                        SubtypeId = "MA_Fixed_007",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },




				
					
                },				
				
                Barrels = new []
                {
                    "muzzle_missile_001",
                },
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Grids, Characters, Projectiles, Meteors, // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Thrust, Utility, Offense, Power, Production, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Fixed Laser", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = true,
                    ToggleGuidance = false,
                    EnableOverload =  true,
                },
                Ai = new AiDef
                {
                    TrackTargets = false,
                    TurretAttached = false,
                    TurretController = false,
                    PrimaryTracking = false,
                    LockOnFocus = false,
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.1f,
                    ElevateRate = 0.1f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = 45,
                    MaxElevation = 90,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 700, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, //10 heat generated per shot
                    MaxHeat = 800, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .5f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 25, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_4
            },
            //Animations = PDX_Animations,
            // Don't edit below this line
        };



        WeaponDefinition MA_Fixed_Laser_small => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {

                     new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_000",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				

 
                    new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_001",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				

 
                    new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_002",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				


                     new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_003",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				


                    new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_004",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				

                    new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_005",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				
                    new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_006",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				
                    new MountPointDef {
                        SubtypeId = "MA_Fixed_sb_007",
                        AimPartId = "None",
                        MuzzlePartId = "None",
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
						DurabilityMod = 0.25f,
                        IconName = "filter_energy.dds"
                    },				







					
                },				
				
                Barrels = new []
                {
                    "muzzle_missile_001",
                },
            },
           Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Grids, Characters, Projectiles, Meteors, // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
                },
                SubSystems = new[]
                {
                    Thrust, Utility, Offense, Power, Production, Any, // subsystems the gun targets
                },
                ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
                MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
                MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
                TopTargets = 0, // 0 = unlimited, max number of top targets to randomize between.
                TopBlocks = 4, // 0 = unlimited, max number of blocks to randomize between
                StopTrackingSpeed = 10000, // do not track target threats traveling faster than this speed
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Fixed Laser", // name of weapon in terminal
                DeviateShotAngle = 0f,
                AimingTolerance = 0.1f, // 0 - 180 firing angle
                AimLeadingPrediction = Off, // Off, Basic, Accurate, Advanced
                DelayCeaseFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).

                Ui = new UiDef
                {
                    RateOfFire = false,
                    DamageModifier = true,
                    ToggleGuidance = false,
                    EnableOverload =  true,
                },
                Ai = new AiDef
                {
                    TrackTargets = false,
                    TurretAttached = false,
                    TurretController = false,
                    PrimaryTracking = false,
                    LockOnFocus = false,
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.1f,
                    ElevateRate = 0.1f,
                    MinAzimuth = -180,
                    MaxAzimuth = 180,
                    MinElevation = 45,
                    MaxElevation = 90,
                    FixedOffset = false,
                    InventorySize = 0.658f,
                    Offset = Vector(x: 0, y: 0, z: 0),
                },
                Other = new OtherDef
                {
                    GridWeaponCap = 0,
                    RotateBarrelAxis = 0,
                    EnergyPriority = 0,
                    MuzzleCheck = false,
                    Debug = false,
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 3600,
                    BarrelSpinRate = 700, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 10, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, //10 heat generated per shot
                    MaxHeat = 800, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .5f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 20, //amount of heat lost per second
                    DegradeRof = false, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "",
                    FiringSound = "", // subtype name from sbc
                    FiringSoundPerShot = false,
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "",
                    BarrelRotationSound = "",
                },
                Graphics = new HardPointParticleDef
                {
                    Barrel1 = new ParticleDef
                    {
                        Name = "", // Smoke_LargeGunShot
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 200,
                            MaxDuration = 1,
                            Scale = 1.0f,
                        },
                    },
                    Barrel2 = new ParticleDef
                    {
                        Name = "",//Muzzle_Flash_Large
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 100,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
       
			Ammos = new [] {
                MA_Laser_4
            },
            //Animations = PDX_Animations,
            // Don't edit below this line
        };
		
	
		
		
		
		
    }
}