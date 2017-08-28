using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Prompts
{
    public abstract class Prompt<T, R> 
        where T : Prompt<T, R> 
        where R : PromptResult
    {
        public List<string> Message { get; set; } = new List<string>();

        public Prompt()
        {
        }

        public abstract R GetResponse();

        protected void Decorate()
        {
            Console.WriteLine();
            this.PrintMessage();
        }

        public T WithMessage(string message)
        {
            this.Message.Clear();
            this.Message.Add(message);

            return (T)this;
        }

        public T WithMessage(string[] message)
        {
            this.Message.Clear();
            this.Message.AddRange(message);

            return (T)this;
        }

        private void PrintMessage()
        {
            this.Message.ForEach(m => Console.WriteLine(m));
        }
    }
}
