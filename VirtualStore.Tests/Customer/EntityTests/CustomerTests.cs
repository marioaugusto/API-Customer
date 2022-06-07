
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualStore.Domain.Customer.Entities;

namespace VirtualStore.Tests.EntityTests;

[TestClass]

public class CustomerTests
{

    private  readonly Customer _validCustomer  = new Customer("Mario", "Augusto", DateTime.Now,
        "0869473115", "01333009518", "Bahia", "Salvador", "Massaranduba", "40435-070", "Rua Carlos Lopes, Número 49");

    [TestMethod]

    public void Dado_um_novo_cliente_o_mesmo_precisa_estar_ativo()
    {      
        Assert.AreEqual(_validCustomer.Active, true);
    }
}