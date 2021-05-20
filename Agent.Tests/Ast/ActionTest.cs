﻿using Agent.Antlr.Ast;
using System;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using Action = Agent.Antlr.Ast.Action;

namespace Agent.Tests.ast
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class ActionTest
    {
        private Action _action;
        private const string TYPE = "Action";

        [SetUp]
        public void Setup()
        {
            _action = new Action("");
        }


        [Test]
        public void Test_GetNodeType_CorrectOutput()
        {
            //Arrange
            //Act
            var result = _action.GetNodeType();
            //Assert
            Assert.AreEqual(TYPE, result);
        }


        [Test]
        public void Test_AddChild_AddConditionChild()
        {
            //Arrange
            var condition = new Condition();
            _action.AddChild(condition);

            //Act
            var result = (_action.GetChildren()[0])?.GetNodeType();

            //Assert
            Assert.AreEqual("Condition", result);
        }


        [Test]
        public void Test_AddChild_AddNodeChild()
        {
            //Arrange
            var node = new Node();
            _action.AddChild(node);

            //Act
            var result = (_action.GetChildren()[0])?.GetNodeType();

            //Assert
            Assert.AreEqual("Node", result);
        }


        [Test]
        public void Test_RemoveChild_RemoveConditionChild()
        {
            //Arrange
            var condition = new Condition();
            _action.AddChild(condition);
            _action.RemoveChild(condition);

            //Act
            var result = _action.GetChildren().Count == 0;

            //Assert
            Assert.True(result);
        }

   
        [Test]
        public void Test_RemoveChild_RemoveNodeChild()
        {
            //Arrange
            var node = new Node();
            _action.AddChild(node);
            _action.RemoveChild(node);

            //Act
            var result = _action.GetChildren().Count == 0;

            //Assert
            Assert.True(result);
        }
    }
}