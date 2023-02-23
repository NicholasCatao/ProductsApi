using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int Role { get; set; }

    }
}
