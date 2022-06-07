using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualStore.Domain.Customer.Commands.Contracts;
using VirtualStore.Domain.Customer.Handlers;
using VirtualStore.Domain.Customer.Tests.Repositories;
using VirtualStore.Shared;

namespace VirtualStore.Domain.Customer.Tests.HabdlerTests;

[TestClass]
public class CreateCustomerHandlerTests
{

    private readonly CreateCustomerCommand _invalidCommand = new CreateCustomerCommand("", "", DateTime.Now, "", "", "", "", "", "", "");

    private readonly CreateCustomerCommand _validCommand = new CreateCustomerCommand("Mario", "Augusto", DateTime.Now,
        "0869473115", "01333009518", "Bahia", "Salvador", "Massaranduba", "40435-070", "Rua Carlos Lopes, Número 49");

    private readonly CustomerHandler _handler = new CustomerHandler(new FakeCustomerRepository());

    private GenericCommandResult _result = new GenericCommandResult();

    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_o_cliente()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(_result.Success, true);
    }
}


