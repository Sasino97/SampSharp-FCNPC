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
using SampSharp.GameMode.Pools;
using System.Collections.Generic;

namespace SampSharp.FCNPCs
{
    public partial class MovePath : IdentifiedPool<MovePath>
    {
        /// <summary>
        /// Returns whether this MovePath instance points
        /// to a valid move path.
        /// </summary>
        public bool IsValid
        {
            get
            {
                AssertNotDisposed();
                return Internal.IsValidMovePath(Id);
            }
        }

        private MovePath() { }

        /// <summary>
        /// Creates a new move path.
        /// </summary>
        public static MovePath Create()
        {
            return Create(Internal.CreateMovePath());
        }

        /// <summary>
        /// Destroys the move path.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            Internal.DestroyMovePath(Id);
            base.Dispose(disposing);
        }

        /***** TODO: create a custom collection to manage move points *****/
        /// <summary>
        /// Adds a point to the move path.
        /// </summary>
        public bool AddPoint(Vector3 point)
        {
            AssertNotDisposed();
            return Internal.AddPointToPath(Id, point.X, point.Y, point.Z);
        }

        /// <summary>
        /// Adds an array of points to the move path.
        /// </summary>
        public bool AddPoints(IList<Vector3> points)
        {
            AssertNotDisposed();

            int len = points.Count;
            float[,] pointsArr = new float[len, 3];

            for (int i = 0; i < len; i++)
            {
                pointsArr[i, 0] = points[i].X;
                pointsArr[i, 1] = points[i].Y;
                pointsArr[i, 2] = points[i].Z;
            }
            return Internal.AddPointsToPath(Id, pointsArr, len);
        }

        /// <summary>
        /// Removes a point from the move path.
        /// </summary>
        public bool RemovePoint(int pointIndex)
        {
            AssertNotDisposed();
            return Internal.RemovePointFromPath(Id, pointIndex);
        }

        /// <summary>
        /// Returns whether the specified move path point is valid.
        /// </summary>
        public bool IsValidPoint(int pointIndex)
        {
            AssertNotDisposed();
            return Internal.IsValidMovePoint(Id, pointIndex);
        }

        /// <summary>
        /// Gets the specified point.
        /// </summary>
        public Vector3 GetPoint(int pointIndex)
        {
            AssertNotDisposed();
            Internal.GetMovePoint(Id, pointIndex, out float x, out float y, out float z);
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Gets the the count of points.
        /// </summary>
        public int GetPointCount()
        {
            AssertNotDisposed();
            return Internal.GetNumberMovePoint(Id);
        }
    }
}
