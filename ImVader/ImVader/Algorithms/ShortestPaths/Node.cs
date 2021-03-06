﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Node.cs" company="Sigma">
//   It's a totally free software
// </copyright>
// <summary>
//   Defines the Node type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImVader.Algorithms.ShortestPaths
{
    using System;

    /// <summary>
    /// The node used in Dijktra algorithm.
    /// </summary>
    public class Node : IComparable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="nodeIndex">
        /// The index of the node.
        /// </param>
        /// <param name="weight">
        /// The weight.
        /// </param>
        public Node(int nodeIndex, double weight)
        {
            this.NodeIndex = nodeIndex;
            this.Weight = weight;
        }

        /// <summary>
        /// Gets or sets the weight of the path to the vertex.
        /// </summary>
        /// <value>
        /// The weight of the path to the vertex.
        /// </value>
        public double Weight { get; set; }

        /// <summary>
        /// Gets or sets the index of the node.
        /// </summary>
        /// <value>
        /// The index of the node.
        /// </value>
        public int NodeIndex { get; set; }

        /// <summary>
        /// Compares nodes, used for Dijkstra minPQ.
        /// </summary>
        /// <param name="obj">
        /// The object to compare.
        /// </param>
        /// <returns>
        /// The difference between the nodes.
        /// </returns>
        public int CompareTo(object obj)
        {
            var anotherNode = (Node)obj;
            return this.Weight.CompareTo(anotherNode.Weight);
        }
    }
}
