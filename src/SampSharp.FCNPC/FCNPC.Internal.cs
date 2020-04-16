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
using SampSharp.Core.Natives.NativeObjects;
using System;
using SampSharp.FCNPCs.Events;
using SampSharp.GameMode.World;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;

namespace SampSharp.FCNPCs
{
    public partial class FCNPC
    {
        private static readonly FCNPCInternal Internal;

        static FCNPC()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<FCNPCInternal>();
        }

        internal static void OnCreate(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.Created?.Invoke(fcnpc, EventArgs.Empty);
        }

        internal static void OnDestroy(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.Destroyed?.Invoke(fcnpc, EventArgs.Empty);
        }

        internal static void OnSpawn(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.Spawned?.Invoke(fcnpc, EventArgs.Empty);
        }

        internal static void OnRespawn(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.Respawned?.Invoke(fcnpc, EventArgs.Empty);
        }

        internal static void OnDeath(int npcid, int killerid, int weaponid)
        {
            var fcnpc = Find(npcid);
            var args = new DeathEventArgs(BasePlayer.Find(killerid), (Weapon)weaponid);
            fcnpc?.Died?.Invoke(fcnpc, args);
        }

        internal static void OnVehicleEntryComplete(int npcid, int vehicleid, int seatid)
        {
            var fcnpc = Find(npcid);
            var args = new VehicleEntryEventArgs()
            {
                Vehicle = BaseVehicle.Find(vehicleid),
                Seat = seatid
            };
            fcnpc?.VehicleEntryCompleted?.Invoke(fcnpc, args);
        }

        internal static void OnVehicleExitComplete(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.VehicleExitCompleted?.Invoke(fcnpc, EventArgs.Empty);
        }

        internal static void OnReachDestination(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.DestinationReached?.Invoke(fcnpc, EventArgs.Empty);
        }

        internal static void OnFinishPlayback(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.PlaybackFinished?.Invoke(fcnpc, EventArgs.Empty);
        }

        internal static void OnTakeDamage(int npcid, int damagerid, int weaponid, int bodyPart, float healthLoss)
        {
            var fcnpc = Find(npcid);
            var args = new DamageEventArgs(BasePlayer.Find(damagerid), healthLoss, (Weapon)weaponid, (BodyPart)bodyPart);
            fcnpc?.TakeDamage?.Invoke(fcnpc, args);
        }

        internal static void OnGiveDamage(int npcid, int damagedid, int weaponid, int bodyPart, float healthLoss)
        {
            var fcnpc = Find(npcid);
            var args = new DamageEventArgs(BasePlayer.Find(damagedid), healthLoss, (Weapon)weaponid, (BodyPart)bodyPart);
            fcnpc?.GiveDamage?.Invoke(fcnpc, args);
        }

        internal static void OnVehicleTakeDamage(int npcid, int damagerid, int vehicleid, int weaponid, float x, float y, float z)
        {
            var fcnpc = Find(npcid);
            var args = new VehicleTakeDamageEventArgs()
            {
                Damager = BasePlayer.Find(damagerid),
                Vehicle = BaseVehicle.Find(vehicleid),
                Weapon = (Weapon)weaponid,
                Position = new Vector3(x, y, z)
            };
            fcnpc?.VehicleTakeDamage?.Invoke(fcnpc, args);
        }

        internal static bool OnWeaponShot(int npcid, int weaponid, int hittype, int hitid, float x, float y, float z)
        {
            var fcnpc = Find(npcid);
            var args = new WeaponShotEventArgs((Weapon)weaponid, (BulletHitType)hittype, hitid, new Vector3(x, y, z));
            fcnpc?.WeaponShot?.Invoke(fcnpc, args);
            return !args.PreventDamage;
        }

        internal static void OnWeaponStateChange(int npcid, int weapon_state)
        {
            var fcnpc = Find(npcid);
            var args = new WeaponStateChangedEventArgs()
            {
                WeaponState = (WeaponState)weapon_state
            };
            fcnpc?.WeaponStateChanged?.Invoke(fcnpc, args);
        }

