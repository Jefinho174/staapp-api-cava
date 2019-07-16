using System;
using StaminaApp.Core.Entidades;
using StaminaApp.Domain.Enum;

namespace StaminaApp.Domain.Inventario.Entidades
{
    public class Manutencao : Entidade
    {
        public Item Item { get; private set; }
        public OrdemServico OrdemServico { get; private set; }
        public EStatusManutencao Status { get; private set; }
    }
}