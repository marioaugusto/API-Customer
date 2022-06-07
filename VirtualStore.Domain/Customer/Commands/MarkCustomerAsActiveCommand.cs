using System;
using Flunt.Notifications;
using Flunt.Validations;
using VirtualStore.Domain.Customer.Commands.Contracts;
using VirtualStore.Shared.Commands.Contracts;

namespace VirtualStore.Domain.Customer.Commands;

    public class MarkCustomerAsActiveCommand : Notifiable, ICommand
    {
        public MarkCustomerAsActiveCommand() { }

        public MarkCustomerAsActiveCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User, 3, "User", "Usuário inválido!")
            );
        }
    }