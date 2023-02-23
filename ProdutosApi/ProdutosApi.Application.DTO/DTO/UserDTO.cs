using ProdutosApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Application.DTO.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Role Role { get; set; }
    }
}
