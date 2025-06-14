﻿namespace ZAlert.Api.Domain.Entity
{
    using ZAlert.Api.Domain.Exceptions;
    using System.ComponentModel.DataAnnotations;

    public class Dispositivo
    {
        [Key]
        public int IdDisposit { get; private set; }

        public string TipoDisposit { get; private set; }
        public string StatusDisposit { get; private set; }
        public Dependente Dependente { get; private set; }

        private Dispositivo(string tipoDisposit, string statusDisposit, Dependente dependente)
        {
            TipoDisposit = string.IsNullOrWhiteSpace(tipoDisposit) || tipoDisposit.Length > 50
                ? throw new DomainException("Tipo de dispositivo inválido")
                : tipoDisposit;

            StatusDisposit = string.IsNullOrWhiteSpace(statusDisposit) || statusDisposit.Length > 20
                ? throw new DomainException("Status de dispositivo inválido")
                : statusDisposit;

            Dependente = dependente ?? throw new DomainException("Dependente é obrigatório");
        }

        internal static Dispositivo Create(string tipoDisposit, string statusDisposit, Dependente dependente)
        {
            return new Dispositivo(tipoDisposit, statusDisposit, dependente);
        }

        public Dispositivo() { }

        public void SetTipoDisposit(string tipo)
        {
            TipoDisposit = string.IsNullOrWhiteSpace(tipo) || tipo.Length > 50
                ? throw new DomainException("Tipo de dispositivo inválido") : tipo;
        }

        public void SetStatusDisposit(string status)
        {
            StatusDisposit = string.IsNullOrWhiteSpace(status) || status.Length > 20
                ? throw new DomainException("Status de dispositivo inválido") : status;
        }

        public void SetDependente(Dependente dependente)
        {
            Dependente = dependente ?? throw new DomainException("Dependente é obrigatório");
        }

    }
}