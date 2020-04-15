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
using SampSharp.Core.Natives.NativeObjects;

namespace SampSharp.FCNPCs
{
    public partial class MovePath
    {
        private static readonly MovePathInternal Internal;

        static MovePath()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<MovePathInternal>();
        }

        public class MovePathInternal
        {
            [NativeMethod(Function = "FCNPC_CreateMovePath")]
            public virtual int CreateMovePath() =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_DestroyMovePath")]
            public virtual bool DestroyMovePath(int pathid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsValidMovePath")]
            public virtual bool IsValidMovePath(int pathid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_AddPointToPath")]
            public virtual bool AddPointToPath(int pathid, float x, float y, float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_AddPointsToPath")]
            public virtual bool AddPointsToPath(int pathid, float[,] points, int size) =>
                throw new NativeNotImplementedException();

            // Unused
            [NativeMethod(Function = "FCNPC_AddPointsToPath2")]
            public virtual bool AddPointsToPath2(int pathid, float[] points_x, float[] points_y, float[] points_z, int size) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_RemovePointFromPath")]
            public virtual bool RemovePointFromPath(int pathid, int pointid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsValidMovePoint")]
            public virtual bool IsValidMovePoint(int pathid, int pointid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetMovePoint")]
            public virtual bool GetMovePoint(int pathid, int pointid, out float x, out float y, out float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetNumberMovePoint")]
            public virtual int GetNumberMovePoint(int pathid) =>
                throw new NativeNotImplementedException();
        }
    }
}
