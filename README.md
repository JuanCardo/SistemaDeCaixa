# Sistema de Caixa
Projeto simples desenvolvido para praticar lógica de programação em C#.

## Objetivo
Criar um sistema de caixa em console usando condicionais e laços para cadastrar, consultar e vender produtos.

## Requisitos
- .NET 10 SDK
- Visual Studio 2022/2026 ou outro editor compatível

## Como executar
1. Abra a solução no Visual Studio ou use o terminal na pasta do projeto.
2. No terminal, execute:

   dotnet run --project SistemaDeCaixa

Ou execute a aplicação a partir do Visual Studio (Start / F5).

## Formato de entrada
- Produto: texto (nome exato usado para buscas e vendas).
- Preço: número decimal (use vírgula ou ponto conforme cultura do sistema).
- Quantidade: número inteiro.

Exemplo de entrada: "Arroz", "12.50", "10"

## Funcionalidades implementadas
- Cadastro de produtos (nome, preço, quantidade).
- Consulta de produtos por nome.
- Adição de produtos ao carrinho e atualização do estoque.
- Finalizar compra (exibe total).

## Comportamento atual e limitações
- Todos os dados ficam em memória (List). Ao encerrar o programa, os dados são perdidos.
- Todas as operações estão dentro do método Main (sem separação em funções).
- Não há validação robusta de entrada: int.Parse/float.Parse podem lançar exceções com entrada inválida.
- Finalizar compra apenas exibe o total; não zera o carrinho nem confirma pagamento.
- Consulta e busca usam comparação exata do nome; diferenças de maiúsculas/minúsculas não são tratadas.

## Exemplo de uso (fluxo)
1. Cadastrar produtos no estoque.
2. Consultar para visualizar preço e quantidade.
3. Comprar produtos adicionando-os ao carrinho.
4. Finalizar compra para ver o total.

## Melhorias sugeridas
- Extrair funcionalidades em métodos separados (cadastrar, consultar, comprar, finalizar).
- Validar entradas do usuário (TryParse) e tratar exceções.
- Tratar busca sem distinção entre maiúsculas/minúsculas e permitir correspondência parcial.
- Implementar persistência (arquivo/DB como MySQL) para manter o estoque entre execuções.
- Melhorar fluxo de finalização: opções de pagamento, zerar carrinho, gerar recibo.
- Padronização e organização do código
