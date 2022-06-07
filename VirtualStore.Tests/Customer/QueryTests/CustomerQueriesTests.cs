using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualStore.Domain.Customer.Entities;
using VirtualStore.Domain.Customer.Queries;

namespace VirtualStore.Tests.Tests.QueriesTests
{
    [TestClass]
    public class CustomerQueryTests
    {
        private List<VirtualStore.Domain.Customer.Entities.Customer> _items;

        public CustomerQueryTests()
        {
            _items = new List<VirtualStore.Domain.Customer.Entities.Customer>();

            _items.Add(new VirtualStore.Domain.Customer.Entities.Customer("Mario", "Augusto", DateTime.Now,
        "0869473115", "01333009518", "Bahia", "Salvador", "Massaranduba", "40435-070", "Rua Carlos Lopes, Número 49"));

            _items.Add(new VirtualStore.Domain.Customer.Entities.Customer("Rebeca", "Rodrigues", DateTime.Now,
        "0679473115", "01238009518", "Bahia", "Salvador", "Massaranduba", "40435-070", "Rua Carlos Lopes, Número 49"));

        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_todos_os_clientes_ativos()
        {
            var result = _items.AsQueryable().Where(CustomerQueries.GetAllActives());
            Assert.AreEqual(2, result.Count());
        }
    }
}