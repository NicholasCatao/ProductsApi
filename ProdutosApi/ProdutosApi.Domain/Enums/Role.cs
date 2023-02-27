using System.ComponentModel;

namespace ProdutosApi.Domain.Enums
{
    public enum Role
    {

        [Description("Admin")]
        Admin  = 0,
        [Description("User")]
        User = 1
    }
}
