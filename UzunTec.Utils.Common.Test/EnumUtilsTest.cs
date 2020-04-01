using System;
using System.Collections.Generic;
using Xunit;

namespace UzunTec.Utils.Common.Test
{
    public class EnumUtilsTest
    {
        public enum Sides
        {
            Up, Down, Left, Right
        }

        public enum Profiences
        {
            Doctor = 'D',
            Enginner = 'E',
            Teacher = 'T',
        }

        public enum Status
        {
            Inactive = 0,
            Active = 1,
            Overload = 2,
        }


        public static IEnumerable<object[]> GetGenericEnumGetValueMassTests()
        {
            return new List<object[]>
            {
                new object[] { typeof(Status), null, true, null},
                new object[] { typeof(Status), null, false, null},
                new object[] { typeof(Sides), null, false, null},
                new object[] { typeof(Profiences), null, false, null},
                new object[] { typeof(Status), "Inactive", true, Status.Inactive},
                new object[] { typeof(Status), "Active", true, Status.Active},
                new object[] { typeof(Status), "Overload", true, Status.Overload},
                new object[] { typeof(Status), "NotContained", true, null },
                new object[] { typeof(Status), "inactive", true, Status.Inactive},
                new object[] { typeof(Status), "active", true, Status.Active},
                new object[] { typeof(Status), "overload", true, Status.Overload},
                new object[] { typeof(Status), "notcontained", true, null },
                new object[] { typeof(Status), "Inactive", false, Status.Inactive},
                new object[] { typeof(Status), "Active", false, Status.Active},
                new object[] { typeof(Status), "Overload", false, Status.Overload},
                new object[] { typeof(Status), "NotContained", false, null },
                new object[] { typeof(Status), "inactive", false, null},
                new object[] { typeof(Status), "active", false, null},
                new object[] { typeof(Status), "overload", false, null},
                new object[] { typeof(Status), 'i' , true, null},
                new object[] { typeof(Status), 'a' , true, null},
                new object[] { typeof(Status), 'o', true,null},
                new object[] { typeof(Status), 'I' , true, null},
                new object[] { typeof(Status), 'A' , true, null},
                new object[] { typeof(Status), 'O', true, null},
                new object[] { typeof(Status), 0, false, Status.Inactive},
                new object[] { typeof(Status), 1, false, Status.Active},
                new object[] { typeof(Status), 2, false, Status.Overload},
                new object[] { typeof(Profiences), "Doctor", true, Profiences.Doctor},
                new object[] { typeof(Profiences), "Enginner", true, Profiences.Enginner},
                new object[] { typeof(Profiences), "Teacher", true, Profiences.Teacher},
                new object[] { typeof(Profiences), "D", true, null },
                new object[] { typeof(Profiences), "E", true, null},
                new object[] { typeof(Profiences), "T", true, null},
                new object[] { typeof(Profiences), 'D', true, Profiences.Doctor},
                new object[] { typeof(Profiences), 'E', true, Profiences.Enginner},
                new object[] { typeof(Profiences), 'T', true, Profiences.Teacher},
                new object[] { typeof(Sides), "Up", true, Sides.Up},
                new object[] { typeof(Sides), "Down", true, Sides.Down},
                new object[] { typeof(Sides), "Left", true, Sides.Left},
                new object[] { typeof(Sides), "Right", true, Sides.Right},
                new object[] { typeof(Sides), 0, true, Sides.Up},
                new object[] { typeof(Sides), 1, true, Sides.Down},
                new object[] { typeof(Sides), 2, true, Sides.Left},
                new object[] { typeof(Sides), 3, true, Sides.Right},
                new object[] { typeof(Status), Sides.Up, true, Status.Inactive},
                new object[] { typeof(Sides), Status.Inactive, true,  Sides.Up},
                new object[] { typeof(Sides), null, true,  null},
            };
        }

