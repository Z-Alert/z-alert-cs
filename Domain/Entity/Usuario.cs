namespace ZAlert.Api.Domain.Entity
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ZAlert.Api.Domain.Exceptions;

    public enum UserRole { ADMIN, USER }

    public class Usuario
    {
        [Key]
        public int IdUsu { get; private set; }

        public string NmUsu { get; private set; }
        public string EmailUsu { get; private set; }
        public string SenhaUsu { get; private set; }
        public UserRole Role { get; private set; } = UserRole.USER;
        public List<Dependente> Dependentes { get; private set; } = new();

        private Usuario(string nome, string email, string senha, UserRole role)
        {
            NmUsu = string.IsNullOrWhiteSpace(nome) || nome.Length > 60
                ? throw new DomainException("Nome inválido") : nome;

            EmailUsu = string.IsNullOrWhiteSpace(email) || email.Length > 100
                ? throw new DomainException("Email inválido") : email;

            SenhaUsu = string.IsNullOrWhiteSpace(senha) || senha.Length > 100
                ? throw new DomainException("Senha inválida") : senha;

            Role = role;
        }

        internal static Usuario Create(string nome, string email, string senha, UserRole role)
        {
            return new Usuario(nome, email, senha, role);
        }

        public Usuario() { }

        public void SetNmUsu(string nome)
        {
            NmUsu = string.IsNullOrWhiteSpace(nome) || nome.Length > 60
                ? throw new DomainException("Nome inválido") : nome;
        }

        public void SetEmailUsu(string email)
        {
            EmailUsu = string.IsNullOrWhiteSpace(email) || email.Length > 100
                ? throw new DomainException("Email inválido") : email;
        }

        public void SetSenhaUsu(string senha)
        {
            SenhaUsu = string.IsNullOrWhiteSpace(senha) || senha.Length > 100
                ? throw new DomainException("Senha inválida") : senha;
        }

    }
}