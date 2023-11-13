using Microsoft.AspNetCore.Mvc;
using TESTAPP.DbConnection;

namespace TESTAPP.Controllers
{
    public class StudentController : Controller
    {


        [HttpPut]
        public IActionResult UpdateStudentById(int id, [FromBody] Student updatedStudent)
        {
            try
            {
                using (var _dbContext = new DatabaseContext())
                {
                    // Find the student with the specified Id in the database.
                    var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

                    if (student == null)
                    {
                        return NotFound(new
                        {
                            success = false,
                            message = "Student not found",
                            statusCode = 404
                        });
                    }

                    // Update the student's properties with the new values from the updatedStudent object.   
                    student.FirstName = updatedStudent.FirstName;
                    student.LastName = updatedStudent.LastName;
                    student.EmailAddress = updatedStudent.EmailAddress;

                    _dbContext.SaveChanges();

                    return StatusCode(200, new
                    {
                        success = true,
                        message = "Student updated successfully",
                        updatedStudent
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Logging the error (you can customize this part based on your logging strategy).
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error while updating student",
                    error = ex.Message
                });
            }
        }


        [HttpDelete]
        public IActionResult DeleteStudentById(int id)
        {
            try
            {
                using (var _dbContext = new DatabaseContext())
                {
                    // Find the student with the specified Id in the database.
                    var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

                    if (student == null)
                    {
                        return NotFound(new
                        {
                            success = false,
                            message = "Student not found",
                            statusCode = 404
                        });
                    }

                    // Delete the student from the database.
                    _dbContext.Students.Remove(student);
                    _dbContext.SaveChanges();

                    return StatusCode(200, new
                    {
                        success = true,
                        message = "Student deleted successfully"
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Logging the error (you can customize this part based on your logging strategy).
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error while deleting student",
                    error = ex.Message
                });
            }
        }


        [HttpGet]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                using (var _dbContext = new DatabaseContext())
                {
                    // Find the student with the specified Id in the database.
                    var student = _dbContext.Students.FirstOrDefault(s => s.Id == id);

                    if (student == null)
                    {
                        return NotFound(new
                        {
                            success = false,
                            message = "Student not found",
                            statusCode = 404
                        });
                    }

                    return StatusCode(200, new
                    {
                        success = true,
                        message = "Student found",
                        student
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Logging the error (you can customize this part based on your logging strategy).
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error while fetching student",
                    error = ex.Message
                });
            }
        }


        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                using (var _dbContext = new DatabaseContext())
                {
                    // Retrieve all students from the database.
                    var students = _dbContext.Students.ToList();

                    return StatusCode(200, new
                    {
                        success = true,
                        message = "Successfully fetched students",
                        students
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Logging the error (you can customize this part based on your logging strategy).
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error while fetching students",
                    error = ex.Message
                });
            }
        }


        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                using (var _dbContext = new DatabaseContext())
                {
                    // Add the student to the database and save changes.
                    _dbContext.Students.Add(student);
                    _dbContext.SaveChanges();

                    return StatusCode(200, new
                    {
                        success = true,
                        message = "Student added successfully",
                        student
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Logging the error (you can customize this part based on your logging strategy).
                return StatusCode(500, new
                {
                    success = false,
                    message = "Error while adding student",
                    error = ex.Message
                });
            }
        }


        [HttpGet]
        public IActionResult TestMethod()
        {
            return StatusCode(200, new
            {
                success = true,
                message = "Single Product Fetched",
                
            });
        }
    }
}
