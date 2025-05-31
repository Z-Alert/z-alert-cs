namespace ZAlert.Api.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using ZAlert.Api.Domain.Exceptions;

    public class Dependente
    {
        public int IdDepen { get; private set; }
        public string NmDepen { get; private set; }
        public string Tipo { get; private set; }
        public int IdadeDepen { get; private set; }

        public Usuario Usuario { get; private set; }
        public List<Alerta> Alertas { get; private set; }
        public List<Localizacao> Localizacoes { get; private set; }
        public Dispositivo Dispositivo { get; private set; }

        private Dependente(string nmDepen, string tipo, int idadeDepen, Usuario usuario)
        {
            NmDepen = nmDepen?.Length > 100
                ? throw new DomainException("Nome do dependente deve ter no máximo 100 caracteres")
                : nmDepen ?? throw new DomainException("Nome do dependente é obrigatório");

            Tipo = tipo?.Length > 30
                ? throw new DomainException("Tipo deve ter no máximo 30 caracteres")
                : tipo ?? throw new DomainException("Tipo é obrigatório");

            IdadeDepen = idadeDepen;
            Usuario = usuario ?? throw new DomainException("Usuário é obrigatório");

            Alertas = new List<Alerta>();
            Localizacoes = new List<Localizacao>();
        }

        internal static Dependente Create(string nmDepen, string tipo, int idadeDepen, Usuario usuario)
        {
            return new Dependente(nmDepen, tipo, idadeDepen, usuario);
        }

        public Dependente()
        {
            Alertas = new List<Alerta>();
            Localizacoes = new List<Localizacao>();
        }
    }
}
