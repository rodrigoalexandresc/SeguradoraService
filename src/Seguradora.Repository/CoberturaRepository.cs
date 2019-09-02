using Seguradora.Dominio;
using Seguradora.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.Repository
{
    public class CoberturaRepository : ICoberturaRepository
    {
        private IEnumerable<Cobertura> coberturasDataSetCache;
        private IEnumerable<Cobertura> CoberturasDataSet
        {
            get
            {
                if (coberturasDataSetCache == null)
                {
                    coberturasDataSetCache = new List<Cobertura>()
                    {
                        new Cobertura { Id = 1, Nome = "Morte Acidental", Premio = 100, Valor = 50000, Principal = true },
                        new Cobertura { Id = 2, Nome = "Quebra de Ossos", Premio = 30, Valor = 5000, Principal = false },
                        new Cobertura { Id = 3, Nome = "Internacao Hospitalar", Premio = 50, Valor = 10000, Principal = false },
                        new Cobertura { Id = 4, Nome = "Assistencia Funeraria", Premio = 10, Valor = 2500, Principal = false },
                        new Cobertura { Id = 5, Nome = "Invalidez Permanente", Premio = 130, Valor = 90000, Principal = true },
                        new Cobertura { Id = 6, Nome = "Assistencia Odontologia Emergencial", Premio = 10, Valor = 2500, Principal = false },
                        new Cobertura { Id = 7, Nome = "Diária Incapacidade Temporária", Premio = 30, Valor = 5000, Principal = false },
                        new Cobertura { Id = 8, Nome = "Invalidez Funcional", Premio = 80, Valor = 40000, Principal = true },
                        new Cobertura { Id = 9, Nome = "Doenças Graves", Premio = 100, Valor = 50000, Principal = false },
                        new Cobertura { Id = 10, Nome = "Diagnostico de Cancer", Premio = 50, Valor = 10000, Principal = false },
                    };
                }
                return coberturasDataSetCache;
            }
        }

        public async Task<IEnumerable<Cobertura>> Obter(IEnumerable<int> idsCoberturas)
        {
            return CoberturasDataSet.Where(o => idsCoberturas.Contains(o.Id));
        }

        public async Task<IEnumerable<Cobertura>> Obter()
        {
            return CoberturasDataSet;
        }
    }
}
