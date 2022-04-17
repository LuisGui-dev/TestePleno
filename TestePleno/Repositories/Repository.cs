using System;
using System.Collections.Generic;
using System.Linq;
using TestePleno.Entities;
using TestePleno.Entities.Base;

namespace TestePleno.Repositories
{
    public class Repository
    {
        private readonly List<IModel> _fakeDatabase = new();

        public Repository()
        {
            var operator1 = new Operator
            {
                Id = Guid.NewGuid(),
                Code = "OP01"
            };
            _fakeDatabase.Add(operator1);

            var operator2 = new Operator
            {
                Id = Guid.NewGuid(),
                Code = "OP02"
            };
            _fakeDatabase.Add(operator2);

            var operator3 = new Operator
            {
                Id = Guid.NewGuid(),
                Code = "OP03"
            };
            _fakeDatabase.Add(operator3);

            var fare1 = new Fare
            {
                Id = Guid.NewGuid(),
                Value = new decimal(2.49),
                Operator = operator3,
                OperatorId = operator3.Id
            };
            _fakeDatabase.Add(fare1);
        }

        public void Insert(IModel model)
        {
            if (model.Id == Guid.Empty)
                throw new Exception("Não é possível salvar um registro com Id não preenchido");

            var modelAlreadyExists = _fakeDatabase.Any(savedModel => savedModel.Id == model.Id);
            if (modelAlreadyExists)
                throw new Exception($"Já existe um registro para a entidade '{model.GetType().Name}' com o Id '{model.Id}'");

            _fakeDatabase.Add(model);
        }

        public void Update(IModel model)
        {
            var updatingModel = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == model.Id);
            if (updatingModel == null)
                throw new Exception($"Não há registros para a entidade '{model.GetType().Name}' com Id '{model.Id}'");

            _fakeDatabase.Remove(updatingModel);
            _fakeDatabase.Add(model);
        }

        public T GetById<T>(Guid id)
        {
            var model = _fakeDatabase.FirstOrDefault(savedModel => savedModel.Id == id);
            return (T)model;
        }

        public List<T> GetAll<T>()
        {
            var allModels = _fakeDatabase.Where(savedModel => savedModel.GetType().IsAssignableFrom(typeof(T)));
            var convertedModels = allModels.Select(genericModel => (T)genericModel).ToList();
            return convertedModels;
        }
    }
}