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
using System;
using SampSharp.FCNPCs;
using SampSharp.FCNPCs.Definitions;
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.Events;
using SampSharp.GameMode.SAMP.Commands;
using SampSharp.GameMode.World;
using static System.Math;

namespace TestMode
{
    public class GameMode : BaseMode
    {
        private static FCNPC clone;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("  Test FCNPC gamemode by Sasinosoft ");
            Console.WriteLine("----------------------------------\n");

            AddPlayerClass(17, new Vector3(834.8044f, -2052.1753f, 12.8672f), 0f);
        }

        protected override void OnPlayerSpawned(BasePlayer player, SpawnEventArgs e)
        {
            player.GiveWeapon(Weapon.Tec9, 5000);
        }

        [Command("clone create")]
        private static void CloneCreateCommand(BasePlayer player)
        {
            if (clone != null)
            {
                player.SendClientMessage("Your clone was already created!");
                return;
            }

            clone = FCNPC.Create($"[BOT]{player.Name}");
            var pos = GetPositionInFront(player.Position, player.Angle, 2f);
            clone.Spawned += (object sender, EventArgs e) =>
            {
                clone.Angle = player.Angle + 180;
                clone.Armour = 100f;
                clone.Weapon = Weapon.Uzi;
                clone.Ammo = 100;
                clone.ToggleInfiniteAmmo(true);
                clone.ToggleReloading(true);
            };
            clone.Died += (object sender, DeathEventArgs e) =>
            {
                clone.Dispose();
                clone = null;
                player.SendClientMessage("Your eliminated your clone.");
            }; 
            clone.Spawn(player.Skin, pos);
            player.SendClientMessage("Your clone was created.");
        }

        [Command("clone destroy")]
        private static void CloneDestroyCommand(BasePlayer player)
        {
            if (clone == null)
            {
                player.SendClientMessage("You don't have a clone! Type /clone to spawn it.");
                return;
            }
            clone.Dispose();
            clone = null;
            player.SendClientMessage("Your clone was destroyed.");
        }

        [Command("clone attack")]
        private static void CloneAttackCommand(BasePlayer player)
        {
            if (clone == null)
            {
                player.SendClientMessage("You don't have a clone! Type /clone to spawn it.");
                return;
            }

            if (clone.Vehicle != null)
            {
                clone.ExitVehicle();
                EventHandler exitHandler = null;
                exitHandler = (object sender, EventArgs e) =>
                {
                    clone.VehicleExitCompleted -= exitHandler;
                    clone.AimAt(player, true);
                    player.SendClientMessage("Your clone will now attack you!");
                };
                clone.VehicleExitCompleted += exitHandler;
                return;
            }

            clone.AimAt(player, true, 2000);
            player.SendClientMessage("Your clone will now attack you!");
        }

        [Command("clone car")]
        private static void CloneCarCommand(BasePlayer player)
        {
            if (clone == null)
            {
                player.SendClientMessage("You don't have a clone! Type /clone to spawn it.");
                return;
            }

            if (clone.IsAiming)
                clone.StopAim();

            player.SendClientMessage("Your clone will now enter a car.");

            var pos = GetPositionInFront(clone.Position, clone.Angle - 90, 5f);
            var v = BaseVehicle.Create(VehicleModelType.Rancher, pos, clone.Angle, 0, 0);
            clone.EnterVehicle(v, 0, MoveType.Walk);
        }

        // Utils
        private static Vector3 GetPositionInFront(Vector3 pos, float angle, float distance)
        {
            float x = pos.X;
            float y = pos.Y;
            float z = pos.Z;
            float a = (angle + 90) * (float)(PI / 180d);

            x += distance * (float)Cos(a);
            y += distance * (float)Sin(a);
            return new Vector3(x, y, z);
        }
    }
}