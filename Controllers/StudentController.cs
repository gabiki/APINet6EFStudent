using databaseAPI.Data;
using databaseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace databaseAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    
    private readonly DataContext _dataContext;

    public StudentController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("getallstudents")]
    public ActionResult<List<Student>> GetAllStudents()
    {
        var students = _dataContext.Students;
        return Ok(students);
    }

    [HttpGet("getstudent")]
    public ActionResult<Student> GetSingleStudent(string name)
    {
        var existingStudent = _dataContext.Students?.Where(x => x.FirstName == name).FirstOrDefault();
        if (existingStudent == null)
        {
            return NotFound("This student does not exist.");
        }
        else
        {
            return Ok(existingStudent);
        }
    }

    [HttpPost("addstudent")]
    public ActionResult AddStudent(Student student)
    {

        var existingStudent = _dataContext.Students?.Where(x => x.FirstName == student.FirstName).FirstOrDefault();
        if (existingStudent != null)
        {
            return BadRequest("This student already exists.");
        }
        else
        {
            _dataContext.Students.Add(student);
            _dataContext.SaveChanges();
            return Ok("Student added.");
        }
    }

    [HttpPut("updatestudent")]
    public ActionResult UpdateStudent(string name, Student student)
    {
        var existingStudent = _dataContext.Students?.Where(x => x.FirstName == name).FirstOrDefault();
        if (existingStudent == null)
        {
            return NotFound("This student does not exist.");
        }
        else
        {
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            _dataContext.SaveChanges();
            return Ok("Student updated.");
        }
    }

    [HttpDelete("deletestudent")]
    public ActionResult DeleteStudent(string name)
    {
        var existingStudent = _dataContext.Students?.Where(x => x.FirstName == name).FirstOrDefault();
        if (existingStudent != null)
        {
            _dataContext.Students.Remove(existingStudent);
            _dataContext.SaveChanges();
            return Ok("Student has been deleted.");
        }
        else
        {
            return NotFound("This student does not exist.");
        }
    }
}

