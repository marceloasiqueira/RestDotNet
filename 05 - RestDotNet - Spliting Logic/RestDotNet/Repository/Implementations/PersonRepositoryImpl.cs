﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestDotNet.Model;
using RestDotNet.Model.Context;

namespace RestDotNet.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        // Metodo responsável por criar uma nova pessoa
        // nesse momento adicionamos o objeto ao contexto
        // e finalmente salvamos as mudanças no contexto
        // na base de dados
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        // Metodo responsavel por retornar uma pessoa
        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Método responsável por retornar todas as pessoas
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        // Método responsável por atualizar uma pessoa
        public Person Update(Person person)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exists(person.Id)) return new Person();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return person;
        }

        // Método responsavel por deletar
        // uma pessoa a partir de um ID
        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
