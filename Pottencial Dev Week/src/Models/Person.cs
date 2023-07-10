using System.Collections.Generic;

namespace src.Models;

public class Person
{
    public Person()
    {
        this.Nome = "dSdASdas";
        this.Idade = 0;
        this.contracts = new List<Contract>();
        this.Ativado = true;
    }

    public Person(string Nome, int Idade, string Cpf)
    {
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf = Cpf;
        this.contracts = new List<Contract>();
        this.Ativado = true;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string? Cpf { get; set; }
    public bool Ativado { get; set; }

    public List<Contract> contracts { get; set; }
}