        internal static void OnFinishNodePoint(int npcid, int point)
        {
            var fcnpc = Find(npcid);
            var args = new NodePointFinishedEventArgs()
            {
                Point = point
            };
            fcnpc?.NodePointFinished?.Invoke(fcnpc, args);
        }

        internal static void OnChangeNode(int npcid, int nodeid)
        {
            var fcnpc = Find(npcid);
            var args = new NodeChangedEventArgs()
            {
                Node = new Node(nodeid)
            };
            fcnpc?.NodeChanged?.Invoke(fcnpc, args);
            
        }

        internal static void OnFinishNode(int npcid)
        {
            var fcnpc = Find(npcid);
            fcnpc?.NodeFinished?.Invoke(fcnpc, EventArgs.Empty);
            
        }

        internal static void OnStreamIn(int npcid, int forplayerid)
        {
            var fcnpc = Find(npcid);
            var args = new PlayerEventArgs(BasePlayer.Find(forplayerid));
            fcnpc?.StreamedIn?.Invoke(fcnpc, args);
        }

        internal static void OnStreamOut(int npcid, int forplayerid)
        {
            var fcnpc = Find(npcid);
            var args = new PlayerEventArgs(BasePlayer.Find(forplayerid));
            fcnpc?.StreamedOut?.Invoke(fcnpc, args);
        }

        internal static bool OnUpdate(int npcid)
        {
            var fcnpc = Find(npcid);
            var e = new PlayerUpdateEventArgs();
            fcnpc?.Update?.Invoke(fcnpc, e);
            return !e.PreventPropagation;
        }

        internal static void OnFinishMovePath(int npcid, int pathid)
        {
            var fcnpc = Find(npcid);
            var args = new MovePathFinishedEventArgs()
            {
                MovePath = MovePath.FindOrCreate(pathid)
            };
            fcnpc?.MovePathFinished?.Invoke(fcnpc, args);
        }

        internal static void OnFinishMovePathPoint(int npcid, int pathid, int pointid)
        {
            var fcnpc = Find(npcid);
            var args = new MovePathPointFinishedEventArgs()
            {
                MovePath = MovePath.FindOrCreate(pathid),
                Point = pointid
            };
            fcnpc?.MovePathPointFinished?.Invoke(fcnpc, args);
        }

        // disabled by default, see FCNPC_SetMinHeightPosCall
        internal static void OnChangeHeightPos(int npcid, float new_z, float old_z)
        {
            var fcnpc = Find(npcid);
            var args = new HeightPositionChangedEventArgs()
            {
                NewHeight = new_z,
                OldHeight = old_z
            };
            fcnpc?.HeightPositionChanged?.Invoke(fcnpc, args);
        }

        public class FCNPCInternal
        {
            /* Plugin Static Functions */
            [NativeMethod(Function = "FCNPC_GetPluginVersion")]
            public virtual void GetPluginVersion(out string version, int size) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetUpdateRate")]
            public virtual bool SetUpdateRate(int rate) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetUpdateRate")]
            public virtual int GetUpdateRate() =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetTickRate")]
            public virtual bool SetTickRate(int rate) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetTickRate")]
            public virtual int GetTickRate() =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_InitMapAndreas")]
            public virtual bool InitMapAndreas(int address) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ToggleCrashLogCreation")]
            public virtual bool ToggleCrashLogCreation(bool toggle = true) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetCrashLogCreation")]
            public virtual bool GetCrashLogCreation() =>
                throw new NativeNotImplementedException();

