using System;
using TestePleno.Entities.Base;

namespace TestePleno.Entities
{
    public class Operator : IModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
    }
}