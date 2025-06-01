namespace ZAlert.Api.Domain.Entity
{
    using System;
    using ZAlert.Api.Domain.Exceptions;

    public class Localizacao
    {
        public int IdLocali { get; private set; }
        public double LatLocali { get; private set; }
        public double LngLocali { get; private set; }
        public DateTime DataHora { get; private set; }
        public Dependente Dependente { get; private set; }

        private Localizacao(double latLocali, double lngLocali, DateTime dataHora, Dependente dependente)
        {
            LatLocali = latLocali;
            LngLocali = lngLocali;
            DataHora = dataHora;
            Dependente = dependente ?? throw new DomainException("Dependente é obrigatório");
        }

        internal static Localizacao Create(double latLocali, double lngLocali, DateTime dataHora, Dependente dependente)
        {
            return new Localizacao(latLocali, lngLocali, dataHora, dependente);
        }

        public Localizacao() { }
    }
}
