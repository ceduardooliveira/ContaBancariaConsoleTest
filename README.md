# 💳 Sistema Bancário Console

Este é um projeto simples de um sistema bancário criado em C# usando .NET Framework, com aplicação de *5 padrões de projeto (Design Patterns)*. O objetivo é demonstrar a implementação prática de conceitos fundamentais de arquitetura de software.

Foram implementados *testes unitários* utilizando a ferramenta *xUnit* para validar funcionalidades do sistema bancário, incluindo:

- *Teste de Criação de Conta Bancária: Verifica se os parâmetros de **titular, **saldo* e *tipo de conta* estão sendo corretamente atribuídos na criação da conta.
- *Teste de Depósito em Conta Bancária*: Valida se o saldo da conta é atualizado corretamente após um depósito.


## O que foi feito 🔨

Foram implementados *testes unitários* utilizando a ferramenta *xUnit* para validar funcionalidades no sistema bancário.

### Objetivo:
- *Teste de Criação de Conta Bancária: Verificar se os parâmetros de **titular, **saldo* e *tipo de conta* estão sendo corretamente atribuídos na criação da conta.
- *Teste de Depósito em Conta*: Validar se o saldo da conta é atualizado corretamente após um depósito.

---

## Como executar ⚙️

### Passo 1: Instalar Pacotes NuGet

Antes de rodar os testes, é necessário instalar os pacotes *xUnit* e o runner para Visual Studio. Execute os seguintes comandos:

bash
dotnet add package xunit
dotnet add package xunit.runner.visualstudio


### Passo 2: Criar o Projeto de Testes

Crie um novo projeto de testes em seu repositório. Execute o seguinte comando:


dotnet new xunit -n SistemaBancarioConsole.Tests


### Passo 3: Adicionar Referência ao Projeto Principal

Agora, adicione uma referência ao projeto principal para que os testes possam acessar as classes do sistema bancário:

dotnet add SistemaBancarioConsole.Tests reference SistemaBancarioConsole


### Passo 4: Rodar os Testes
Após configurar os testes, execute-os com o seguinte comando:


dotnet test


### Quais foram os testes implementados 🧪

Teste 1: Criação de Conta Bancária ✅
Objetivo: Verificar se os parâmetros de titular, saldo e tipo de conta são corretamente atribuídos ao criar uma nova conta bancária.

Código do Teste:


[Fact]
public void TesteCriacaoContaBancaria()
{
    // Parâmetros ajustados para o construtor
    var conta = new ContaBancaria("Titular Teste", 1000m, "Conta Corrente");

    // Verificações
    Assert.NotNull(conta); // A conta não deve ser nula
    Assert.Equal("Titular Teste", conta.Titular); // Verifica o titular
    Assert.Equal(1000m, conta.Saldo); // Verifica o saldo
    Assert.Equal("Conta Corrente", conta.TipoConta); // Verifica o tipo de conta
}



#### Explicação:

O teste verifica se, ao criar uma nova conta com o titular, saldo e tipo definidos, os valores são corretamente atribuídos à conta.
Utiliza-se o método Assert.Equal para garantir que os valores são os esperados e Assert.NotNull para garantir que a conta foi criada corretamente.


Teste 2: Depósito em Conta Bancária ✅
Objetivo: Validar se o saldo da conta é atualizado corretamente após um depósito.

Código do Teste:


[Fact]
public void TesteDepositoConta()
{
    // Parâmetros ajustados para o construtor
    var conta = new ContaBancaria("Titular Teste", 500m, "Conta Poupança");

    // Realiza o depósito
    conta.Depositar(200m);

    // Verificações
    Assert.Equal(700m, conta.Saldo); // Verifica se o saldo foi atualizado corretamente
}



### Explicação:

O teste realiza um depósito de 200 na conta, que já tem 500 de saldo.
Após o depósito, o saldo da conta deve ser atualizado para 700.
O método Assert.Equal é utilizado para garantir que o valor esperado de saldo seja igual ao atual.

### Conclusão 🎯

Foram implementados dois testes principais no sistema bancário:

Criação de Conta Bancária: Verifica a correta criação de uma conta com os parâmetros fornecidos.
Depósito em Conta Bancária: Garante que o saldo da conta seja atualizado corretamente após um depósito.
Com a execução desses testes, garantimos que as funcionalidades básicas do sistema bancário estão funcionando corretamente, proporcionando maior confiança na estabilidade do código.


### Nome dos integrantes 🧑

  - Carlos Eduardo Pereira de Oliveira
  - Daniel Marques de Melos Asiático