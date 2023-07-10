using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Models;

public class Contract
{
    public Contract()
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = 0;
        this.TokenId = "000000";
        this.Pago = false;
    }

    public Contract(string TokenID, double Valor)
    {
        this.DataCriacao = DateTime.Now;
        this.Valor = Valor;
        this.TokenId = TokenID;
        this.Pago = false;
    }

    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public string TokenId { get; set; }
    public double Valor { get; set; }
    public bool Pago { get; set; }
}