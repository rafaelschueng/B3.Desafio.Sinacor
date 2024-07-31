namespace B3.Desafio.Sinacor.Controllers.Response
{
    public class CdiResponseDto { 
        public decimal InitialValue {get; init;}
        public required IEnumerable<Incomes> Incomes {get; init;}
    }

}