using ProdutosApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Application.DTO.DTO
{
    public record struct UserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
