using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hello.Models;

public class Atividade
{
    public string Descricao { get; set; }
    public float Dificuldade { get; set; }
    public string Tipo { get; set; }
    public int Participantes { get; set; }
    public string Link { get; set; }

    public Atividade(Resposta resposta, string tipo)
    {
        this.Descricao = resposta.Activity;
        this.Dificuldade = resposta.Accessibility;
        this.Tipo = tipo;
        this.Participantes = resposta.Participants;
        this.Link = resposta.Link ?? "";
    }
}
