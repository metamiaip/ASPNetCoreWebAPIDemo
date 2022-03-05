using ASPNetCoreWebAPiDemo.Services;
using ASPNetCoreWebAPIDemo.Models;
using ASPNetCoreWebAPIDemo.ViewModels;

namespace ASPNetCoreWebAPIDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmpContext _context;
        public EmployeeService(EmpContext context)
        {
            _context = context;
        }

        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ResponseModel DeleteEmployee(int employeeId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employees _temp = GetEmployeeDetailsById(employeeId);
                if (_temp != null)
                {
                    _context.Remove<Employees>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Employee Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public Employees GetEmployeeDetailsById(int empId)
        {
            Employees emp;
            try
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                emp = _context.Find<Employees>(empId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            catch (Exception)
            {
                throw;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return emp;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        public List<Employees> GetEmployeesList()
        {
            List<Employees> empList;
            try
            {
                empList = _context.Set<Employees>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public ResponseModel SaveEmployee(Employees employeeModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employees _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
                if (_temp != null)
                {
                    _temp.Designation = employeeModel.Designation;
                    _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
                    _temp.EmployeeLastName = employeeModel.EmployeeLastName;
                    _temp.Salary = employeeModel.Salary;
                    _context.Update<Employees>(_temp);
                    model.Messsage = "Employee Update Successfully";
                }
                else
                {
                    _context.Add<Employees>(employeeModel);
                    model.Messsage = "Employee Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }

}
