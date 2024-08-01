using System.Diagnostics.CodeAnalysis;

namespace B3.Desafio.Sinacor.Controllers.Response
{
    [ExcludeFromCodeCoverage]
    public class CdiResponseDto
    {
        [ExcludeFromCodeCoverage]
        public decimal InitialValue { get; init; }
        [ExcludeFromCodeCoverage]
        public required IEnumerable<Incomes> Incomes { get; init; }
    }

}