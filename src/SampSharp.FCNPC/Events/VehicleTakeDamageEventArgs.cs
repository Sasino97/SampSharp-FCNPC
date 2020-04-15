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
using SampSharp.GameMode;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.World;
using System;

namespace SampSharp.FCNPCs.Events
{
    public class VehicleTakeDamageEventArgs : EventArgs
    {
        public BasePlayer Damager { get; set; }
        public BaseVehicle Vehicle { get; set; }
        public Weapon Weapon { get; set; }
        public Vector3 Position { get; set; }
    }
}
