# Apontamento de Horarios

Um programa CLI simples que registra seu horario e dia e uma descricao sobre aquele apontamento.

Por enquanto ainda é um projeto bem simples, somente para fins de uso próprio

## Build

1. Baixe o repositório
2. Abra o Visual Studio usando a solution do repositório
3. Compile o projeto
4. Abra o terminal de comando
5. Vá até o diretório `bin\\Debug\\net'?'\\`, onde o "?" reflete a versão do dotnet instalada na sua máquina (na minha por exemplo está o dotnet 8, então ficaria o caminho `bin\\Debug\\net8.0\\`)
6. Execute o comando `Horarios.exe --descricao "uma simples descricao"` e espere ver no diretório em que o terminal se encontra um arquivo chamado "apontamentos.csv" sendo criado com o seu novo apontamento
7. Seja feliz :)

## To-do's

[] corrigir o processo de build, tornando o mais simples possivel

[] adicionar nos apontamentos um campo de horario final

[] (apenas para devs) ter um middleware para funcionar junto com o git
