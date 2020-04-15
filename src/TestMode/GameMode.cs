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
using SampSharp.GameMode;
using SampSharp.GameMode.SAMP;

namespace TestMode
{
    public class GameMode : BaseMode
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("  Test FCNPC gamemode by Sasinosoft ");
            Console.WriteLine("----------------------------------\n");
            
            var npc = FCNPC.Create("TesterBot");
            npc.Spawned += OnSpawned;
            npc.Destroyed += OnDestroyed;

            npc.Spawn(17, new Vector3(0f, 0f, 5f));
            npc.IsInvulnerable = true;

            var timer = new Timer(5000, false, true);
            timer.Tick += (object sender, EventArgs e) =>
            {
                npc.Dispose();
            };
        }

        private void OnDestroyed(object sender, EventArgs e)
        {
            Console.WriteLine($"NPC Destroyed: {sender as FCNPC}");
        }

        private void OnSpawned(object sender, EventArgs e)
        {
            Console.WriteLine($"NPC Spawned: {sender as FCNPC}");
        }
    }
}