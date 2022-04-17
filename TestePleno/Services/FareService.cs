using System;
using System.Collections.Generic;
using System.Linq;
using TestePleno.Entities;
using TestePleno.Repositories;

namespace TestePleno.Services
{
    public class FareService
    {
        private readonly Repository _repository = new();

        public Fare GetFareValidate(decimal value,string code)
        {
            var fares = _repository.GetAll<Fare>();
            var selectedFare = fares.FirstOrDefault(f => f.Value == value && f.Operator.Code == code && f.Status == 1);
            return selectedFare != null && selectedFare.CreateOn.AddMonths(6) > DateTime.Now ? selectedFare : null;
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }

        public void Create(Fare insertingFare)
        {
            _repository.Insert(insertingFare);
        }

        public void Update(Fare updatingFare)
        {
            _repository.Update(updatingFare);
        }
    }
}