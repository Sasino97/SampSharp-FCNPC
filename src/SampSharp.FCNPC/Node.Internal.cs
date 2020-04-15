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
    public partial class Node
    {
        private static readonly NodeInternal Internal;

        static Node()
        {
            Internal = NativeObjectProxyFactory.CreateInstance<NodeInternal>();
        }

        public class NodeInternal
        {
            [NativeMethod(Function = "FCNPC_OpenNode")]
            public virtual bool OpenNode(int nodeid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_CloseNode")]
            public virtual bool CloseNode(int nodeid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_IsNodeOpen")]
            public virtual bool IsNodeOpen(int nodeid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetNodeType")]
            public virtual int GetNodeType(int nodeid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_SetNodePoint")]
            public virtual bool SetNodePoint(int nodeid, int point) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetNodePointPosition")]
            public virtual bool GetNodePointPosition(int nodeid, out float x, out float y, out float z) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetNodePointCount")]
            public virtual int GetNodePointCount(int nodeid) =>
                throw new NativeNotImplementedException();

            [NativeMethod(Function = "FCNPC_GetNodeInfo")]
            public virtual bool GetNodeInfo(int nodeid, out int vehnodes, out int pednodes, out int navinodes) =>
                throw new NativeNotImplementedException();
        }
    }
}
