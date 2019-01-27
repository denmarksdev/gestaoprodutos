using System;

namespace GPApp.Model
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public bool Sincronizado { get; set; }
        public DateTimeOffset UltimaAtualizacao { get; set; }
    }
}