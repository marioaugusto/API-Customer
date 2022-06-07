using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualStore.Domain.Customer.Commands.Contracts;

namespace VirtualStore.Domain.Customer.Tests.CommandTests;

[TestClass]
public class CreateCustomerCommandTests
{
    private readonly CreateCustomerCommand _invalidCommand = new CreateCustomerCommand("", "", DateTime.Now, "", "", "", "", "", "", "");
    
    private readonly CreateCustomerCommand _validCommand = new CreateCustomerCommand("Mario", "Augusto", DateTime.Now,
        "0869473115", "01333009518", "Bahia", "Salvador", "Massaranduba", "40435-070", "Rua Carlos Lopes, Número 49");

    public CreateCustomerCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
        
    }

    [TestMethod]
    public void Dado_um_comando_invalido()
    {
       
        Assert.AreEqual(_invalidCommand.Valid, false);
    }


    [TestMethod]
    public void Dado_um_comando_valido()
    {
       
        Assert.AreEqual(_validCommand.Valid, true);
    }
}