            /* FCNPC General */
            [NativeMethod(Function = "FCNPC_Create")]
            public virtual int Create(string name) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_Destroy")]
            public virtual bool Destroy(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_Spawn")]
            public virtual bool Spawn(int npcid, int skinid, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_Respawn")]
            public virtual bool Respawn(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsSpawned")]
            public virtual bool IsSpawned(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_Kill")]
            public virtual bool Kill(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsDead")]
            public virtual bool IsDead(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsValid")]
            public virtual bool IsValid(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsStreamedIn")]
            public virtual bool IsStreamedIn(int npcid, int forplayerid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsStreamedInForAnyone")]
            public virtual bool IsStreamedInForAnyone(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetValidArray")]
            public virtual bool GetValidArray(out int[] npcs, int size) =>
                throw new NativeNotImplementedException();

            /* FCNPC World-Positioning */
            [NativeMethod(Function = "FCNPC_SetPosition")]
            public virtual bool SetPosition(int npcid, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GivePosition")]
            public virtual bool GivePosition(int npcid, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetPosition")]
            public virtual bool GetPosition(int npcid, out float x, out float y, out float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetAngle")]
            public virtual bool SetAngle(int npcid, float angle) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveAngle")]
            public virtual bool GiveAngle(int npcid, float angle) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetAngleToPos")]
            public virtual bool SetAngleToPos(int npcid, float x, float y) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetAngleToPlayer")]
            public virtual bool SetAngleToPlayer(int npcid, int playerid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetAngle")]
            public virtual float GetAngle(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetQuaternion")]
            public virtual bool SetQuaternion(int npcid, float w, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveQuaternion")]
            public virtual bool GiveQuaternion(int npcid, float w, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetQuaternion")]
            public virtual bool GetQuaternion(int npcid, out float w, out float x, out float y, out float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetVelocity")]
            public virtual bool SetVelocity(int npcid, float x, float y, float z, bool update_pos = false) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveVelocity")]
            public virtual bool GiveVelocity(int npcid, float x, float y, float z, bool update_pos = false) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetVelocity")]
            public virtual bool GetVelocity(int npcid, out float x, out float y, out float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetSpeed")]
            public virtual bool SetSpeed(int npcid, float speed) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetSpeed")]
            public virtual float GetSpeed(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetInterior")]
            public virtual bool SetInterior(int npcid, int interiorid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetInterior")]
            public virtual int GetInterior(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetVirtualWorld")]
            public virtual bool SetVirtualWorld(int npcid, int worldid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetVirtualWorld")]
            public virtual int GetVirtualWorld(int npcid) =>
                throw new NativeNotImplementedException();

            /* FCNPC Health */
            [NativeMethod(Function = "FCNPC_SetHealth")]
            public virtual bool SetHealth(int npcid, float health) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveHealth")]
            public virtual float GiveHealth(int npcid, float health) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetHealth")]
            public virtual float GetHealth(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetArmour")]
            public virtual bool SetArmour(int npcid, float armour) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveArmour")]
            public virtual float GiveArmour(int npcid, float armour) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetArmour")]
            public virtual float GetArmour(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetInvulnerable")]
            public virtual bool SetInvulnerable(int npcid, bool invulnerable = true) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsInvulnerable")]
            public virtual bool IsInvulnerable(int npcid) =>
                throw new NativeNotImplementedException();

            /* FCNPC Skins */
            [NativeMethod(Function = "FCNPC_SetSkin")]
            public virtual bool SetSkin(int npcid, int skinid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetSkin")]
            public virtual int GetSkin(int npcid) =>
                throw new NativeNotImplementedException();

            /* FCNPC Weapons */
            [NativeMethod(Function = "FCNPC_SetWeapon")]
            public virtual bool SetWeapon(int npcid, int weaponid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeapon")]
            public virtual int GetWeapon(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetAmmo")]
            public virtual bool SetAmmo(int npcid, int ammo) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveAmmo")]
            public virtual bool GiveAmmo(int npcid, int ammo) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetAmmo")]
            public virtual int GetAmmo(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetAmmoInClip")]
            public virtual bool SetAmmoInClip(int npcid, int ammo) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveAmmoInClip")]
            public virtual bool GiveAmmoInClip(int npcid, int ammo) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetAmmoInClip")]
            public virtual int GetAmmoInClip(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponSkillLevel")]
            public virtual bool SetWeaponSkillLevel(int npcid, int skill, int level) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveWeaponSkillLevel")]
            public virtual bool GiveWeaponSkillLevel(int npcid, int skill, int level) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponSkillLevel")]
            public virtual int GetWeaponSkillLevel(int npcid, int skill) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponState")]
            public virtual bool SetWeaponState(int npcid, int weaponstate) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponState")]
            public virtual int GetWeaponState(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponReloadTime")]
            public virtual bool SetWeaponReloadTime(int npcid, int weaponid, int time) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponReloadTime")]
            public virtual int GetWeaponReloadTime(int npcid, int weaponid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponActualReloadTime")]
            public virtual int GetWeaponActualReloadTime(int npcid, int weaponid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponShootTime")]
            public virtual bool SetWeaponShootTime(int npcid, int weaponid, int time) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponShootTime")]
            public virtual int GetWeaponShootTime(int npcid, int weaponid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponClipSize")]
            public virtual bool SetWeaponClipSize(int npcid, int weaponid, int size) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponClipSize")]
            public virtual int GetWeaponClipSize(int npcid, int weaponid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponActualClipSize")]
            public virtual int GetWeaponActualClipSize(int npcid, int weaponid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponAccuracy")]
            public virtual bool SetWeaponAccuracy(int npcid, int weaponid, float accuracy) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponAccuracy")]
            public virtual float GetWeaponAccuracy(int npcid, int weaponid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponInfo")]
            public virtual bool SetWeaponInfo(int npcid, int weaponid, int reload_time = -1, int shoot_time = -1, int clip_size = -1, float accuracy = 1f) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponInfo")]
            public virtual bool GetWeaponInfo(int npcid, int weaponid, out int reload_time, out int shoot_time, out int clip_size, out float accuracy) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetWeaponDefaultInfo")]
            public virtual bool SetWeaponDefaultInfo(int weaponid, int reload_time = -1, int shoot_time = -1, int clip_size = -1, float accuracy = 1f) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetWeaponDefaultInfo")]
            public virtual bool GetWeaponDefaultInfo(int weaponid, out int reload_time, out int shoot_time, out int clip_size, out float accuracy) =>
                throw new NativeNotImplementedException();

            /* FCNPC Keys */
            [NativeMethod(Function = "FCNPC_SetKeys")]
            public virtual bool SetKeys(int npcid, int ud_analog, int lr_analog, int keys) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetKeys")]
            public virtual bool GetKeys(int npcid, out int ud_analog, out int lr_analog, out int keys) =>
                throw new NativeNotImplementedException();

            /* FCNPC Animations  */
            [NativeMethod(Function = "FCNPC_SetSpecialAction")]
            public virtual bool SetSpecialAction(int npcid, int actionid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetSpecialAction")]
            public virtual int GetSpecialAction(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetAnimation")]
            public virtual bool SetAnimation(int npcid, int animationid, float fDelta = 4.1f, bool loop = false, bool lockx = true, bool locky = true, bool freeze = false, int time = 1) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetAnimationByName")]
            public virtual bool SetAnimationByName(int npcid, string name, float fDelta = 4.1f, bool loop = false, bool lockx = true, bool locky = true, bool freeze = false, int time = 1) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ResetAnimation")]
            public virtual bool ResetAnimation(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetAnimation")]
            public virtual bool GetAnimation(int npcid, out int animationid, out float fDelta, out bool loop, out bool lockx, out bool locky, out bool freeze, out int time) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ApplyAnimation")]
            public virtual bool ApplyAnimation(int npcid, string animlib, string animname, float fDelta = 4.1f, bool loop = false, bool lockx = true, bool locky = true, bool freeze = false, int time = 1) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ClearAnimations")]
            public virtual bool ClearAnimations(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetFightingStyle")]
            public virtual bool SetFightingStyle(int npcid, int style) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetFightingStyle")]
            public virtual int GetFightingStyle(int npcid) =>
                throw new NativeNotImplementedException();

            /* FCNPC Reloading And Infinite Ammo */
            [NativeMethod(Function = "FCNPC_ToggleReloading")]
            public virtual bool ToggleReloading(int npcid, bool toggle) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ToggleInfiniteAmmo")]
            public virtual bool ToggleInfiniteAmmo(int npcid, bool toggle) =>
                throw new NativeNotImplementedException();

            /* FCNPC Movement */
            [NativeMethod(Function = "FCNPC_GoTo")]
            public virtual bool GoTo(int npcid, float x, float y, float z, int type = (int)MoveType.Auto, float speed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setangle = true, float dist_offset = 0f, int stopdelay = 250) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GoToPlayer")]
            public virtual bool GoToPlayer(int npcid, int playerid, int type = (int)MoveType.Auto, float speed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setangle = true, float dist_offset = 0f, float dist_check = 1.5f, int stopdelay = 250) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_Stop")]
            public virtual bool Stop(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsMoving")]
            public virtual bool IsMoving(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsMovingAtPlayer")]
            public virtual bool IsMovingAtPlayer(int npcid, int playerid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetDestinationPoint")]
            public virtual bool GetDestinationPoint(int npcid, out float x, out float y, out float z) =>
                throw new NativeNotImplementedException();

            /* FCNPC Attacking */
            [NativeMethod(Function = "FCNPC_AimAt")]
            public virtual bool AimAt(int npcid, float x, float y, float z, bool shoot = false, int shoot_delay = -1, bool setangle = true, float offset_from_x = 0f, float offset_from_y = 0f, float offset_from_z = 0f) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_AimAtPlayer")]
            public virtual bool AimAtPlayer(int npcid, int playerid, bool shoot = false, int shoot_delay = -1, bool setangle = true, float offset_x = 0f, float offset_y = 0f, float offset_z = 0f, float offset_from_x = 0f, float offset_from_y = 0f, float offset_from_z = 0f) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_StopAim")]
            public virtual bool StopAim(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_MeleeAttack")]
            public virtual bool MeleeAttack(int npcid, int delay = -1, bool fightstyle = false) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_StopAttack")]
            public virtual bool StopAttack(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsAttacking")]
            public virtual bool IsAttacking(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsAiming")]
            public virtual bool IsAiming(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsAimingAtPlayer")]
            public virtual bool IsAimingAtPlayer(int npcid, int playerid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetAimingPlayer")]
            public virtual int GetAimingPlayer(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsShooting")]
            public virtual bool IsShooting(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsReloading")]
            public virtual bool IsReloading(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_TriggerWeaponShot")]
            public virtual bool TriggerWeaponShot(int npcid, int weaponid, int hittype, int hitid, float x, float y, float z, bool ishit = true, float offset_from_x = 0f, float offset_from_y = 0f, float offset_from_z = 0f) =>
                throw new NativeNotImplementedException();

            /* FCNPC Vehicles */
            [NativeMethod(Function = "FCNPC_EnterVehicle")]
            public virtual bool EnterVehicle(int npcid, int vehicleid, int seatid, int type = (int)MoveType.Walk) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ExitVehicle")]
            public virtual bool ExitVehicle(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_PutInVehicle")]
            public virtual bool PutInVehicle(int npcid, int vehicleid, int seatid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_RemoveFromVehicle")]
            public virtual bool RemoveFromVehicle(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetVehicleID")]
            public virtual int GetVehicleID(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetVehicleSeat")]
            public virtual int GetVehicleSeat(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetVehicleSiren")]
            public virtual bool SetVehicleSiren(int npcid, bool status) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsVehicleSiren")]
            public virtual bool IsVehicleSiren(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetVehicleHealth")]
            public virtual bool SetVehicleHealth(int npcid, float health) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetVehicleHealth")]
            public virtual float GetVehicleHealth(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetVehicleHydraThrusters")]
            public virtual bool SetVehicleHydraThrusters(int npcid, bool direction) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetVehicleHydraThrusters")]
            public virtual bool GetVehicleHydraThrusters(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetVehicleGearState")]
            public virtual bool SetVehicleGearState(int npcid, bool gear_state) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetVehicleGearState")]
            public virtual bool GetVehicleGearState(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetSurfingOffsets")]
            public virtual bool SetSurfingOffsets(int npcid, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GiveSurfingOffsets")]
            public virtual bool GiveSurfingOffsets(int npcid, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetSurfingOffsets")]
            public virtual bool GetSurfingOffsets(int npcid, out float x, out float y, out float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetSurfingVehicle")]
            public virtual bool SetSurfingVehicle(int npcid, int vehicleid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetSurfingVehicle")]
            public virtual int GetSurfingVehicle(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetSurfingObject")]
            public virtual bool SetSurfingObject(int npcid, int objectid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetSurfingObject")]
            public virtual int GetSurfingObject(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetSurfingPlayerObject")]
            public virtual bool SetSurfingPlayerObject(int npcid, int objectid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetSurfingPlayerObject")]
            public virtual int GetSurfingPlayerObject(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_StopSurfing")]
            public virtual bool StopSurfing(int npcid) =>
                throw new NativeNotImplementedException();

            /* FCNPC Recordings Playback */
            [NativeMethod(Function = "FCNPC_StartPlayingPlayback")]
            public virtual bool StartPlayingPlayback(int npcid, string file = "", int recordid = InvalidRecordId, bool auto_unload = false) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_StopPlayingPlayback")]
            public virtual bool StopPlayingPlayback(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_PausePlayingPlayback")]
            public virtual bool PausePlayingPlayback(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ResumePlayingPlayback")]
            public virtual bool ResumePlayingPlayback(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetPlayingPlaybackPath")]
            public virtual bool SetPlayingPlaybackPath(int npcid, string path) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetPlayingPlaybackPath")]
            public virtual bool GetPlayingPlaybackPath(int npcid, out string path, int size) =>
                throw new NativeNotImplementedException();

            /* FCNPC Nodes */
            [NativeMethod(Function = "FCNPC_PlayNode")]
            public virtual bool PlayNode(int npcid, int nodeid, int move_type = (int)MoveType.Auto, float speed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setangle = true) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_StopPlayingNode")]
            public virtual bool StopPlayingNode(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_PausePlayingNode")]
            public virtual bool PausePlayingNode(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_ResumePlayingNode")]
            public virtual bool ResumePlayingNode(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsPlayingNode")]
            public virtual bool IsPlayingNode(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsPlayingNodePaused")]
            public virtual bool IsPlayingNodePaused(int npcid) =>
                throw new NativeNotImplementedException();

            /* FCNPC Move Paths */
            [NativeMethod(Function = "FCNPC_GoByMovePath")]
            public virtual bool GoByMovePath(int npcid, int pathid, int type = (int)MoveType.Auto, float speed = MoveSpeed.Auto, bool useMapAndreas = false, float radius = 0f, bool setangle = true, float dist_offset = 0f) =>
                throw new NativeNotImplementedException();

            /* FCNPC Misc */
            [NativeMethod(Function = "FCNPC_ToggleMapAndreasUsage")]
            public virtual bool ToggleMapAndreasUsage(int npcid, bool enabled) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsMapAndreasUsed")]
            public virtual bool IsMapAndreasUsed(int npcid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetMinHeightPosCall")]
            public virtual bool SetMinHeightPosCall(int npcid, float height) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetMinHeightPosCall")]
            public virtual float SetMinHeightPosCall(int npcid) =>
                throw new NativeNotImplementedException();
        }
    }
}
