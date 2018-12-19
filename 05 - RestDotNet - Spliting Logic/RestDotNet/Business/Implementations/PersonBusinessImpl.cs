using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestDotNet.Model;
using RestDotNet.Model.Context;
using RestDotNet.Repository;

namespace RestDotNet.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Person Create(Person person)
        {
            // Aqui, caso necessario, vao as regras de nogocios, validações, etc
            return _repository.Create(person);
        }

        // Metodo responsavel por retornar uma pessoa
        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        // Método responsável por retornar todas as pessoas
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        // Método responsável por atualizar uma pessoa
        public Person Update(Person person)
        {
            // Aqui, caso necessario, vao as regras de nogocios, validações, etc
            return _repository.Update(person);
        }

        // Método responsavel por deletar
        // uma pessoa a partir de um ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
