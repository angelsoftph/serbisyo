namespace EmployeeManagement.Dto
{
    public class ViewCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; } = 0;
    }
}
