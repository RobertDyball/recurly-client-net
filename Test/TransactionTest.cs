﻿using System;
using FluentAssertions;
using Xunit;

namespace Recurly.Test
{
    public class TransactionTest : BaseTest
    {
        [Fact]
        public void LookupTransaction()
        {
            var acct = CreateNewAccountWithBillingInfo();
            var transaction = new Transaction(acct, 5000, "USD");
            transaction.Create();

            var fromService = Transactions.Get(transaction.Uuid);

            transaction.Should().Be(fromService);
        }

        [Fact]
        public void CreateTransactionNewAccount()
        {
            var account = NewAccountWithBillingInfo();
            var transaction = new Transaction(account, 5000, "USD");

            transaction.Create();

            transaction.CreatedAt.Should().NotBe(default(DateTime));
        }

        [Fact]
        public void CreateTransactionExistingAccount()
        {
            var acct = CreateNewAccountWithBillingInfo();
            var transaction = new Transaction(acct.AccountCode, 3000, "USD");

            transaction.Create();

            transaction.CreatedAt.Should().NotBe(default(DateTime));
        }

        [Fact]
        public void CreateTransactionExistingAccountNewBillingInfo()
        {
            var account = new Account(GetUniqueAccountCode())
            {
                FirstName = "John",
                LastName = "Smith"
            };
            account.Create();
            account.BillingInfo = NewBillingInfo(account);
            var transaction = new Transaction(account, 5000, "USD");

            transaction.Create();

            transaction.CreatedAt.Should().NotBe(default(DateTime));
        }

        [Fact]
        public void RefundTransactionFull()
        {
            var acct = NewAccountWithBillingInfo();
            var transaction = new Transaction(acct, 5000, "USD");
            transaction.Create();

            transaction.Refund();

            transaction.Status.Should().Be(Transaction.TransactionState.Voided);
        }

        [Fact]
        public void RefundTransactionPartial()
        {
            var account = NewAccountWithBillingInfo();
            var transaction = new Transaction(account, 5000, "USD");
            transaction.Create();

            transaction.Refund(2500);

            account.GetTransactions().Should().HaveCount(2);
        }

    }
}
