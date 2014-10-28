﻿namespace ImVaderUnitTests.AlgorithmsTests
{
    using System;
    using System.Linq;
    using ImVader;
    using ImVader.Algorithms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DepthFirstPassesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), AllowDerivedTypes = false)]
        public void InitTest()
        {
            var g = new MatrixGraph<int, Edge>(4);
            g.AddEdge(new UnweightedEdge(0, 1));
            g.AddEdge(new UnweightedEdge(2, 3));
            var dfs = new DepthFirstPathes<int, Edge>(g, -1);
            Assert.IsNotNull(dfs);
        }

        [TestMethod]
        public void DfsTest()
        {
            var g = new MatrixGraph<int, Edge>(4);
            g.AddEdge(new UnweightedEdge(0, 1));
            g.AddEdge(new UnweightedEdge(2, 3));
            var dfs = new DepthFirstPathes<int, Edge>(g, 0);
            Assert.IsFalse(dfs.HasPathTo(2));
            Assert.IsNull(dfs.PathTo(2));
            Assert.IsTrue(dfs.HasPathTo(1));
            Assert.IsTrue(dfs.PathTo(1).ToArray().Length == 2);
        }

        [TestMethod]
        public void DirectedGraphTest()
        {
            var dirListGraph = new DirectedListGraph<int, Edge>(4);
            dirListGraph.AddEdge(new UnweightedEdge(0, 1));
            dirListGraph.AddEdge(new UnweightedEdge(1, 3));
            dirListGraph.AddEdge(new UnweightedEdge(0, 2));
            dirListGraph.AddEdge(new UnweightedEdge(0, 3));
            var dfs = new DepthFirstPathes<int, Edge>(dirListGraph, 1);
            Assert.IsFalse(dfs.HasPathTo(0));
        }

        [TestMethod]
        public void PathToTest()
        {
            var dirListGraph = new DirectedListGraph<int, Edge>(5);
            dirListGraph.AddEdge(new UnweightedEdge(0, 1));
            dirListGraph.AddEdge(new UnweightedEdge(1, 3));
            dirListGraph.AddEdge(new UnweightedEdge(0, 2));
            dirListGraph.AddEdge(new UnweightedEdge(0, 3));
            dirListGraph.AddEdge(new UnweightedEdge(3, 4));
            var dfs = new DepthFirstPathes<int, Edge>(dirListGraph, 0);
            var path = dfs.PathTo(4).ToArray();
            int[] path1 = { 0, 1, 3, 4 };
            int[] path2 = { 0, 3, 4 };
            Assert.IsTrue(path.Length == path1.Length || path.Length == path2.Length);
        }
    }
}
