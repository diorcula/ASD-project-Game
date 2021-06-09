﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Agent.Mapper;
using NUnit.Framework;

namespace Agent.Tests.Mapper
{
    [ExcludeFromCodeCoverage]
    public class FileToSettingListMapperTest
    {
        private FileToSettingListMapper _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new FileToSettingListMapper();

        }

        [Test]
        public void Test_MapFileToConfiguration_Successful()
        {
            //Arrange
            List<Setting> expected = new List<Setting>();
            expected.Add(new Setting("explore", "random"));
            expected.Add(new Setting("combat", "offensive"));
            var filepath = string.Format(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\"))) + "Resource\\npcFileTest.txt";
            
            //Act
            var actual = _sut.MapFileToConfiguration(filepath);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Test_MapFileToConfiguration_Unsuccessful()
        {
            //Arrange
            var filepath = string.Format(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\"))) + "Resource\\npcFileTest_2.txt";
            
            //Act & Assert
            Assert.Throws<System.IndexOutOfRangeException>(() => _sut.MapFileToConfiguration(filepath));

        }
    }
}