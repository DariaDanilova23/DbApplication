using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DbApplication
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Departments Department { get; set; }
    }
}
