using System.ComponentModel.DataAnnotations;
namespace EFMigrationsDemo.Data
{
    public  class Author
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}