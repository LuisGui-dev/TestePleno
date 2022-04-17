using System;
using TestePleno.Entities.Base;

namespace TestePleno.Entities
{
    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateOn { get; set; }
        public Guid OperatorId { get; set; }
        public Operator Operator { get; set; }

        public Fare()
        {
            CreateOn = DateTime.Now;
            Status = 1;
        }

        public Fare(Guid id, decimal value, Guid operatorId, Operator @operator) : this()
        {
            Id = id;
            Value = value;
            OperatorId = operatorId;
            Operator = @operator;
        }

    }
}