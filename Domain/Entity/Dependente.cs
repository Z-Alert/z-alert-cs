namespace ZAlert.Api.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ZAlert.Api.Domain.Exceptions;

    public class Dependente
    {
        [Key]
        public int IdDepen { get; private set; }

        public string NmDepen { get; private set; }
        public string Tipo { get; private set; }
        public int IdadeDepen { get; private set; }
        public Usuario Usuario { get; private set; }

        public List<Alerta> Alertas { get; private set; } = new();
        public List<Localizacao> Localizacoes { get; private set; } = new();
        public Dispositivo? Dispositivo { get; private set; }

        private Dependente(string nmDepen, string tipo, int idadeDepen, Usuario usuario)
        {
            NmDepen = string.IsNullOrWhiteSpace(nmDepen) || nmDepen.Length > 100
                ? throw new DomainException("Nome do dependente � obrigat�rio e deve ter at� 100 caracteres")
                : nmDepen;

            Tipo = string.IsNullOrWhiteSpace(tipo) || tipo.Length > 30
                ? throw new DomainException("Tipo do dependente � obrigat�rio e deve ter at� 30 caracteres")
                : tipo;

            IdadeDepen = idadeDepen >= 0 ? idadeDepen : throw new DomainException("Idade inv�lida");
            Usuario = usuario ?? throw new DomainException("Usu�rio � obrigat�rio");
        }

        internal static Dependente Create(string nmDepen, string tipo, int idadeDepen, Usuario usuario)
        {
            return new Dependente(nmDepen, tipo, idadeDepen, usuario);
        }

        public Dependente() { }

        public void SetNmDepen(string nome)
        {
            NmDepen = string.IsNullOrWhiteSpace(nome) || nome.Length > 100
                ? throw new DomainException("Nome inv�lido") : nome;
        }

        public void SetTipo(string tipo)
        {
            Tipo = string.IsNullOrWhiteSpace(tipo) || tipo.Length > 30
                ? throw new DomainException("Tipo inv�lido") : tipo;
        }

        public void SetIdadeDepen(int idade)
        {
            IdadeDepen = idade >= 0 ? idade : throw new DomainException("Idade inv�lida");
        }

        public void SetUsuario(Usuario usuario)
        {
            Usuario = usuario ?? throw new DomainException("Usu�rio � obrigat�rio");
        }
    }
}