using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;

namespace KuasCoreTests.Services
{
    [TestClass]
    public class CourseServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public ICourseService CourseService { get; set; }
        
        //Function2-新增一筆課程記錄到資料庫
        [TestMethod]
        public void TestCourseService_AddCourse()
        {
            Course course = new Course();
            course.CourseID = "UnitTests";
            course.CourseName = "單元測試";
            course.CourseDescription = "15";
            CourseService.AddCourse(course);

            Course dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseID, dbCourse.CourseID);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseID);
            Console.WriteLine("描述 = " + dbCourse.CourseName);
            Console.WriteLine("課程年齡為 = " + dbCourse.CourseDescription);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNull(dbCourse);
        }
        /*
        [TestMethod]
        public void TestCourseService_UpdateCourse()
        {
            // 取得資料
            Course course = CourseService.GetCourseById("asp.net");
            Assert.IsNotNull(course);

            // 更新資料
            course.CourseName = "單元測試";
            CourseService.UpdateCourse(course);

            // 再次取得資料
            Course dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseID);
            Console.WriteLine("描述 = " + dbCourse.CourseName);
            Console.WriteLine("課程年齡為 = " + dbCourse.CourseDescription);

            Console.WriteLine("================================");

            // 將資料改回來
            course.CourseName = "嚴志和";
            CourseService.UpdateCourse(course);

            // 再次取得資料
            dbCourse = CourseService.GetCourseById(course.CourseID);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.CourseName, dbCourse.CourseName);

            Console.WriteLine("課程編號為 = " + dbCourse.CourseID);
            Console.WriteLine("描述 = " + dbCourse.CourseName);
            Console.WriteLine("課程年齡為 = " + dbCourse.CourseDescription);
        }
        */
        /*
        [TestMethod]
        public void TestCourseService_DeleteCourse()
        {
            Course newCourse = new Course();
            newCourse.CourseID = "UnitTests";
            newCourse.CourseName = "單元測試";
            newCourse.CourseDescription = "15";
            CourseService.AddCourse(newCourse);

            Course dbCourse = CourseService.GetCourseById(newCourse.CourseID);
            Assert.IsNotNull(dbCourse);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseById(newCourse.CourseID);
            Assert.IsNull(dbCourse);
        }
        */

        //Function1-以課程名稱讀取某筆紀錄
        [TestMethod]
        public void TestCourseService_GetCourseByName()
        {
            Course course = CourseService.GetCourseByName("test");
            Assert.IsNotNull(course);

            Console.WriteLine("課程編號為 = " + course.CourseID);
            Console.WriteLine("描述 = " + course.CourseName);
            Console.WriteLine("課程年齡為 = " + course.CourseDescription);
        }

    }
}
