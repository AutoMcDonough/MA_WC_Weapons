﻿using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.ModelAssignmentsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.HardPointDef.Prediction;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.BlockTypes;
using static WeaponThread.WeaponStructure.WeaponDefinition.TargetingDef.Threat;

namespace WeaponThread {   
    partial class Weapons {
		// Don't edit above this line
 
				
        WeaponDefinition MA_Blister => new WeaponDefinition
        {	
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[]
                {
                    new MountPointDef {
                        SubtypeId = "MA_Blister",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3b",
                        ElevationPartId = "Part2",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_30mm.dds"
                    },
                  new MountPointDef {
                        SubtypeId = "MA_Blister_sm",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3b",
                        ElevationPartId = "Part2",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_30mm.dds"						
                    },
					new MountPointDef {
                        SubtypeId = "MA_Blister45",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3b",
                        ElevationPartId = "Part2",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_30mm.dds"						
                    },
					new MountPointDef {
                        SubtypeId = "MA_Blister45_sm",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3b",
                        ElevationPartId = "Part2",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_30mm.dds"						
                    },					
					new MountPointDef {
                        SubtypeId = "MA_Blister30",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3c",
                        ElevationPartId = "Part2",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_30mm.dds"						
                    },
					new MountPointDef {
                        SubtypeId = "MA_Blister32",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3d",
                        ElevationPartId = "Part2",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_30mm.dds"						
                    },
					new MountPointDef {
                        SubtypeId = "MA_Blister32_sm",
                        AimPartId = "",
                        MuzzlePartId = "Part2",
                        AzimuthPartId = "Base3d",
                        ElevationPartId = "Part2",
						DurabilityMod = 0.25f,
                        IconName = "filter_MA_30mm.dds"						
                    },					
                },
                Barrels = new []
                {
                    "muzzle_03", "muzzle_04",
                },
				Scope = "scope_02", //Where line of sight checks are performed from must be clear of block collision
				Ejector = "Shell_Casings",
            },
            Targeting = new TargetingDef
            {
                Threats = new[]
                {
                    Projectiles, Meteors, Characters, Grids, // threats percieved automatically without changing menu settings  Grids, Characters, Projectiles, Meteors,
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
                StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
				MaxTargetDistance = 1250,
            },
            HardPoint = new HardPointDef
            {
                WeaponName = "Blister Turret", // name of weapon in terminal
                DeviateShotAngle = 1.8f,
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
                    MinElevation = -5,
                    MaxElevation = 89,
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
                    RateOfFire = 720,
                    BarrelSpinRate = 0, // visual only, 0 disables and uses RateOfFire
                    BarrelsPerShot = 1,
                    TrajectilesPerBarrel = 1, // Number of Trajectiles per barrel per fire event.
                    SkipBarrels = 0,
                    ReloadTime = 120, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    DelayUntilFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 10, //heat generated per shot
                    MaxHeat = 1000, //max heat before weapon enters cooldown (70% of max heat)
                    Cooldown = .8f, //percent of max heat to be under to start firing again after overheat accepts .2-.95
                    HeatSinkRate = 20, //amount of heat lost per second
                    DegradeRof = true, // progressively lower rate of fire after 80% heat threshold (80% of max heat)
                    ShotsInBurst = 0,
                    DelayAfterBurst = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFullBurst = false,
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "MD_GatlingBarrelLoop",
                    FiringSound = "Blister_30_Shot", // subtype name from sbc
                    FiringSoundPerShot = true,
                    ReloadSound = "",
                    NoAmmoSound = "ArcWepShipGatlingNoAmmo",
                    HardPointRotationSound = "WepTurretGatlingRotate",
                    BarrelRotationSound = "MD_GatlingBarrelLoop",
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
                MA_30mm
            },
            Animations = BlisterAnimations,
            // Don't edit below this line
        };
		
    }
}