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

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataFinalizacao { get; set; }
    }
}