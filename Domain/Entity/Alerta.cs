namespace ZAlert.Api.Domain.Entity
{
    using System;
    using ZAlert.Api.Domain.Exceptions;

    public class Alerta
    {
        public int IdAlerta { get; private set; }
        public DateTime DataHora { get; private set; }
        public string Localizacao { get; private set; }
        public string SttsAlerta { get; private set; }
        public Dependente Dependente { get; private set; }

        private Alerta(DateTime dataHora, string localizacao, string sttsAlerta, Dependente dependente)
        {
            DataHora = dataHora;
            Localizacao = localizacao?.Length > 255
                ? throw new DomainException("Localização deve ter no máximo 255 caracteres")
                : localizacao ?? throw new DomainException("Localização é obrigatória");

            SttsAlerta = sttsAlerta?.Length > 50
                ? throw new DomainException("Status deve ter no máximo 50 caracteres")
                : sttsAlerta ?? throw new DomainException("Status é obrigatório");

            Dependente = dependente ?? throw new DomainException("Dependente é obrigatório");
        }

        internal static Alerta Create(DateTime dataHora, string localizacao, string sttsAlerta, Dependente dependente)
        {
            return new Alerta(dataHora, localizacao, sttsAlerta, dependente);
        }

        public Alerta() { }
    }
}