using Xunit;
using SistemaBancarioConsole;

namespace SistemaBancarioConsole.Tests
{
    public class ContaBancariaTests
    {
        // Teste corrigido para criar uma ContaBancaria
        [Fact]
        public void TesteCriacaoContaBancaria()
        {
            // Parâmetros ajustados para o construtor
            var conta = new ContaBancaria("Titular Teste", 1000m, "Conta Corrente");

            Assert.NotNull(conta);
            Assert.Equal("Titular Teste", conta.Titular);
            Assert.Equal(1000m, conta.Saldo);
            Assert.Equal("Conta Corrente", conta.TipoConta);
        }

        // Outro teste corrigido
        [Fact]
        public void TesteDepositoConta()
        {
            // Parâmetros ajustados para o construtor
            var conta = new ContaBancaria("Titular Teste", 500m, "Conta Poupança");

            conta.Depositar(200m);

            Assert.Equal(700m, conta.Saldo);
        }
    }
}
