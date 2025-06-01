namespace ZAlert.Api.Domain.Entity
{
    using System.Collections.Generic;
    using ZAlert.Api.Domain.Exceptions;

    public class Usuario
    {
        public int IdUsu { get; private set; }
        public string NmUsu { get; private set; }
        public string EmailUsu { get; private set; }
        public string SenhaUsu { get; private set; }
        public List<Dependente> Dependentes { get; private set; }

        private Usuario(string nmUsu, string emailUsu, string senhaUsu)
        {
            NmUsu = nmUsu?.Length > 60
                ? throw new DomainException("Nome deve ter no máximo 60 caracteres")
                : nmUsu ?? throw new DomainException("Nome é obrigatório");

            EmailUsu = emailUsu?.Length > 100
                ? throw new DomainException("Email deve ter no máximo 100 caracteres")
                : emailUsu ?? throw new DomainException("Email é obrigatório");

            SenhaUsu = senhaUsu?.Length > 100
                ? throw new DomainException("Senha deve ter no máximo 100 caracteres")
                : senhaUsu ?? throw new DomainException("Senha é obrigatória");

            Dependentes = new List<Dependente>();
        }

        internal static Usuario Create(string nmUsu, string emailUsu, string senhaUsu)
        {
            return new Usuario(nmUsu, emailUsu, senhaUsu);
        }

        public Usuario()
        {
            Dependentes = new List<Dependente>();
        }
    }
}
