using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hello.Models;

public class Resposta
{
    public string Activity { get; set; }
    public string Type { get; set; }
    public int Participants { get; set; }
    public float Price { get; set; }
    public string Link { get; set; }
    public string Key { get; set; }
    public float Accessibility { get; set; }
    public Resposta(
        string activity,
        string type,
        int participants,
        float price,
        string link,
        string key,
        float accessibility
    ) {
        this.Activity = activity;
        this.Type = type;
        this.Participants = participants;
        this.Price = price;
        this.Link = link;
        this.Key = key;
        this.Accessibility = accessibility;
    }
}
