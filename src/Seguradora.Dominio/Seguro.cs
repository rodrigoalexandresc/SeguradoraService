using System;
using System.Collections.Generic;
using System.Linq;

namespace Seguradora.Dominio
{
    public class Seguro
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<int> IdsCoberturas { get; set; }
        public IEnumerable<Cobertura> Coberturas { get; set; }

        public int CalcularIdadeSegurado()
        {
            var hoje = DateTime.Now;
            var idade = hoje.Year - Nascimento.Year;
            if (Nascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }

        public decimal CalcularTotalCoberturas()
        {
            return Coberturas?.Sum(c => c.Valor) ?? 0m;
        }
    }
}
