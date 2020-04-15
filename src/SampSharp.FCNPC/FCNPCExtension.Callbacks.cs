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
using SampSharp.Core.Callbacks;

namespace SampSharp.FCNPCs
{
    public partial class FCNPCExtension
    {
        [Callback] internal void FCNPC_OnCreate(int npcid) => FCNPC.OnCreate(npcid);
        [Callback] internal void FCNPC_OnDestroy(int npcid) => FCNPC.OnDestroy(npcid);
        [Callback] internal void FCNPC_OnSpawn(int npcid) => FCNPC.OnSpawn(npcid);
        [Callback] internal void FCNPC_OnRespawn(int npcid) => FCNPC.OnRespawn(npcid);
        [Callback] internal void FCNPC_OnDeath(int npcid, int killerid, int weaponid) => FCNPC.OnDeath(npcid, killerid, weaponid);
        [Callback] internal void FCNPC_OnVehicleEntryComplete(int npcid, int vehicleid, int seatid) => FCNPC.OnVehicleEntryComplete(npcid, vehicleid, seatid);
        [Callback] internal void FCNPC_OnVehicleExitComplete(int npcid) => FCNPC.OnVehicleExitComplete(npcid);
        [Callback] internal void FCNPC_OnReachDestination(int npcid) => FCNPC.OnReachDestination(npcid);
        [Callback] internal void FCNPC_OnFinishPlayback(int npcid) => FCNPC.OnFinishPlayback(npcid);
        [Callback] internal void FCNPC_OnTakeDamage(int npcid, int damagerid, int weaponid, int bodypart, float health_loss) => FCNPC.OnTakeDamage(npcid, damagerid, weaponid, bodypart, health_loss);
        [Callback] internal void FCNPC_OnGiveDamage(int npcid, int damagedid, int weaponid, int bodypart, float health_loss) => FCNPC.OnGiveDamage(npcid, damagedid, weaponid, bodypart, health_loss);
        [Callback] internal void FCNPC_OnVehicleTakeDamage(int npcid, int damagerid, int vehicleid, int weaponid, float x, float y, float z) => FCNPC.OnVehicleTakeDamage(npcid, damagerid, vehicleid, weaponid, x, y, z);
        [Callback] internal bool FCNPC_OnWeaponShot(int npcid, int weaponid, int hittype, int hitid, float x, float y, float z) => FCNPC.OnWeaponShot(npcid, weaponid, hittype, hitid, x, y, z);
        [Callback] internal void FCNPC_OnWeaponStateChange(int npcid, int weapon_state) => FCNPC.OnWeaponStateChange(npcid, weapon_state);
        [Callback] internal void FCNPC_OnFinishNodePoint(int npcid, int point) => FCNPC.OnFinishNodePoint(npcid, point);
        [Callback] internal void FCNPC_OnChangeNode(int npcid, int nodeid) => FCNPC.OnChangeNode(npcid, nodeid);
        [Callback] internal void FCNPC_OnFinishNode(int npcid) => FCNPC.OnFinishNode(npcid);
        [Callback] internal void FCNPC_OnStreamIn(int npcid, int forplayerid) => FCNPC.OnStreamIn(npcid, forplayerid);
        [Callback] internal void FCNPC_OnStreamOut(int npcid, int forplayerid) => FCNPC.OnStreamOut(npcid, forplayerid);
        [Callback] internal bool FCNPC_OnUpdate(int npcid) => FCNPC.OnUpdate(npcid);
        [Callback] internal void FCNPC_OnFinishMovePath(int npcid, int pathid) => FCNPC.OnFinishMovePath(npcid, pathid);
        [Callback] internal void FCNPC_OnFinishMovePathPoint(int npcid, int pathid, int pointid) => FCNPC.OnFinishMovePathPoint(npcid, pathid, pointid);
        [Callback] internal void FCNPC_OnChangeHeightPos(int npcid, float new_z, float old_z) => FCNPC.OnChangeHeightPos(npcid, new_z, old_z);
    }
}
