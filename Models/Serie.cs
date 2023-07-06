using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hello.Models;

public class Serie
{
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Nome { get; set; }

    [Required]
    [Range(-1, 1)]
    public int Interesse { get; set; }

    public Serie(string nome, int interesse)
    {
        this.Nome = nome;
        this.Interesse = interesse;
    }
}
