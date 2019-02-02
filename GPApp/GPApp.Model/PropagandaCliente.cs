﻿using System;

namespace GPApp.Model
{
    public class PropagandaCliente : BaseModel
    {
        public Guid ClienteId { get; set; }
        public Guid PropagandaId { get; set; }
        public string ChaveCliente { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}
