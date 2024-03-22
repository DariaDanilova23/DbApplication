using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DbApplication
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Employees> Employees { get; set; }
    }
}
