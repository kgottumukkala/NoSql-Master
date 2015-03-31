using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoSqlSvc.Controllers;
using System.Collections.Generic;

namespace NoSqlSvc.Tests.Controllers
{
    [TestClass]
    public class CourseControllerTest
    {
        CourseController _courseController;

        [TestInitialize]
        public void Setup ()
        {
            _courseController = new CourseController();
        }


        [TestMethod]
        public void Get_Success ()
        {
            var courses = _courseController.Get();
            Assert.IsNotNull( courses );
            Assert.Equals( typeof( IEnumerable< Models.Course >), courses.GetType() );
        }

        [TestMethod]
        public void Get_Fail ()
        {
            var courses = _courseController.Get();
            Assert.IsNotNull( courses );
            Assert.Equals( typeof( IEnumerable<Models.Course> ), courses.GetType() );
        }
    }
}
