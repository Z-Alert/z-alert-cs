namespace ZAlert.Api.Domain.Entity
{
    using ZAlert.Api.Domain.Exceptions;

    public class Dispositivo
    {
        public int IdDisposit { get; private set; }
        public string TipoDisposit { get; private set; }
        public string StatusDisposit { get; private set; }
        public Dependente Dependente { get; private set; }

        private Dispositivo(string tipoDisposit, string statusDisposit, Dependente dependente)
        {
            TipoDisposit = tipoDisposit?.Length > 50
                ? throw new DomainException("Tipo do dispositivo deve ter no máximo 50 caracteres")
                : tipoDisposit ?? throw new DomainException("Tipo do dispositivo é obrigatório");

            StatusDisposit = statusDisposit?.Length > 20
                ? throw new DomainException("Status do dispositivo deve ter no máximo 20 caracteres")
                : statusDisposit ?? throw new DomainException("Status do dispositivo é obrigatório");

            Dependente = dependente ?? throw new DomainException("Dependente é obrigatório");
        }

        internal static Dispositivo Create(string tipoDisposit, string statusDisposit, Dependente dependente)
        {
            return new Dispositivo(tipoDisposit, statusDisposit, dependente);
        }

        public Dispositivo() { }
    }
}
