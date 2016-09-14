using Poc_HangFire.Repositories;
using System;

namespace Poc_HangFire.Models
{
    public class MyJob : IJob
    {
        private IPocRepository _repository;

        public MyJob(IPocRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string teste)
        {
            Console.WriteLine("Teste");
            _repository.Salvar(DateTime.Now, teste);
        }
    }
}