        [Theory]
        [MemberData(nameof(GetGenericEnumGetValueMassTests))]
        public void GenericEnumGetValueMassTest(Type enumType, object obj, bool ignoreStatus, object expected)
        {
            object result = EnumUtils.GetEnumValue(enumType, obj, ignoreStatus);
            object resultConverted = (result == null) ? null : Enum.ToObject(enumType, result);
            object expectedConverted = (expected == null) ? null : Enum.ToObject(enumType, expected);
            Assert.True((resultConverted == null && expectedConverted == null) || resultConverted.Equals(expectedConverted));
        }

        public static IEnumerable<object[]> GetStatusValueMassTests()
        {
            return new List<object[]>
            {
                new object[] { null, true, null},
                new object[] { null, false, null},
                new object[] { "Inactive", true, Status.Inactive},
                new object[] { "Active", true, Status.Active},
                new object[] { "Overload", true, Status.Overload},
                new object[] { "NotContained", true, null },
                new object[] { "inactive", true, Status.Inactive},
                new object[] { "active", true, Status.Active},
                new object[] { "overload", true, Status.Overload},
                new object[] { "notcontained", true, null },
                new object[] { "Inactive", false, Status.Inactive},
                new object[] { "Active", false, Status.Active},
                new object[] { "Overload", false, Status.Overload},
                new object[] { "NotContained", false, null },
                new object[] { "inactive", false, null},
                new object[] { "active", false, null},
                new object[] { "overload", false, null},
                new object[] { 'i' , true, null},
                new object[] { 'a' , true, null},
                new object[] { 'o', true,null},
                new object[] { 'I' , true, null},
                new object[] { 'A' , true, null},
                new object[] { 'O', true, null},
                new object[] { 0, false, Status.Inactive},
                new object[] { 1, false, Status.Active},
                new object[] { 2, false, Status.Overload},
            };
        }

        [Theory]
        [MemberData(nameof(GetStatusValueMassTests))]
        public void ParseStatusMassTests(object obj, bool ignoreStatus, Status? expected)
        {
            Assert.True(EnumUtils.GetEnumValue<Status>(obj, ignoreStatus) == expected);
        }

        public static IEnumerable<object[]> GetProficienceValueMassTests()
        {
            return new List<object[]>
            {
                new object[] { "Doctor", true, Profiences.Doctor},
                new object[] { "Enginner", true, Profiences.Enginner},
                new object[] { "Teacher", true, Profiences.Teacher},
                new object[] { "D", true, null },
                new object[] { "E", true, null},
                new object[] { "T", true, null},
                new object[] { 'D', true, Profiences.Doctor},
                new object[] { 'E', true, Profiences.Enginner},
                new object[] { 'T', true, Profiences.Teacher},
                new object[] { 'd', true, null},
                new object[] { 'e', true, null},
                new object[] { 't', true, null},
                new object[] { 0, false, null},
                new object[] { 1, false, null},
                new object[] { 2, false, null},
            };
        }

        [Theory]
        [MemberData(nameof(GetProficienceValueMassTests))]
        public void ProficienceValueMassTest(object obj, bool ignoreStatus, Profiences? expected)
        {
            Assert.True(EnumUtils.GetEnumValue<Profiences>(obj, ignoreStatus) == expected);
        }

        public static IEnumerable<object[]> GetSidesValueMassTests()
        {
            return new List<object[]>
            {
                new object[] { "Up", true, Sides.Up},
                new object[] { "Down", true, Sides.Down},
                new object[] { "Left", true, Sides.Left},
                new object[] { "Right", true, Sides.Right},
                new object[] { 0, true, Sides.Up},
                new object[] { 1, true, Sides.Down},
                new object[] { 2, true, Sides.Left},
                new object[] { 3, true, Sides.Right},
            };
        }

        [Theory]
        [MemberData(nameof(GetSidesValueMassTests))]
        public void SidesValueMassTest(object obj, bool ignoreStatus, Sides? expected)
        {
            Assert.True(EnumUtils.GetEnumValue<Sides>(obj, ignoreStatus) == expected);
        }
    }
}
