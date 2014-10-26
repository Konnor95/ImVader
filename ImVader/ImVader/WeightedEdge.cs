﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeightedEdge.cs" company="Sigma">
//   It's a totally free software
// </copyright>
// <summary>
//   Defines the WeightedEdge type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImVader
{
    /// <summary>
    /// Represents weighted edge in the graph
    /// </summary>
    public class WeightedEdge : Edge
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeightedEdge"/> class.
        /// </summary>
        /// <param name="from">
        /// The first vertex of the edge
        /// </param>
        /// <param name="to">
        /// The second vertex of the edge
        /// </param>
        /// <param name="weight">
        /// WEight of the edge
        /// </param>
        public WeightedEdge(int from, int to, double weight)
            : base(from, to)
        {
            Weight = weight;
        }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public double Weight { get; set; }
    }
}
