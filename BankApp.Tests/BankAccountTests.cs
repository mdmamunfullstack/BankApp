using System;
using Xunit;
using BankApp;

namespace BankApp.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void NewAccount_HasZeroBalance()
        {
            // Arrange
            var account = new BankAccount();

            // Act
            var balance = account.Balance;

            // Assert
            Assert.Equal(0m, balance);
        }

        [Fact]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            // Arrange
            var account = new BankAccount();

            // Act
            account.Deposit(100m);

            // Assert
            Assert.Equal(100m, account.Balance);
        }

        [Fact]
        public void Deposit_MultipleAmounts_AccumulatesBalance()
        {
            // Arrange
            var account = new BankAccount();

            // Act
            account.Deposit(50m);
            account.Deposit(25.5m);

            // Assert
            Assert.Equal(75.5m, account.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10.5)]
        public void Deposit_NonPositiveAmount_ThrowsArgumentException(decimal amount)
        {
            // Arrange
            var account = new BankAccount();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Deposit(amount));
        }

        [Fact]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(100m);

            // Act
            account.Withdraw(40m);

            // Assert
            Assert.Equal(60m, account.Balance);
        }

        [Fact]
        public void Withdraw_ExactBalance_SetsBalanceToZero()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(30m);

            // Act
            account.Withdraw(30m);

            // Assert
            Assert.Equal(0m, account.Balance);
        }

        [Fact]
        public void Withdraw_MoreThanBalance_ThrowsInvalidOperationException()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(20m);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(30m));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void Withdraw_NonPositiveAmount_ThrowsArgumentException(decimal amount)
        {
            // Arrange
            var account = new BankAccount();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => account.Withdraw(amount));
        }

        [Fact]
        public void Sequence_DepositAndWithdraw_MaintainsCorrectBalance()
        {
            // Arrange
            var account = new BankAccount();

            // Act
            account.Deposit(100m);
            account.Withdraw(30m);
            account.Deposit(10m);
            account.Withdraw(20m);

            // Assert
            Assert.Equal(60m, account.Balance);
        }

        [Fact]
        public void Withdraw_DecimalFraction_WorksCorrectly()
        {
            // Arrange
            var account = new BankAccount();
            account.Deposit(10.75m);

            // Act
            account.Withdraw(0.75m);

            // Assert
            Assert.Equal(10.00m, account.Balance);
        }
    }
}
