﻿namespace EmployeeManagement.Dto
{
    public class ViewEmployeeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }

}
