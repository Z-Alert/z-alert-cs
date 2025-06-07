namespace ZAlert.Api.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ZAlert.Api.Domain.Exceptions;

    public class Localizacao
    {
        [Key]
        public int IdLocali { get; private set; }

        public decimal LatLocali { get; private set; }
        public decimal LngLocali { get; private set; }
        public DateTime DataHora { get; private set; }
        public Dependente Dependente { get; private set; }

        private Localizacao(decimal lat, decimal lng, DateTime dataHora, Dependente dependente)
        {
            if (lat < -90 || lat > 90) throw new DomainException("Latitude inválida");
            if (lng < -180 || lng > 180) throw new DomainException("Longitude inválida");

            LatLocali = lat;
            LngLocali = lng;
            DataHora = dataHora;
            Dependente = dependente ?? throw new DomainException("Dependente é obrigatório");
        }

        internal static Localizacao Create(decimal lat, decimal lng, DateTime dataHora, Dependente dependente)
        {
            return new Localizacao(lat, lng, dataHora, dependente);
        }

        public Localizacao() { }

        public void SetLatLocali(decimal lat)
        {
            if (lat < -90 || lat > 90) throw new DomainException("Latitude inválida");
            LatLocali = lat;
        }

        public void SetLngLocali(decimal lng)
        {
            if (lng < -180 || lng > 180) throw new DomainException("Longitude inválida");
            LngLocali = lng;
        }

        public void SetDependente(Dependente dependente)
        {
            Dependente = dependente ?? throw new DomainException("Dependente é obrigatório");
        }

    }
}