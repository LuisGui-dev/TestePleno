using System;
using TestePleno.Entities;
using TestePleno.Services;

namespace TestePleno.Controller
{
    public class FareController
    {
        private readonly OperatorService _operatorService;
        private readonly FareService _fareService;

        public FareController()
        {
            _fareService = new FareService();
            _operatorService = new OperatorService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            if (selectedOperator == null)
                throw new Exception("Operadora não encontrada!");

            var selectedFare = _fareService.GetFareValidate(fare.Value, operatorCode);
            if (selectedFare != null)
                throw new Exception("A Operadora já contém uma tarifa com esse valor!");

            fare.Id = Guid.NewGuid();
            fare.OperatorId = selectedOperator.Id;
            fare.Operator = selectedOperator;

            _fareService.Create(fare);
        }
    }
}