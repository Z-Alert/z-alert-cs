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
                ? throw new DomainException("Nome do dependente é obrigatório e deve ter até 100 caracteres")
                : nmDepen;

            Tipo = string.IsNullOrWhiteSpace(tipo) || tipo.Length > 30
                ? throw new DomainException("Tipo do dependente é obrigatório e deve ter até 30 caracteres")
                : tipo;

            IdadeDepen = idadeDepen >= 0 ? idadeDepen : throw new DomainException("Idade inválida");
            Usuario = usuario ?? throw new DomainException("Usuário é obrigatório");
        }

        internal static Dependente Create(string nmDepen, string tipo, int idadeDepen, Usuario usuario)
        {
            return new Dependente(nmDepen, tipo, idadeDepen, usuario);
        }

        public Dependente() { }

        public void SetNmDepen(string nome)
        {
            NmDepen = string.IsNullOrWhiteSpace(nome) || nome.Length > 100
                ? throw new DomainException("Nome inválido") : nome;
        }

        public void SetTipo(string tipo)
        {
            Tipo = string.IsNullOrWhiteSpace(tipo) || tipo.Length > 30
                ? throw new DomainException("Tipo inválido") : tipo;
        }

        public void SetIdadeDepen(int idade)
        {
            IdadeDepen = idade >= 0 ? idade : throw new DomainException("Idade inválida");
        }

        public void SetUsuario(Usuario usuario)
        {
            Usuario = usuario ?? throw new DomainException("Usuário é obrigatório");
        }
    }
}