using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GPApp.Wrapper
{
    public partial class ProdutoWrapper
    {
        private const string OBRIGATORIO = "Campo obrigatório";

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Codigo))
            {
                yield return new ValidationResult(OBRIGATORIO, new[] { nameof(Codigo) });
            }

            if (string.IsNullOrEmpty(Nome))
            {
                yield return new ValidationResult(OBRIGATORIO, new[] { nameof(Nome) });
            }

            if (string.IsNullOrEmpty(Descricao))
            {
                yield return new ValidationResult(OBRIGATORIO, new[] { nameof(Descricao) });
            }

            if (Custo == 0)
            {
                yield return new ValidationResult("Deve ser maior que zero", new[] { nameof(Custo) });
            }
            else if (Preco < Custo)
            {
                yield return new ValidationResult("Deve ser menor ou igual ao preco", new[] { nameof(Preco) });
            }

            if (Preco == 0)
            {
                yield return new ValidationResult("Deve ser maior que zero" , new[] { nameof(Preco) });
            } else if (Custo > Preco)
            {
                yield return new ValidationResult("Deve ser maior que o custo", new[] { nameof(Preco) });
            }

            if (PrecoPromocional >= Preco)
            {
                yield return new ValidationResult("Deve ser menor que o preço", new[] { nameof(PrecoPromocional) });
            }
        }
    }
}
