namespace Hello.Models;

public class Serie
{
    public string nome { get; set; }
    public int interesse { get; set; }

    public Serie(string nome, int interesse)
    {
        this.nome = nome;
        this.interesse = interesse;
    }
}
