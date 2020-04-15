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
using SampSharp.GameMode;

namespace SampSharp.FCNPCs
{
    public partial class Node
    {
        //
        public int Id { get; private set; }

        //
        public bool IsOpen => Internal.IsNodeOpen(Id);
        public NodeType Type => (NodeType)Internal.GetNodeType(Id);
        public int Point { set { Internal.SetNodePoint(Id, value); } }

        //
        public Node(int id) 
        {
            Id = id;
        }

        //
        public bool Open() => Internal.OpenNode(Id);
        public bool Close() => Internal.CloseNode(Id);

        //
        public Vector3 GetNodePointPosition()
        {
            Internal.GetNodePointPosition(Id, out float x, out float y, out float z);
            return new Vector3(x, y, z);
        }

        //
        public int GetNodePointCount() => Internal.GetNodePointCount(Id);

        //
        public bool GetNodeInfo(out int vehnodes, out int pednodes, out int navinodes) =>
            Internal.GetNodeInfo(Id, out vehnodes, out pednodes, out navinodes);
    }
}
