using GraduationTracker.Models;
using GraduationTracker.Models.Enums;
using GraduationTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private IGraduationTracker GraduationTracker { get; set; }
        private IDiplomaRepository DiplomaRepository { get; set; }
        private IStudentRepository StudentRepository { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            GraduationTracker = new GraduationTracker();
            DiplomaRepository = new DiplomaRepository();
            StudentRepository = new StudentRepository();
        }

        [TestMethod]
        public void TestHasCredits()
        {
            Diploma diploma = new Diploma();
            Student[] students = new Student[] { };
            List<Tuple<bool, Standing>> graduated = new List<Tuple<bool, Standing>>();
            int i = 1;
            diploma = DiplomaRepository.GetById(i);

            int[] ids = new int[] { 1, 2, 3 };
            students = StudentRepository.All(ids).ToArray();

            foreach (Student student in students)
            {
                graduated.Add(GraduationTracker.HasGraduated(diploma, student));
            }
            Assert.IsTrue(graduated.Any());

            ids = new int[] { 4 };
            students = StudentRepository.All(ids).ToArray();
            foreach (Student student in students)
            {
                graduated.Clear();
                graduated.Add(GraduationTracker.HasGraduated(diploma, student));
            }
            Assert.IsFalse(graduated.Any(g => g.Item1 == true));

            ids = new int[] { 1, 4 };
            students = StudentRepository.All(ids).ToArray();
            foreach (Student student in students)
            {
                graduated.Clear();
                graduated.Add(GraduationTracker.HasGraduated(diploma, student));
            }
            Assert.IsTrue(graduated.Any());
        }

        [TestMethod]
        public void TestHasNoCredits()
        {
            Diploma diploma = new Diploma();
            Student[] students = new Student[] { };
            List<Tuple<bool, Standing>> graduated = new List<Tuple<bool, Standing>>();
            int i = 1;
            int[] ids = new int[] { 1, 2, 3 };
            diploma = DiplomaRepository.GetById(i);
            students = StudentRepository.All(ids).ToArray();

            foreach (Student student in students)
            {
                graduated.Add(GraduationTracker.HasGraduated(diploma, student));
            }
            Assert.IsFalse(graduated.All(g => g.Item1 == false));

            ids = new int[] { 4 };
            students = StudentRepository.All(ids).ToArray();
            foreach (Student student in students)
            {
                graduated.Clear();
                graduated.Add(GraduationTracker.HasGraduated(diploma, student));
            }
            Assert.IsTrue(graduated.All(g => g.Item1 == false));

            ids = new int[] { 1, 4 };
            students = StudentRepository.All(ids).ToArray();
            foreach (Student student in students)
            {
                graduated.Clear();
                graduated.Add(GraduationTracker.HasGraduated(diploma, student));
            }
            Assert.IsFalse(graduated.All(g => g.Item1 == true));
        }

    }
}
