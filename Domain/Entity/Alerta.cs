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
                ? throw new DomainException("Localiza��o deve ter no m�ximo 255 caracteres")
                : localizacao ?? throw new DomainException("Localiza��o � obrigat�ria");

            SttsAlerta = sttsAlerta?.Length > 50
                ? throw new DomainException("Status deve ter no m�ximo 50 caracteres")
                : sttsAlerta ?? throw new DomainException("Status � obrigat�rio");

            Dependente = dependente ?? throw new DomainException("Dependente � obrigat�rio");
        }

        internal static Alerta Create(DateTime dataHora, string localizacao, string sttsAlerta, Dependente dependente)
        {
            return new Alerta(dataHora, localizacao, sttsAlerta, dependente);
        }

        public Alerta() { }
    }
}