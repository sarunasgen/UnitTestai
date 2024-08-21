namespace ListOperations.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestListInitialize()
        {
            //Arrange&Act
            StudentsService studentsService = new StudentsService();
            //Assert
            Assert.Equal(0, studentsService.Students.Count);
            Assert.NotNull(studentsService.Students);

        }

        [Fact]
        public void TestAddStudent()
        {
            //Arrange
            StudentsService studentsService = new StudentsService();
            Student student1 = new Student
            {
                Name = "Vardenis",
                Surname = "Pavardenis"
            };
            Student student2 = new Student
            {
                Name = "Vardaitis",
                Surname = "Pavardaitis"
            };
            //Act
            studentsService.AddStudent(student1);
            studentsService.AddStudent(student2);
            //Assert
            Assert.Equal(2, studentsService.Students.Count);

        }
        [Fact]
        public void TestAddStudentWithNull()
        {
            //Arrange
            StudentsService studentsService = new StudentsService();
            Student student1 = new Student
            {
                Name = "Vardenis",
                Surname = "Pavardenis"
            };
            
            //Act
            studentsService.AddStudent(student1);
            studentsService.AddStudent(null);
            //Assert
            Assert.Equal(1, studentsService.Students.Count);

        }
    }
}