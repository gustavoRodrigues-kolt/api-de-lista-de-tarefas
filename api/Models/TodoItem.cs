using System;

namespace api.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string DataEmtrega { get; set; }
        public bool Completa { get; set; }
    }
}