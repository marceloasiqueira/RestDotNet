using System;
using System.Collections.Generic;
using System.Threading;
using RestDotNet.Model;

namespace RestDotNet.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        // Contador responsável por gerar um fake ID já 
        // que não estamos acessando nenhum BD
        private volatile int count;
        
        // Metodo responsavel por criar uma nova pessoa
        // Se tivéssemos um BD, esse seria o momento de
        // persistir os dados
        public Person Create(Person person)
        {
            return person;
        }

        // Metodo responsavel por retornar uma pessoa
        // Como não estamos acessando nenhuma base de
        // dados, estamos retornando um mock
        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Mi Nombre",
                LastName = "Aooooo",
                Address = "Brasília - DF",
                Gender = "Male"
            };
        }

        // Método responsavel por deletar
        // uma pessoa a partir de um ID
        public void Delete(long id)
        {
            // A nossa lógica de exclusão virá aqui...
        }

        // Método responsável por retornar todas as
        // pessoas. Mais uma vez, essas informações
        // são mock
        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i< 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação
        // passada
        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person Lastname " + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
