﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Agent.Exceptions;
using Agent.Mapper;
using Agent.Models;
using Agent.Services;
using InputCommandHandler;
using Moq;
using NUnit.Framework;

namespace Agent.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class AgentConfigurationServiceTests
    {
        private AgentConfigurationService _sut;
        private Mock<FileHandler> _fileHandlerMock;
        private Mock<Pipeline> _pipelineMock;
        private Mock<InputCommandHandlerComponent> _mockedRetriever;

        [SetUp]
        public void Setup()
        {
            _mockedRetriever = new();
            _sut = new AgentConfigurationService(new List<Configuration>(), new FileToSettingListMapper(), _mockedRetriever.Object);
            _fileHandlerMock = new Mock<FileHandler>();
            _sut.FileHandler = _fileHandlerMock.Object;
            _pipelineMock = new Mock<Pipeline>();
            _sut.Pipeline = _pipelineMock.Object;
        }

        [Test]
        public void Test_Configure_SyntaxError()
        {
            //Arrange
            var input = string.Format(Path.GetFullPath(Path.Combine
                        (AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\"))) + "resource\\AgentConfigurationTestFileParseException.txt";

            _mockedRetriever.SetupSequence(x => x.GetCommand()).Returns(input).Returns("cancel");
            
            _fileHandlerMock.Setup(x => x.ImportFile(It.IsAny<String>())).Returns("wrong:wrong");

            //Act
            _sut.Configure();

            //Assert
            Assert.AreEqual("missing '=' at 'wrong'", _sut.LastError);
        }
        
        [Test]
        public void Test_Configure_CatchesSemanticError()
        {
            //Arrange
            var input = string.Format(Path.GetFullPath(Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\"))) + "Resources\\AgentTestFileWrongExtension.txt";
            var error = "Semantic error";
            
            _mockedRetriever.SetupSequence(x => x.GetCommand()).Returns(input).Returns("cancel");
            _fileHandlerMock.Setup(x => x.ImportFile(It.IsAny<String>())).Returns("explore=high");
            _pipelineMock.Setup(x => x.CheckAst()).Throws(new SemanticErrorException(error));

            //Act
            _sut.Configure();

            //Assert
            Assert.AreEqual(error, _sut.LastError);
        }
        
        [Test]
        public void Test_Configure_FileError()
        {
            //Arrange
            var input = string.Format(Path.GetFullPath(Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\"))) + "Resources\\AgentTestFileWrongExtension.txt";
            var error = "File not found";
            _fileHandlerMock.Setup(x => x.ImportFile(It.IsAny<String>())).Throws(new FileException(error));
            _mockedRetriever.SetupSequence(x => x.GetCommand()).Returns(input).Returns("cancel");
            
            //Act
            _sut.Configure();

            //Assert
            Assert.AreEqual(error, _sut.LastError);
        }

        [Test]
        public void Test_Configure_SavesFileInAgentFolder()
        {
            //Arrange
            var input = string.Format(Path.GetFullPath(Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\"))) + "Resources\\AgentConfigurationTestFile.txt";
            _mockedRetriever.SetupSequence(x => x.GetCommand()).Returns(input);
            
            _fileHandlerMock.Setup(x => x.ImportFile(It.IsAny<String>())).Returns("aggressiveness=high");

            //Act
            _sut.Configure();
            
            //Assert
            _fileHandlerMock.Verify( x => x.ExportFile(It.IsAny<String>(), It.IsAny<String>()), Times.Exactly(1));
        }
        
        [Test]
        public void Test_CreateNewAgentConfiguration_WithNewAgent()
        {
            //Arrange
            var filepath =
                string.Format(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\"))) +
                "resource\\agent_test.cfg";

            //Act
            _sut.CreateConfiguration("Agent", filepath);

            //Assert
            Assert.True(_sut.GetConfigurations().Count > 0);
            Assert.AreEqual(_sut.GetConfigurations()[0].GetSetting("explore"), "random");
        }

        [Test]
        public void Test_Configure_Semantic()
        {
            //TODO not for this sprint bc of decision
        }
    }
}
