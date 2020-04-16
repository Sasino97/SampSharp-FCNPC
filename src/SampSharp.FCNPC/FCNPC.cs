/*
 * SampSharp.FCNPC - An FCNPC Wrapper For SampSharp
 * Copyright (c) 2020 Sasinosoft Games
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using SampSharp.FCNPCs.Definitions;
using SampSharp.FCNPCs.Events;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.Pools;
using SampSharp.GameMode.World;
using System;

namespace SampSharp.FCNPCs
{
    public partial class FCNPC : IdentifiedPool<FCNPC>, IWorldObject, IEquatable<FCNPC>, IComparable<FCNPC>
    {
        /* Constants */
        public const int IncludeVersion = 180;
        public const int MaxNodes = 64;
        public const int InvalidMovePathId = -1;
        public const int InvalidRecordId = -1;

        /* Static Properties */
        /// <summary>
        /// Gets the plugin version.
        /// </summary>
        public static string Version
        {
            get
            {
                Internal.GetPluginVersion(out string val, 8);
                return val;
            }
        }

        /// <summary>
        /// Gets or sets the FCNPC update rate.
        /// </summary>
        public static int UpdateRate
        {
            get => Internal.GetUpdateRate();
            set => Internal.SetUpdateRate(value);
        }

        /// <summary>
        /// Gets or sets the FCNPC tick rate.
        /// </summary>
        public static int TickRate
        {
            get => Internal.GetTickRate();
            set => Internal.SetTickRate(value);
        }

        /* Instance Properties */
        /// <summary>
        /// Gets an instance of BasePlayer representing 
        /// this FCNPC in the player layer.
        /// </summary>
        public BasePlayer Player
        {
            get
            {
                AssertNotDisposed();
                return BasePlayer.Find(Id);
            }
        }

        /// <summary>
        /// Gets or sets the name of this FCNPC.
        /// </summary>
        public string Name
        {
            get
            {
                AssertNotDisposed();
                return BasePlayer.Find(Id)?.Name;
            }
            set
            {
                AssertNotDisposed();
                BasePlayer.Find(Id).Name = value;
            }
        }

        /// <summary>
        /// Returns whether the FCNPC is spawned.
        /// </summary>
        public bool IsSpawned
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsSpawned(Id);
            }
        }

        /// <summary>
        /// Returns whether the FCNPC is dead.
        /// </summary>
        public bool IsDead
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsDead(Id);
            }
        }

        /// <summary>
        /// Returns whether the FCNPC is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsValid(Id);
            }
        }

        /// <summary>
        /// Returns whether the FCNPC is streamed in for any other player.
        /// </summary>
        public bool IsStreamedInForAnyone
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsStreamedInForAnyone(Id);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's position.
        /// </summary>
        public Vector3 Position
        {
            get
            {
                AssertNotDisposed();
                Internal.GetPosition(Id, out float x, out float y, out float z);
                return new Vector3(x, y, z);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetPosition(Id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's facing angle.
        /// </summary>
        public float Angle
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetAngle(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetAngle(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's rotation quaternion.
        /// </summary>
        public Quaternion Quaternion
        {
            get
            {
                AssertNotDisposed();
                Internal.GetQuaternion(Id, out float w, out float x, out float y, out float z);
                return new Quaternion(x, y, z, w);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetQuaternion(Id, value.W, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's velocity vector.
        /// </summary>
        public Vector3 Velocity
        {
            get
            {
                AssertNotDisposed();
                Internal.GetVelocity(Id, out float x, out float y, out float z);
                return new Vector3(x, y, z);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetVelocity(Id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's speed.
        /// </summary>
        public float Speed
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetSpeed(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetSpeed(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's interior.
        /// </summary>
        public int Interior
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetInterior(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetInterior(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's virtual world.
        /// </summary>
        public int VirtualWorld
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetVirtualWorld(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetVirtualWorld(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's health.
        /// </summary>
        public float Health
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetHealth(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetHealth(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's body armor.
        /// </summary>
        public float Armour
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetArmour(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetArmour(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's invulnerability.
        /// </summary>
        public bool IsInvulnerable
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsInvulnerable(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetInvulnerable(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's skin.
        /// </summary>
        public int Skin
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetSkin(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetSkin(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's holding weapon.
        /// </summary>
        public Weapon Weapon
        {
            get
            {
                AssertNotDisposed();
                return (Weapon)Internal.GetWeapon(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetWeapon(Id, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's ammo.
        /// </summary>
        public int Ammo
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetAmmo(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetAmmo(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's ammo in clip.
        /// </summary>
        public int AmmoInClip
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetAmmoInClip(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetAmmoInClip(Id, value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's weapon state.
        /// </summary>
        public WeaponState WeaponState
        {
            get
            {
                AssertNotDisposed();
                return (WeaponState)Internal.GetWeaponState(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetWeaponState(Id, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's special action.
        /// </summary>
        public SpecialAction SpecialAction
        {
            get
            {
                AssertNotDisposed();
                return (SpecialAction)Internal.GetSpecialAction(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetSpecialAction(Id, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets this FCNPC's fight style.
        /// </summary>
        public FightStyle FightStyle
        {
            get
            {
                AssertNotDisposed();
                return (FightStyle)Internal.GetFightingStyle(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetFightingStyle(Id, (int)value);
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this FCNPC is moving.
        /// </summary>
        public bool IsMoving
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsMoving(Id);
            }
        }

        /// <summary>
        /// Gets this FCNPC's destination point.
        /// </summary>
        public Vector3 DestinationPoint
        {
            get
            {
                AssertNotDisposed();
                Internal.GetDestinationPoint(Id, out float x, out float y, out float z);
                return new Vector3(x, y, z);
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this FCNPC is attacking.
        /// </summary>
        public bool IsAttacking
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsAttacking(Id);
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this FCNPC is aiming.
        /// </summary>
        public bool IsAiming
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsAiming(Id);
            }
        }

        /// <summary>
        /// Gets the player this FCNPC is aiming at.
        /// </summary>
        public BasePlayer AimingPlayer
        {
            get
            {
                AssertNotDisposed();
                return BasePlayer.Find(Internal.GetAimingPlayer(Id));
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this FCNPC is shooting.
        /// </summary>
        public bool IsShooting
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsShooting(Id);
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this FCNPC is reloading.
        /// </summary>
        public bool IsReloading
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsReloading(Id);
            }
        }

        /// <summary>
        /// Gets this FCNPC's current vehicle.
        /// </summary>
        public BaseVehicle Vehicle
        {
            get
            {
                AssertNotDisposed();
                return BaseVehicle.Find(Internal.GetVehicleID(Id));
            }
        }

        /// <summary>
        /// Gets this FCNPC's current vehicle.
        /// </summary>
        public int VehicleSeat
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetVehicleSeat(Id);
            }
        }

        /// <summary>
        /// Gets this FCNPC's current vehicle's siren state.
        /// </summary>
        public bool VehicleSiren
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsVehicleSiren(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetVehicleSiren(Id, value);
            }
        }

        /// <summary>
        /// Gets this FCNPC's current vehicle's health.
        /// </summary>
        public float VehicleHealth
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetVehicleHealth(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetVehicleHealth(Id, value);
            }
        }

        /// <summary>
        /// Gets this FCNPC's current vehicle's hydra thrusters.
        /// </summary>
        public bool VehicleHydraThrusters
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetVehicleHydraThrusters(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetVehicleHydraThrusters(Id, value);
            }
        }

        /// <summary>
        /// Gets this FCNPC's current vehicle's gear state.
        /// </summary>
        public bool VehicleGearState
        {
            get
            {
                AssertNotDisposed();
                return Internal.GetVehicleGearState(Id);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetVehicleGearState(Id, value);
            }
        }

        /// <summary>
        /// Gets this FCNPC's surfing offsets.
        /// </summary>
        public Vector3 SurfingOffsets
        {
            get
            {
                AssertNotDisposed();
                Internal.GetSurfingOffsets(Id, out float x, out float y, out float z);
                return new Vector3(x, y, z);
            }
            set
            {
                AssertNotDisposed();
                Internal.SetSurfingOffsets(Id, value.X, value.Y, value.Z);
            }
        }

        /// <summary>
        /// Gets this FCNPC's surfing offsets.
        /// </summary>
        public BaseVehicle SurfingVehicle
        {
            get
            {
                AssertNotDisposed();
                return BaseVehicle.Find(Internal.GetSurfingVehicle(Id));
            }
            set
            {
                AssertNotDisposed();
                Internal.SetSurfingVehicle(Id, value.Id);
            }
        }

        /// <summary>
        /// Gets this FCNPC's surfing offsets.
        /// </summary>
        public GlobalObject SurfingObject
        {
            get
            {
                AssertNotDisposed();
                return GlobalObject.Find(Internal.GetSurfingObject(Id));
            }
            set
            {
                AssertNotDisposed();
                Internal.SetSurfingObject(Id, value.Id);
            }
        }

        /// <summary>
        /// Gets this FCNPC's surfing offsets.
        /// </summary>
        public PlayerObject SurfingPlayerObject
        {
            get
            {
                AssertNotDisposed();
                return PlayerObject.Find(Player, Internal.GetSurfingPlayerObject(Id));
            }
            set
            {
                AssertNotDisposed();
                Internal.SetSurfingPlayerObject(Id, value.Id);
            }
        }

        /// <summary>
        /// Returns whether the FCNPC is playing the current node.
        /// </summary>
        public bool IsPlayingNode
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsPlayingNode(Id);
            }
        }

        /// <summary>
        /// Returns whether the FCNPC is pausing the current node.
        /// </summary>
        public bool IsPlayingNodePaused
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsPlayingNodePaused(Id);
            }
        }

        /* Events */
        public event EventHandler Created;
        public event EventHandler Destroyed;
        public event EventHandler Spawned;
        public event EventHandler Respawned;
        public event EventHandler<DeathEventArgs> Died;

        //
        public event EventHandler<VehicleEntryEventArgs> VehicleEntryCompleted;
        public event EventHandler VehicleExitCompleted;

        //
        public event EventHandler DestinationReached;
        public event EventHandler PlaybackFinished;

        //
        public event EventHandler<DamageEventArgs> TakeDamage;
        public event EventHandler<DamageEventArgs> GiveDamage;
        public event EventHandler<VehicleTakeDamageEventArgs> VehicleTakeDamage;
        public event EventHandler<WeaponShotEventArgs> WeaponShot;
        public event EventHandler<WeaponStateChangedEventArgs> WeaponStateChanged;

        //
        public event EventHandler<NodePointFinishedEventArgs> NodePointFinished;
        public event EventHandler<NodeChangedEventArgs> NodeChanged;
        public event EventHandler NodeFinished;

        //
        public event EventHandler<PlayerEventArgs> StreamedIn;
        public event EventHandler<PlayerEventArgs> StreamedOut;

        //
        public event EventHandler<PlayerUpdateEventArgs> Update;

        //
        public event EventHandler<MovePathFinishedEventArgs> MovePathFinished;
        public event EventHandler<MovePathPointFinishedEventArgs> MovePathPointFinished;

        //
        public event EventHandler<HeightPositionChangedEventArgs> HeightPositionChanged;

        /* Constructor */
        public FCNPC() { }

        /* Public Static Methods */
        /// <summary>
        /// Creates and connects to the server a new FCNPC with the specified nickname.
        /// </summary>
        /// <param name="name">The nickname</param>
        /// <returns></returns>
        public static FCNPC Create(string name)
        {
            return Create(Internal.Create(name));
        }

        /* Public Instance Methods */
        /// <summary>
        /// Spawns the FCNPC.
        /// </summary>
        public bool Spawn(int skinid, Vector3 position)
        {
            AssertNotDisposed();
            return Internal.Spawn(Id, skinid, position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Respawns the FCNPC.
        /// </summary>
        public bool Respawn()
        {
            AssertNotDisposed();
            return Internal.Respawn(Id);
        }

        /// <summary>
        /// Kills the FCNPC.
        /// </summary>
        public bool Kill()
        {
            AssertNotDisposed();
            return Internal.Kill(Id);
        }

        /// <summary>
        /// Returns whether the FCNPC is streamed in for the specified player.
        /// </summary>
        public bool IsStreamedIn(BasePlayer player)
        {
            AssertNotDisposed();
            return Internal.IsStreamedIn(Id, player.Id);
        }

        /// <summary>
        /// Sets this FCNPC's facing angle to the specified coordinates.
        /// </summary>
        public bool SetAngleToPos(float x, float y)
        {
            AssertNotDisposed();
            return Internal.SetAngleToPos(Id, x, y);
        }

        /// <summary>
        /// Sets this FCNPC's facing angle to the specified player.
        /// </summary>
        public bool SetAngleToPlayer(BasePlayer player)
        {
            AssertNotDisposed();
            return Internal.SetAngleToPlayer(Id, player.Id);
        }

        /// <summary>
        /// Gets this FCNPC's skill level of the specified weapon.
        /// </summary>
        public int GetWeaponSkillLevel(WeaponSkill skill)
        {
            AssertNotDisposed();
            return Internal.GetWeaponSkillLevel(Id, (int)skill);
        }

        /// <summary>
        /// Sets this FCNPC's skill level of the specified weapon.
        /// </summary>
        public bool SetWeaponSkillLevel(WeaponSkill skill, int level)
        {
            AssertNotDisposed();
            return Internal.SetWeaponSkillLevel(Id, (int)skill, level);
        }

        /// <summary>
        /// Gets this FCNPC's reload time of the specified weapon.
        /// </summary>
        public int GetWeaponReloadTime(Weapon weapon)
        {
            AssertNotDisposed();
            return Internal.GetWeaponReloadTime(Id, (int)weapon);
        }

        /// <summary>
        /// Sets this FCNPC's reload time of the specified weapon.
        /// </summary>
        public bool SetWeaponReloadTime(Weapon weapon, int time)
        {
            AssertNotDisposed();
            return Internal.SetWeaponReloadTime(Id, (int)weapon, time);
        }

        /// <summary>
        /// Gets this FCNPC's actual reload time of the specified weapon.
        /// </summary>
        public int GetWeaponActualReloadTime(Weapon weapon)
        {
            AssertNotDisposed();
            return Internal.GetWeaponActualReloadTime(Id, (int)weapon);
        }

        /// <summary>
        /// Gets this FCNPC's shoot time of the specified weapon.
        /// </summary>
        public int GetWeaponShootTime(Weapon weapon)
        {
            AssertNotDisposed();
            return Internal.GetWeaponShootTime(Id, (int)weapon);
        }

        /// <summary>
        /// Sets this FCNPC's shoot time of the specified weapon.
        /// </summary>
        public bool SetWeaponShootTime(Weapon weapon, int time)
        {
            AssertNotDisposed();
            return Internal.SetWeaponShootTime(Id, (int)weapon, time);
        }

        /// <summary>
        /// Gets this FCNPC's clip size of the specified weapon.
        /// </summary>
        public int GetWeaponClipSize(Weapon weapon)
        {
            AssertNotDisposed();
            return Internal.GetWeaponClipSize(Id, (int)weapon);
        }

        /// <summary>
        /// Sets this FCNPC's clip size of the specified weapon.
        /// </summary>
        public bool SetWeaponClipSize(Weapon weapon, int size)
        {
            AssertNotDisposed();
            return Internal.SetWeaponClipSize(Id, (int)weapon, size);
        }

        /// <summary>
        /// Gets this FCNPC's accuracy of the specified weapon.
        /// </summary>
        public float GetWeaponAccuracy(Weapon weapon)
        {
            AssertNotDisposed();
            return Internal.GetWeaponAccuracy(Id, (int)weapon);
        }

        /// <summary>
        /// Sets this FCNPC's accuracy of the specified weapon.
        /// </summary>
        public bool SetWeaponAccuracy(Weapon weapon, float accuracy)
        {
            AssertNotDisposed();
            return Internal.SetWeaponAccuracy(Id, (int)weapon, accuracy);
        }

        /// <summary>
        /// Gets this FCNPC's weapon info.
        /// </summary>
        public bool GetWeaponInfo(Weapon weapon, out int reload_time, out int shoot_time, out int clip_size, out float accuracy)
        {
            AssertNotDisposed();
            return Internal.GetWeaponInfo(Id, (int)weapon, out reload_time, out shoot_time, out clip_size, out accuracy);
        }

        /// <summary>
        /// Sets this FCNPC's weapon info.
        /// </summary>
        public bool SetWeaponInfo(Weapon weapon, int reload_time = -1, int shoot_time = -1, int clip_size = -1, float accuracy = 1f)
        {
            AssertNotDisposed();
            return Internal.SetWeaponInfo(Id, (int)weapon, reload_time, shoot_time, clip_size, accuracy);
        }

        /// <summary>
        /// Gets this FCNPC's keys state.
        /// </summary>
        public bool GetKeys(out int upDownAnalog, out int leftRightAnalog, out Keys keys)
        {
            AssertNotDisposed();
            var b = Internal.GetKeys(Id, out upDownAnalog, out leftRightAnalog, out int k);
            keys = (Keys)k;
            return b;
        }

        /// <summary>
        /// Sets this FCNPC's clip size of the specified weapon.
        /// </summary>
        public bool SetKeys(int upDownAnalog, int leftRightAnalog, Keys keys)
        {
            AssertNotDisposed();
            return Internal.SetKeys(Id, upDownAnalog, leftRightAnalog, (int)keys);
        }

        /// <summary>
        /// Gets this FCNPC's animation.
        /// </summary>
        public bool GetAnimation(out int animationId, out float fDelta, out bool loop, out bool lockx, out bool locky, out bool freeze, out int time)
        {
            AssertNotDisposed();
            return Internal.GetAnimation(Id, out animationId, out fDelta, out loop, out lockx, out locky, out freeze, out time);
        }

        /// <summary>
        /// Sets this FCNPC's animation.
        /// </summary>
        public bool SetAnimation(int animationId, float fDelta = 4.1f, bool loop = false, bool lockx = true, bool locky = true, bool freeze = false, int time = 1)
        {
            AssertNotDisposed();
            return Internal.SetAnimation(Id, animationId, fDelta, loop, lockx, locky, freeze, time);
        }

        /// <summary>
        /// Sets this FCNPC's animatiom by name.
        /// </summary>
        public bool SetAnimation(string animationName, float fDelta = 4.1f, bool loop = false, bool lockx = true, bool locky = true, bool freeze = false, int time = 1)
        {
            AssertNotDisposed();
            return Internal.SetAnimationByName(Id, animationName, fDelta, loop, lockx, locky, freeze, time);
        }

        /// <summary>
        /// Reset this FCNPC's animation.
        /// </summary>
        public bool ResetAnimation()
        {
            AssertNotDisposed();
            return Internal.ResetAnimation(Id);
        }

        /// <summary>
        /// Applies an animation to this FCNPC.
        /// </summary>
        public bool ApplyAnimation(string animationLib, string animationName, float fDelta = 4.1f, bool loop = false, bool lockx = true, bool locky = true, bool freeze = false, int time = 1)
        {
            AssertNotDisposed();
            return Internal.ApplyAnimation(
                Id, 
                animationLib, 
                animationName, 
                fDelta, 
                loop, 
                lockx, 
                locky, 
                freeze, 
                time
            );
        }

        /// <summary>
        /// Clears this FCNPC's animations.
        /// </summary>
        public bool ClearAnimations()
        {
            AssertNotDisposed();
            return Internal.ClearAnimations(Id);
        }

        /// <summary>
        /// Toggles this FCNPC's reloading.
        /// </summary>
        public bool ToggleReloading(bool toggle)
        {
            AssertNotDisposed();
            return Internal.ToggleReloading(Id, toggle);
        }

        /// <summary>
        /// Toggles this FCNPC's infinite ammo.
        /// </summary>
        public bool ToggleInfiniteAmmo(bool toggle)
        {
            AssertNotDisposed();
            return Internal.ToggleInfiniteAmmo(Id, toggle);
        }

        /// <summary>
        /// Makes this FCNPC go to a certain position.
        /// </summary>
        public bool GoTo(Vector3 position, MoveType type = MoveType.Auto, float speed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setangle = true, float dist_offset = 0f, int stopdelay = 250)
        {
            AssertNotDisposed();
            return Internal.GoTo(
                Id, 
                position.X, 
                position.Y, 
                position.Z, 
                (int)type, 
                speed, 
                useMapAndreas, 
                radius, 
                setangle, 
                dist_offset, 
                stopdelay
            );
        }

        /// <summary>
        /// Makes this FCNPC go to a certain player.
        /// </summary>
        public bool GoTo(BasePlayer player, MoveType type = MoveType.Auto, float speed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setangle = true, float dist_offset = 0f, int stopdelay = 250)
        {
            AssertNotDisposed();
            return Internal.GoToPlayer(
                Id, 
                player.Id, 
                (int)type, 
                speed, 
                useMapAndreas, 
                radius, 
                setangle, 
                dist_offset, 
                stopdelay
            );
        }

        /// <summary>
        /// Makes this FCNPC stop moving.
        /// </summary>
        public bool Stop()
        {
            AssertNotDisposed();
            return Internal.Stop(Id);
        }

        /// <summary>
        /// Returns whether this FCNPC is moving towards a certain player.
        /// </summary>
        public bool IsMovingAtPlayer(BasePlayer player)
        {
            AssertNotDisposed();
            return Internal.IsMovingAtPlayer(Id, player.Id);
        }

        /// <summary>
        /// Makes the FCNPC aim at a certain position.
        /// </summary>
        public bool AimAt(Vector3 position, bool shoot = false, int shootDelay = -1, bool setAngle = true, Vector3 offsetFrom = new Vector3())
        {
            AssertNotDisposed();
            return Internal.AimAt(
                Id,
                position.X,
                position.Y,
                position.Z,
                shoot,
                shootDelay,
                setAngle,
                offsetFrom.X,
                offsetFrom.Y,
                offsetFrom.Z
            );
        }

        /// <summary>
        /// Makes the FCNPC aim at a certain player.
        /// </summary>
        public bool AimAt(BasePlayer player, bool shoot = false, int shootDelay = -1, bool setAngle = true, Vector3 offset = new Vector3(), Vector3 offsetFrom = new Vector3())
        {
            AssertNotDisposed();
            return Internal.AimAtPlayer(
                Id,
                player.Id,
                shoot,
                shootDelay,
                setAngle,
                offset.X,
                offset.Y,
                offset.Z,
                offsetFrom.X,
                offsetFrom.Y,
                offsetFrom.Z
            );
        }

        /// <summary>
        /// Makes this FCNPC stop aiming.
        /// </summary>
        public bool StopAim()
        {
            AssertNotDisposed();
            return Internal.StopAim(Id);
        }

        /// <summary>
        /// Makes this FCNPC start a melee attack.
        /// </summary>
        public bool MeleeAttack(int delay = -1, bool useFightStyle = false)
        {
            AssertNotDisposed();
            return Internal.MeleeAttack(Id, delay, useFightStyle);
        }

        /// <summary>
        /// Makes this FCNPC stop the melee attack.
        /// </summary>
        public bool StopAttack()
        {
            AssertNotDisposed();
            return Internal.StopAttack(Id);
        }

        /// <summary>
        /// Returns whether this FCNPC is aiming at a certain player.
        /// </summary>
        public bool IsAimingAtPlayer(BasePlayer player)
        {
            AssertNotDisposed();
            return Internal.IsAimingAtPlayer(Id, player.Id);
        }

        /// <summary>
        /// Triggers a weapon shot.
        /// </summary>
        public bool TriggerWeaponShot(Weapon weapon, BulletHitType hitType, int hitId, Vector3 position, bool isHit = true, Vector3 offsetFrom = new Vector3())
        {
            AssertNotDisposed();
            return Internal.TriggerWeaponShot(
                Id,
                (int)weapon,
                (int)hitType,
                hitId,
                position.X,
                position.Y,
                position.Z,
                isHit,
                offsetFrom.X,
                offsetFrom.Y,
                offsetFrom.Z
            );
        }

        /// <summary>
        /// Makes this FCNPC start entering a certain vehicle.
        /// </summary>
        public bool EnterVehicle(BaseVehicle vehicle, int seatId = 0, MoveType type = MoveType.Walk)
        {
            AssertNotDisposed();
            return Internal.EnterVehicle(Id, vehicle.Id, seatId, (int)type);
        }

        /// <summary>
        /// Makes this FCNPC exit its current vehicle.
        /// </summary>
        public bool ExitVehicle()
        {
            AssertNotDisposed();
            return Internal.ExitVehicle(Id);
        }

        /// <summary>
        /// Puts this FCNPC in a certain vehicle.
        /// </summary>
        public bool PutInVehicle(BaseVehicle vehicle, int seatId = 0)
        {
            AssertNotDisposed();
            return Internal.PutInVehicle(Id, vehicle.Id, seatId);
        }

        /// <summary>
        /// Removes this FCNPC from its current vehicle.
        /// </summary>
        public bool RemoveFromVehicle()
        {
            AssertNotDisposed();
            return Internal.RemoveFromVehicle(Id);
        }

        /// <summary>
        /// Makes this FCNPC stop surfing.
        /// </summary>
        public bool StopSurfing()
        {
            AssertNotDisposed();
            return Internal.StopSurfing(Id);
        }

        /// <summary>
        /// Starts playing a playback given a file name.
        /// </summary>
        public bool StartPlayingPlayback(string file, bool autoUnload = false)
        {
            AssertNotDisposed();
            return Internal.StartPlayingPlayback(Id, file, -1, autoUnload);
        }

        /// <summary>
        /// Starts playing the specified playback.
        /// </summary>
        public bool StartPlayingPlayback(Playback playback, bool autoUnload = false)
        {
            AssertNotDisposed();
            return Internal.StartPlayingPlayback(Id, "", playback.Id, autoUnload);
        }

        /// <summary>
        /// Starts playing the current playback.
        /// </summary>
        public bool StopPlayingPlayback()
        {
            AssertNotDisposed();
            return Internal.StopPlayingPlayback(Id);
        }

        /// <summary>
        /// Pauses the current playback.
        /// </summary>
        public bool PausePlayingPlayback()
        {
            AssertNotDisposed();
            return Internal.PausePlayingPlayback(Id);
        }

        /// <summary>
        /// Resumes the current playback.
        /// </summary>
        public bool ResumePlayingPlayback()
        {
            AssertNotDisposed();
            return Internal.ResumePlayingPlayback(Id);
        }

        // not sure about what the following two functions do, as they are undocumented
        public string GetPlayingPlaybackPath()
        {
            AssertNotDisposed();
            Internal.GetPlayingPlaybackPath(Id, out string path, 128);
            return path;
        }

        public bool SetPlayingPlaybackPath(string path)
        {
            AssertNotDisposed();
            return Internal.SetPlayingPlaybackPath(Id, path);
        }

        /// <summary>
        /// Plays the specified node.
        /// </summary>
        public bool PlayNode(Node node, MoveType moveType = MoveType.Auto, float speed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setAngle = true)
        {
            AssertNotDisposed();
            return Internal.PlayNode(Id, node.Id, (int)moveType, speed, useMapAndreas, radius, setAngle);
        }

        /// <summary>
        /// Stops playing the current node.
        /// </summary>
        public bool StopPlayingNode()
        {
            AssertNotDisposed();
            return Internal.StopPlayingNode(Id);
        }

        /// <summary>
        /// Pauses playing the current node.
        /// </summary>
        public bool PausePlayingNode()
        {
            AssertNotDisposed();
            return Internal.PausePlayingNode(Id);
        }

        /// <summary>
        /// Resumes playing the current node.
        /// </summary>
        public bool ResumePlayingNode()
        {
            AssertNotDisposed();
            return Internal.ResumePlayingNode(Id);
        }

        /// <summary>
        /// Resumes playing the current node.
        /// </summary>
        public bool GoByMovePath(MovePath path, MoveType moveType = MoveType.Auto, float moveSpeed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setAngle = true, float distOffset = 0f)
        {
            AssertNotDisposed();
            return Internal.GoByMovePath(
                Id,
                path.Id,
                (int)moveType,
                moveSpeed,
                useMapAndreas,
                radius,
                setAngle, 
                distOffset
            );
        }

        /// <summary>
        /// Returns whether this instance points to the same FCNPC as the specified instance.
        /// </summary>
        public bool Equals(FCNPC other)
        {
            return this.Id == other.Id;
        }

        public int CompareTo(FCNPC other)
        {
            return this.Id - other.Id;
        }

        //
        public override string ToString()
        {
            return $"{Name} ({Id})";
        }

        /// <summary>
        /// Called when the instance was disposed.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (IsValid)
                Internal.Destroy(Id);

            base.Dispose(disposing);
        }

        /* Static Methods */
        public static bool InitMapAndreas(int address) =>
            Internal.InitMapAndreas(address);

        public static bool ToggleCrashLogCreation(bool toggle) =>
            Internal.ToggleCrashLogCreation(toggle);

        public static bool GetCrashLogCreation() =>
            Internal.GetCrashLogCreation();

        public static bool GetWeaponDefaultInfo(Weapon weapon, out int reload_time, out int shoot_time, out int clip_size, out float accuracy) =>
            Internal.GetWeaponDefaultInfo((int)weapon, out reload_time, out shoot_time, out clip_size, out accuracy);

        public static bool SetWeaponDefaultInfo(Weapon weapon, int reload_time = -1, int shoot_time = -1, int clip_size = -1, float accuracy = 1f) =>
            Internal.SetWeaponDefaultInfo((int)weapon, reload_time, shoot_time, clip_size, accuracy);
    }
}
