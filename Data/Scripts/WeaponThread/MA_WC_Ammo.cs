using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AmmoEjectionDef.SpawnType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.ShapeDef.Shapes;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.TrajectoryDef.GuidanceType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.DamageScaleDef.ShieldDef.ShieldType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.EwarFieldsDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.EwarFieldsDef.PushPullDef.Force;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.AreaDamageDef.AreaEffectType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.Texture;
using static WeaponThread.WeaponStructure.WeaponDefinition.AmmoDef.GraphicDef.LineDef.TracerBaseDef;
namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
		private AmmoDef MA_Gatling => new AmmoDef
        {
			AmmoMagazine = "NATO_25x184mm",
			AmmoRound = "MA_GatlingAmmo",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.00000000001f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 100f,
            Mass = 1f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 50f,
            DecayPerShot = 0f,
            HardPointUsable = true, // set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
            EnergyMagazineSize = 0,
            IgnoreWater = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 1,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
                PatternSteps = 1, // Number of Ammos activated per round, will progress in order and loop.  Ignored if Random = true.
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                VoxelHitModifier = 10,
                Characters = -1f,
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                FallOff = new FallOffDef
                {
                    Distance = -1f, // Distance at which max damage begins falling off.
                    MinMultipler = 1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
					Armor = 0.8f,
					Light = 0.8f,
					Heavy = 0.6f,
					NonArmor = 1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = -1f,
                    Type = Kinetic,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "",
                            Modifier = 2f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                Base = new AreaInfluence
                {
                    Radius = 10f, // the sphere of influence of area effects
                    EffectStrength = 0f, // For ewar it applies this amount per pulse/hit, non-ewar applies this as damage per tick per entity in area of influence. For radiant 0 == use spillover from BaseDamage, otherwise use this value.
                },
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 0,
                    PulseChance = 0,
                    GrowTime = 0,
                    HideModel = false,
                    ShowParticle = false,
                    Particle = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    NoShrapnel = false,
                    NoDeformation = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 0,
                    DetonationRadius = 0,
                    MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 1,
                    StackDuration = false,
                    Depletable = false,
                    MaxStacks = 0,
                    TriggerRange = 0f,
                    DisableParticleEffect = true,
                    Force = new PushPullDef // AreaEffectDamage is multiplied by target mass.
                    {
                        ForceFrom = ProjectileLastPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                        ForceTo = HitPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                        Position = TargetCenterOfMass, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    },
                },
            },
            Beams = new BeamDef
            {
                Enable = false,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = false, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 700,
                MaxTrajectory = 1500f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 0, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 0, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                },
                Mines = new MinesDef
                {
                    DetectRadius = 0,
                    DeCloakRadius = 0,
                    FieldTime = 0,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "MA_Bullet_hit",
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 3, green: 2f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 2500,
                            MaxDuration = 5,
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                    Eject = new ParticleDef
                    {
                        Name = "Shell_Casings",
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 3, green: 1.9f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 500,
                            MaxDuration = 60,
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    ColorVariance = Random(start: 0f, end: 10f), // multiply the color by random values within range.
                    WidthVariance = Random(start: 0f, end: 0.01f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 3f,
                        Width = 0.05f,
                        Color = Color(red: 5, green: 2, blue: 1f, alpha: 1),
                        VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "ProjectileTrailLine",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = false, // If true Tracer TextureMode is ignored
                            Textures = new[] {
								"",
                            },
                            SegmentLength = 0f, // Uses the values below.
                            SegmentGap = 0f, // Uses Tracer textures and values
                            Speed = 1f, // meters per second
                            Color = Color(red: 1, green: 2, blue: 2.5f, alpha: 1),
                            WidthMultiplier = 1f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: 0f, end: 0f),
                            ColorVariance = Random(start: 0f, end: 0f)
                        }
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Textures = new[] {
							"WeaponLaser",
                        },
                        TextureMode = Normal,
                        DecayTime = 10,
                        Color = Color(red: 1, green: 1, blue: 0.75f, alpha: 0.5f),
                        Back = false,
                        CustomWidth = 0f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "ArcImpMetalMetalCat0",
                ShieldHitSound = "",
                PlayerHitSound = "",
                VoxelHitSound = "",
                FloatingHitSound = "",
                HitPlayChance = 0.1f,
                HitPlayShield = true,
            }, // Don't edit below this line
            Ejection = new AmmoEjectionDef
            {
                Type = Particle, // Particle or Item (Inventory Component)
                Speed = 100f, // Speed inventory is ejected from in dummy direction
                SpawnChance = 0.5f, // chance of triggering effect (0 - 1)
                CompDef = new ComponentDef
                {
                    ItemDefinition = "", //InventoryComponent name
                    LifeTime = 0, // how long item should exist in world
                    Delay = 0, // delay in ticks after shot before ejected
                }
            },
        };
		

		
        private AmmoDef MA_Laser_1 => new AmmoDef //T1 red pulse gimbal, pdx
        {
            AmmoMagazine = "Energy",
            AmmoRound = "MA_Laser_1",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 1f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel    (15 * 0.05 * 3600/60/60 = 0.75MW per tick)
            BaseDamage = 10f,
            Mass = 0f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
			DecayPerShot = 0f,            
            HardPointUsable = true,
            EnergyMagazineSize = 60,
            IgnoreWater = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.3, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = 0.25f,
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.5f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = 0.8f,
                    Heavy = 0.4f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 5f,
                    Type = Energy,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "",
                            Modifier = 2f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 0, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 0,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 75,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 100000,
                    DetonationRadius = 75,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = true, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 10f,
                DesiredSpeed = 30000,
                MaxTrajectory = 2500f,
                FieldTime = 600, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 5, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0,
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 1000,
                            MaxDuration = 0,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LaserHitParticlesGimbal",//LaserHitParticlesGimbal
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 10, green: 2, blue: 1, alpha: 0.8f),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 500,
                            MaxDuration = 0,
                            Scale = 1,
                            HitPlayChance = 1,
                        },
                    },
                    Eject = new ParticleDef
                    {
                        Name = "",
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 3, green: 1.9f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 30,
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                },

                Lines = new LineDef
                {
                    ColorVariance = Random(start: 0.8f, end: 1f), // multiply the color by random values within range.
                    WidthVariance = Random(start: -.05f, end: 0f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = .1f,
                        Color = Color(red: 10, green: 0, blue: 0, alpha: .9f),
                        VisualFadeStart = 45, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 60, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "WeaponLaser",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = true, // If true Tracer TextureMode is ignored
                            Textures = new[] {
								"WeaponLaser",
                            },
                            SegmentLength = 20f, // Uses the values below.
                            SegmentGap = 15f, // Uses Tracer textures and values
                            Speed = 40f, // meters per second
                            Color = Color(red: 20, green: 0, blue: 0, alpha: .8f),
                            WidthMultiplier = .9f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: -.05f, end: 0f),
                            ColorVariance = Random(start: 0.6f, end: 1f)
                        }
                    },
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Textures = new[] {
							"",
                        },
                        TextureMode = Normal,
                        DecayTime = 128,
                        Color = Color(red: 0, green: 0, blue: 1, alpha: 1),
                        Back = false,
                        CustomWidth = 0,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
 
        private AmmoDef MA_Laser_2 => new AmmoDef //T3 continuous amber gladius laser
        {
            AmmoMagazine = "Energy",
            AmmoRound = "MA_Laser_2",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 1f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel    (15 * 0.05 * 3600/60/60 = 0.75MW per tick)
            BaseDamage = 120f,
            Mass = 0f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
			DecayPerShot = 0f,            
            HardPointUsable = true,
            EnergyMagazineSize = 0,
            IgnoreWater = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = .5f,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
			Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.5f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = .8f,
                    Heavy = .4f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 5f,
                    Type = Energy,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "",
                            Modifier = 2f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 0, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 0,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 75,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 100000,
                    DetonationRadius = 75,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = true, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = true, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = true, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 10f,
                DesiredSpeed = 30000,
                MaxTrajectory = 2500f,
                FieldTime = 600, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 5, // How long the weapon must fire before it reaches MaxTrajectory.
               Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0,
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "Big_melting_laser_hit", //MA_laserhit
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 800,
                            MaxDuration = 0,
                            Scale = 1,
                            HitPlayChance = 0.5f,
                        },
                    },
                },

               Lines = new LineDef
                {
                    ColorVariance = Random(start: 0.8f, end: 1f), // multiply the color by random values within range.
                    WidthVariance = Random(start: -.1f, end: 0f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = .5f,
                        Color = Color(red: 10, green: 3, blue: 0, alpha: .9f),
                        VisualFadeStart = 440, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 480, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "WeaponLaser",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = true, // If true Tracer TextureMode is ignored
                            Textures = new[] {
                                "WeaponLaser",
                            },
                            SegmentLength = 30f, // Uses the values below.
                            SegmentGap = 15f, // Uses Tracer textures and values
                            Speed = 80f, // meters per second
                            Color = Color(red: 15, green: 5, blue: .5f, alpha: .9f),
                            WidthMultiplier = 1f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: -.1f, end: 0f),
                            ColorVariance = Random(start: 0.6f, end: 1.1f)
                        }
                    },









 
					
					
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 600,
                        Color = Color(red: 10, green: 0, blue: 0, alpha: 1),
                        Back = false,
                        CustomWidth = 0.5f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 1,
                        MaxLength = 1,
                    },
                },

            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
 
        private AmmoDef MA_Ion_1 => new AmmoDef //gladius and EMP ion
        {
            AmmoMagazine = "Energy",
            AmmoRound = "MA_Ion_1",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = .5f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel
            BaseDamage = 1f,
            Mass = 0f, // in kilograms
            Health = 1000, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
            DecayPerShot = 0f,
            HardPointUsable = true, // set to false if this is a shrapnel ammoType and you don't want the turret to be able to select it directly.
            EnergyMagazineSize = 0,
            IgnoreWater = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 1,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            Pattern = new AmmoPatternDef
            {
                Ammos = new[] {
                    "",
                },
                Enable = false,
                TriggerChance = 1f,
                Random = false,
                RandomMin = 1,
                RandomMax = 1,
                SkipParent = false,
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 0.5, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).
                VoxelHitModifier = 10,
                Characters = -1f,
                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.5f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = -1f,
                    Heavy = -1f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 1f,
                    Type = Energy,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test1",
                            Modifier = -1f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = EmpField, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 5f, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 5f,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 1,
                    PulseChance = 100,
                    GrowTime = 0,
                    HideModel = false,
                    ShowParticle = false,
                    Particle = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 0,
                    DetonationRadius = 0,
                    MinArmingTime = 0, //Min time in ticks before projectile will arm for detonation (will also affect shrapnel spawning)
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 180,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 1,
                    TriggerRange = 1f,
                    DisableParticleEffect = true,
                    Force = new PushPullDef // AreaEffectDamage is multiplied by target mass.
                    {
                        ForceFrom = ProjectileLastPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                        ForceTo = HitPosition, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                        Position = TargetCenterOfMass, // ProjectileLastPosition, ProjectileOrigin, HitPosition, TargetCenter, TargetCenterOfMass
                    },
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = true, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 0f,
                DesiredSpeed = 1040,
                MaxTrajectory = 500f,
                FieldTime = 0, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 5, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 0, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 0, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0, // Number of targets allowed before ending, 0 = unlimited
                    NoTargetExpire = false, // Expire without ever having a target at TargetLossTime
                    Roam = false, // Roam current area after target loss
                },
                Mines = new MinesDef
                {
                    DetectRadius = 0,
                    DeCloakRadius = 0,
                    FieldTime = 0,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = false,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 1, green: 1, blue: 15, alpha: 0.8f),
                        Offset = Vector(x: 0, y: 0, z: 1),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "MA_Damage_Electrical_Damaged",
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 1f, green: 2f, blue: 3f, alpha: 1f),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false,
                            Restart = true,
                            MaxDistance = 1000,
                            MaxDuration = 10,
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                    Eject = new ParticleDef
                    {
                        Name = "",
                        ApplyToShield = true,
                        ShrinkByDistance = false,
                        Color = Color(red: 3, green: 1.9f, blue: 1f, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 30,
                            Scale = 1,
                            HitPlayChance = 1f,
                        },
                    },
                },
                Lines = new LineDef
                {
                    ColorVariance = Random(start: 0.8f, end: 1f), // multiply the color by random values within range.
                    WidthVariance = Random(start: -.1f, end: 0f), // adds random value to default width (negatives shrinks width)
                    Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = 1f,
                        Color = Color(red: 1, green: 2, blue: 3f, alpha: 0.9f),
                        VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "WeaponLaser",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = true, // If true Tracer TextureMode is ignored
                            Textures = new[] {
                                "BlackFireSeg1",
                                "BlackFireSeg2",
                                "BlackFireSeg3",
                                "BlackFireSeg4",
                                "BlackFireSeg5",
                                "BlackFireSeg6",
                                "BlackFireSeg7",
                                "BlackFireSeg8",
                            },
                            SegmentLength = 50f, // Uses the values below.
                            SegmentGap = 0f, // Uses Tracer textures and values
                            Speed = 80f, // meters per second
                            Color = Color(red: 1, green: 2, blue: 3f, alpha: 1),
                            WidthMultiplier = 1f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: -.5f, end: .5f),
                            ColorVariance = Random(start: 0.1f, end: 9f)
                        }
                    },
                    Trail = new TrailDef
                    {
                        Enable = false,
                        Textures = new[] {
							"",
                        },
                        TextureMode = Normal,
                        DecayTime = 128,
                        Color = Color(red: 0, green: 0, blue: 1, alpha: 1),
                        Back = false,
                        CustomWidth = 0,
                        UseWidthVariance = false,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 0.2f,
                        MaxLength = 3,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "ParticleElectrical",
                ShieldHitSound = "",
                PlayerHitSound = "",
                VoxelHitSound = "",
                FloatingHitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
            Ejection = new AmmoEjectionDef
            {
                Type = Particle, // Particle or Item (Inventory Component)
                Speed = 100f, // Speed inventory is ejected from in dummy direction
                SpawnChance = 0.5f, // chance of triggering effect (0 - 1)
                CompDef = new ComponentDef
                {
                    ItemDefinition = "", //InventoryComponent name
                    LifeTime = 0, // how long item should exist in world
                    Delay = 0, // delay in ticks after shot before ejected
                }
            },
        };

       private AmmoDef MA_Laser_3 => new AmmoDef //purple pulse low power for PDT
        {
            AmmoMagazine = "Energy",
            AmmoRound = "MA_Laser_3",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 0.5f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel    (15 * 0.05 * 3600/60/60 = 0.75MW per tick)
            BaseDamage = 5f,
            Mass = 0f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
			DecayPerShot = 0f,            
            HardPointUsable = true,
            EnergyMagazineSize = 1,
            IgnoreWater = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = .1f,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.
                HealthHitModifier = 2, // defaults to a value of 1, this setting modifies how much Health is subtracted from a projectile per hit (1 = per hit).


                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = -1f,
                FallOff = new FallOffDef
                {
                    Distance = 1200f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.1f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = 0f,
                    Small = 0f,
                },
                Armor = new ArmorDef
                {
                    Armor = 0f,
                    Light = 0f,
                    Heavy = 0f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 2f,
                    Type = Energy,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "",
                            Modifier = 2f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 0, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 0,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 75,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 100000,
                    DetonationRadius = 75,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = true, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 10f,
                DesiredSpeed = 30000,
                MaxTrajectory = 500f,
                FieldTime = 600, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0,
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LaserHitParticlesGimbal",//LaserHitParticlesGimbal
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 5, green: 2, blue: 5, alpha: 0.8f),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 500,
                            MaxDuration = 0,
                            Scale = 1,
                            HitPlayChance = 1,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.75f, end: 1.25f), // multiply the color by random values within range.
                    WidthVariance = Random(start: -.01f, end: 0.01f), // adds random value to default width (negatives shrinks width)

                   Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = .1f,
                        Color = Color(red: 5, green: 1, blue: 15, alpha: 1f),
                        VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 5, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "WeaponLaser",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = false, // If true Tracer TextureMode is ignored
                            Textures = new[] {
                                "WeaponLaser",
                            },
                            SegmentLength = 5f, // Uses the values below.
                            SegmentGap = 3f, // Uses Tracer textures and values
                            Speed = 60f, // meters per second
							Color = Color(red: 5, green: 2, blue: 9, alpha: 1),
                            WidthMultiplier = .9f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: -.005f, end: 0.005f),
                            ColorVariance = Random(start: 0.6f, end: 1f)
                        }
                    },
                    Trail = new TrailDef
                    {
                        Enable = true,
                        Material = "WeaponLaser",
                        DecayTime = 10,
						Color = Color(red: 5, green: 2, blue: 9, alpha: 1),
                        Back = false,
                        CustomWidth = 0.05f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 1,
                        MaxLength = 1,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
 
       private AmmoDef MA_Laser_4 => new AmmoDef //T2 continuous orange fixed lasers
        {
            AmmoMagazine = "Energy",
            AmmoRound = "MA_Laser_4",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 1f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel    (15 * 0.05 * 3600/60/60 = 0.75MW per tick)
            BaseDamage = 40f,
            Mass = 0f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
			DecayPerShot = 0f,            
            HardPointUsable = true,
            IgnoreWater = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = 0.25f,
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.5f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = .8f,
                    Heavy = .4f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 5f,
                    Type = Energy,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "",
                            Modifier = 2f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 0, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 0,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 75,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 100000,
                    DetonationRadius = 75,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = true, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 10f,
                DesiredSpeed = 30000,
                MaxTrajectory = 2500f,
                FieldTime = 600, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 5, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0,
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LaserHitParticlesGimbal",//LaserHitParticlesGimbal
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 10, green: 2, blue: 1, alpha: 0.8f),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 500,
                            MaxDuration = 0,
                            Scale = 1,
                            HitPlayChance = 1,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.85f, end: 1f), // multiply the color by random values within range.
                    WidthVariance = Random(start: -.05f, end: 0f), // adds random value to default width (negatives shrinks width)

                   Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = .25f,
                        Color = Color(red: 10, green: 1, blue: 0, alpha: .9f),
                        VisualFadeStart = 0, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 0, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "WeaponLaser",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = true, // If true Tracer TextureMode is ignored
                            Textures = new[] {
                                "WeaponLaser",
                            },
                            SegmentLength = 20f, // Uses the values below.
                            SegmentGap = 15f, // Uses Tracer textures and values
                            Speed = 40f, // meters per second
                            Color = Color(red: 20, green: 2, blue: 0, alpha: .8f),
                            WidthMultiplier = .9f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: -.05f, end: 0f),
                            ColorVariance = Random(start: 0.6f, end: 1f)
                        }
                    },









                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 15,
                        Color = Color(red: 5, green: 1, blue: 0, alpha: 1),
                        Back = false,
                        CustomWidth = 0.25f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 1,
                        MaxLength = 1,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };
 
       private AmmoDef MA_Laser_5 => new AmmoDef //T2 orange pulse for turrets
        {
            AmmoMagazine = "Energy",
            AmmoRound = "MA_Laser_5",
            HybridRound = false, //AmmoMagazine based weapon with energy cost
            EnergyCost = 1f, //(((EnergyCost * DefaultDamage) * ShotsPerSecond) * BarrelsPerShot) * ShotsPerBarrel    (15 * 0.05 * 3600/60/60 = 0.75MW per tick)
            BaseDamage = 40f,
            Mass = 0f, // in kilograms
            Health = 0, // 0 = disabled, otherwise how much damage it can take from other trajectiles before dying.
            BackKickForce = 0f,
			DecayPerShot = 0f,            
            HardPointUsable = true,
            EnergyMagazineSize = 120,
            IgnoreWater = false,

            Shape = new ShapeDef //defines the collision shape of projectile, defaults line and visual Line Length if set to 0
            {
                Shape = LineShape,
                Diameter = 0,
            },
            ObjectsHit = new ObjectsHitDef
            {
                MaxObjectsHit = 0, // 0 = disabled
                CountBlocks = false, // counts gridBlocks and not just entities hit
            },
            Shrapnel = new ShrapnelDef
            {
                AmmoRound = "",
                Fragments = 100,
                Degrees = 15,
                Reverse = false,
                RandomizeDir = false, // randomzie between forward and backward directions
            },
            DamageScales = new DamageScaleDef
            {
                MaxIntegrity = 0f, // 0 = disabled, 1000 = any blocks with currently integrity above 1000 will be immune to damage.
                DamageVoxels = false, // true = voxels are vulnerable to this weapon
                SelfDamage = false, // true = allow self damage.

                // modifier values: -1 = disabled (higher performance), 0 = no damage, 0.01 = 1% damage, 2 = 200% damage.
                Characters = 0.25f,
                FallOff = new FallOffDef
                {
                    Distance = 1000f, // Distance at which max damage begins falling off.
                    MinMultipler = 0.5f, // value from 0.0f to 1f where 0.1f would be a min damage of 10% of max damage.
                },
                Grids = new GridSizeDef
                {
                    Large = -1f,
                    Small = -1f,
                },
                Armor = new ArmorDef
                {
                    Armor = -1f,
                    Light = .8f,
                    Heavy = .4f,
                    NonArmor = -1f,
                },
                Shields = new ShieldDef
                {
                    Modifier = 5f,
                    Type = Energy,
                    BypassModifier = -1f,
                },
                // first true/false (ignoreOthers) will cause projectiles to pass through all blocks that do not match the custom subtypeIds.
                Custom = new CustomScalesDef
                {
                    IgnoreAllOthers = false,
                    Types = new[]
                    {
                        new CustomBlocksDef
                        {
                            SubTypeId = "",
                            Modifier = 2f,
                        },
                        new CustomBlocksDef
                        {
                            SubTypeId = "Test2",
                            Modifier = -1f,
                        },
                    },
                },
            },
            AreaEffect = new AreaDamageDef
            {
                AreaEffect = Disabled, // Disabled = do not use area effect at all, Explosive, Radiant, AntiSmart, JumpNullField, JumpNullField, EnergySinkField, AnchorField, EmpField, OffenseField, NavField, DotField.
                AreaEffectDamage = 0, // 0 = use spillover from BaseDamage, otherwise use this value.
                AreaEffectRadius = 0,
                Pulse = new PulseDef // interval measured in game ticks (60 == 1 second), pulseChance chance (0 - 100) that an entity in field will be hit
                {
                    Interval = 60,
                    PulseChance = 75,
                },
                Explosions = new ExplosionDef
                {
                    NoVisuals = false,
                    NoSound = false,
                    Scale = 1,
                    CustomParticle = "",
                    CustomSound = "",
                },
                Detonation = new DetonateDef
                {
                    DetonateOnEnd = false,
                    ArmOnlyOnHit = false,
                    DetonationDamage = 100000,
                    DetonationRadius = 75,
                },
                EwarFields = new EwarFieldsDef
                {
                    Duration = 60,
                    StackDuration = true,
                    Depletable = false,
                    MaxStacks = 10,
                    TriggerRange = 5f,
                },
            },
            Beams = new BeamDef
            {
                Enable = true,
                VirtualBeams = false, // Only one hot beam, but with the effectiveness of the virtual beams combined (better performace)
                ConvergeBeams = false, // When using virtual beams this option visually converges the beams to the location of the real beam.
                RotateRealBeam = false, // The real (hot beam) is rotated between all virtual beams, instead of centered between them.
                OneParticle = true, // Only spawn one particle hit per beam weapon.
            },
            Trajectory = new TrajectoryDef
            {
                Guidance = None,
                TargetLossDegree = 80f,
                TargetLossTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                MaxLifeTime = 0, // 0 is disabled, Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                AccelPerSec = 10f,
                DesiredSpeed = 30000,
                MaxTrajectory = 2500f,
                FieldTime = 600, // 0 is disabled, a value causes the projectile to come to rest, spawn a field and remain for a time (Measured in game ticks, 60 = 1 second)
                GravityMultiplier = 0f, // Gravity multiplier, influences the trajectory of the projectile, value greater than 0 to enable.
                SpeedVariance = Random(start: 0, end: 0), // subtracts value from DesiredSpeed
                RangeVariance = Random(start: 0, end: 0), // subtracts value from MaxTrajectory
                MaxTrajectoryTime = 5, // How long the weapon must fire before it reaches MaxTrajectory.
                Smarts = new SmartsDef
                {
                    Inaccuracy = 0f, // 0 is perfect, hit accuracy will be a random num of meters between 0 and this value.
                    Aggressiveness = 1f, // controls how responsive tracking is.
                    MaxLateralThrust = 0.5, // controls how sharp the trajectile may turn
                    TrackingDelay = 1, // Measured in Shape diameter units traveled.
                    MaxChaseTime = 1800, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    OverideTarget = true, // when set to true ammo picks its own target, does not use hardpoint's.
                    MaxTargets = 0,
                },
                Mines = new MinesDef
                {
                    DetectRadius = 200,
                    DeCloakRadius = 100,
                    FieldTime = 1800,
                    Cloak = false,
                    Persist = false,
                },
            },
            AmmoGraphics = new GraphicDef
            {
                ModelName = "",
                VisualProbability = 1f,
                ShieldHitDraw = true,
                Particles = new AmmoParticleDef
                {
                    Ammo = new ParticleDef
                    {
                        Name = "", //ShipWelderArc
                        ShrinkByDistance = false,
                        Color = Color(red: 128, green: 0, blue: 0, alpha: 32),
                        Offset = Vector(x: 0, y: -1, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 5000,
                            MaxDuration = 1,
                            Scale = 1,
                        },
                    },
                    Hit = new ParticleDef
                    {
                        Name = "LaserHitParticlesGimbal",//LaserHitParticlesGimbal
                        ApplyToShield = true,
                        ShrinkByDistance = true,
                        Color = Color(red: 10, green: 2, blue: 1, alpha: 0.8f),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = true,
                            Restart = false,
                            MaxDistance = 500,
                            MaxDuration = 0,
                            Scale = 1,
                            HitPlayChance = 1,
                        },
                    },
                },
                Lines = new LineDef
                {
                    TracerMaterial = "WeaponLaser", // WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                    ColorVariance = Random(start: 0.85f, end: 1f), // multiply the color by random values within range.
                    WidthVariance = Random(start: -.05f, end: 0f), // adds random value to default width (negatives shrinks width)

                   Tracer = new TracerBaseDef
                    {
                        Enable = true,
                        Length = 1f,
                        Width = .25f,
                        Color = Color(red: 10, green: 1, blue: 0, alpha: .9f),
                        VisualFadeStart = 100, // Number of ticks the weapon has been firing before projectiles begin to fade their color
                        VisualFadeEnd = 120, // How many ticks after fade began before it will be invisible.
                        Textures = new[] {// WeaponLaser, ProjectileTrailLine, WarpBubble, etc..
                            "WeaponLaser",
                        },
                        TextureMode = Normal, // Normal, Cycle, Chaos, Wave
                        Segmentation = new SegmentDef
                        {
                            Enable = true, // If true Tracer TextureMode is ignored
                            Textures = new[] {
                                "WeaponLaser",
                            },
                            SegmentLength = 20f, // Uses the values below.
                            SegmentGap = 15f, // Uses Tracer textures and values
                            Speed = 40f, // meters per second
                            Color = Color(red: 20, green: 2, blue: 0, alpha: .8f),
                            WidthMultiplier = .9f,
                            Reverse = false,
                            UseLineVariance = true,
                            WidthVariance = Random(start: -.05f, end: 0f),
                            ColorVariance = Random(start: 0.6f, end: 1f)
                        }
                    },









                    Trail = new TrailDef
                    {
                        Enable = false,
                        Material = "WeaponLaser",
                        DecayTime = 15,
                        Color = Color(red: 5, green: 1, blue: 0, alpha: 1),
                        Back = false,
                        CustomWidth = 0.25f,
                        UseWidthVariance = true,
                        UseColorFade = true,
                    },
                    OffsetEffect = new OffsetEffectDef
                    {
                        MaxOffset = 0,// 0 offset value disables this effect
                        MinLength = 1,
                        MaxLength = 1,
                    },
                },
            },
            AmmoAudio = new AmmoAudioDef
            {
                TravelSound = "",
                HitSound = "",
                HitPlayChance = 0.5f,
                HitPlayShield = true,
            }, // Don't edit below this line
        };





    }
}
