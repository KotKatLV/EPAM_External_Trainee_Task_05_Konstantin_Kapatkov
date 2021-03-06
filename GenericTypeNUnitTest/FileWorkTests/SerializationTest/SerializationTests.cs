﻿using GenericType.Enums;
using GenericType.Models;
using GenericType.Serializers;
using GenericTypeNUnitTest.FileWorkTests.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace GenericTypeNUnitTest.DeserializationTest
{
    [Description("Class for testing deserialization of objects in various file formats")]
    [TestFixture]
    public class SerializationTests : GenericFileWorker
    {
        [Description("Initialization of _student and _students objects")]
        [OneTimeSetUp]
        public void Initialization()
        {
            Student = new Student { Name = "Vasya", Surname = "Vasiliev", Birthday = new DateTime(2000, 12, 12, 13, 15, 15) };
            Students = new StudentsCollection<Student>(new List<Student>
            {
                new Student { Name = "Vasya", Surname = "Vasiliev", Birthday = new DateTime(2000, 12, 12, 13, 15, 15) },
                new Student { Name = "Petya", Surname = "Petrov", Birthday = new DateTime(1999, 5, 7, 8, 13, 6) },
                new Student { Name = "Kolya", Surname = "Koloev", Birthday = new DateTime(1995, 9, 7, 15, 10, 10) },
            });
        }

        [Description("Testing object serialization to binary file")]
        [Test]
        public void SerializeToBinaryFile_Object_Test()
        {
            MyFileWorker<Student>.Serialize(Path.Combine(_pathToFiles, typeof(Student).Name + _binaryFileExtension), Student, SerializationType.Binary);
            Assert.AreEqual(Student, MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _binaryFileExtension), Student.Version.ToString(), DeserializationType.Binary));
        }

        [Description("Testing object serialization to JSON file")]
        [Test]
        public void SerializeToJSONFile_Object_Test()
        {
            MyFileWorker<Student>.Serialize(Path.Combine(_pathToFiles, typeof(Student).Name + _jsonFileExtension), Student, SerializationType.JSON);
            Assert.AreEqual(Student, MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _jsonFileExtension), Student.Version.ToString(), DeserializationType.JSON));
        }

        [Description("Testing object serialization to XML file")]
        [Test]
        public void SerializeToXmlFile_Object_Test()
        {
            MyFileWorker<Student>.Serialize(Path.Combine(_pathToFiles, typeof(Student).Name + _xmlFileExtension), Student, SerializationType.XML);
            Assert.AreEqual(Student, MyFileWorker<Student>.Deserialize(Path.Combine(_pathToFiles, typeof(Student).Name + _xmlFileExtension), Student.Version.ToString(), DeserializationType.XML));
        }

        [Description("Testing object collection serialization to binary file")]
        [Test]
        public void SerializeToBinaryFile_ObjectCollection_Test()
        {
            MyFileWorker<StudentsCollection<Student>>.Serialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _binaryFileExtension), Students, SerializationType.Binary);
            Assert.AreEqual(Students, MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _binaryFileExtension), Students.Version.ToString(), DeserializationType.Binary));
        }

        [Description("Testing object collection serialization to JSON file")]
        [Test]
        public void SerializeToJSONFile_ObjectCollection_Test()
        {
            MyFileWorker<StudentsCollection<Student>>.Serialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _jsonFileExtension), Students, SerializationType.JSON);
            Assert.AreEqual(Students, MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _jsonFileExtension), Students.Version.ToString(), DeserializationType.JSON));
        }

        [Description("Testing object collection serialization to XML file")]
        [Test]
        public void SerializeToXmlFile_ObjectCollection_Test()
        {
            MyFileWorker<StudentsCollection<Student>>.Serialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _xmlFileExtension), Students, SerializationType.XML);
            Assert.AreEqual(Students, MyFileWorker<StudentsCollection<Student>>.Deserialize(Path.Combine(_pathToFiles, typeof(StudentsCollection<Student>).Name + _xmlFileExtension), Students.Version.ToString(), DeserializationType.XML));
        }
    }
}