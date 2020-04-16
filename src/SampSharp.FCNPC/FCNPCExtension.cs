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
using SampSharp.FCNPCs;
using SampSharp.FCNPCs.Controllers;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using System;

[assembly: SampSharpExtension(typeof(FCNPCExtension))]
namespace SampSharp.FCNPCs
{
    public partial class FCNPCExtension : Extension, IService
    {
        /// <summary>
        /// Gets the game mode.
        /// </summary>
        public BaseMode GameMode { get; private set; }

        //
        public override void LoadServices(BaseMode gameMode)
        {
            GameMode = gameMode;
            gameMode.Services.AddService(this);
            base.LoadServices(gameMode);
        }

        //
        public override void LoadControllers(BaseMode gameMode, ControllerCollection controllerCollection)
        {
            var type = typeof(FCNPCController);
            var instance = Activator.CreateInstance(type);
            var controller = instance as IController;
            controllerCollection.Add(controller);
            base.LoadControllers(gameMode, controllerCollection);
        }
    }
}
