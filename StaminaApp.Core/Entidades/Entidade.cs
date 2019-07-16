using System;
using Flunt.Notifications;

namespace StaminaApp.Core.Entidades
{
    public class Entidade : Notifiable
    {
        public Entidade()
        {
            DataCriacao = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataFinalizacao { get; private set; }
    }
}