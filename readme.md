# Prova BonifiQ Backend
Devido à liberdade de alterações sugerida na descrição da avaliação, optei por modificar alguns aspectos e reescrever a arquitetura do projeto, visando torná-lo mais testável, escalável e alinhado com boas práticas de desenvolvimento.

## Arquitetura
Adotei uma arquitetura em camadas, seguindo os princípios da Clean Architecture, com o objetivo de separar responsabilidades e garantir a manutenibilidade do código. As camadas utilizadas são:

### Domain
A camada de domínio foi projetada para encapsular todas as regras de negócio e especificações do sistema, garantindo que não haja dependência de outras camadas ou pacotes externos. Nela:

 - Transformei os modelos em entidades, alterando a geração da chave primária para não depender do banco de dados.

 - Utilizei Design Patterns para definir e organizar as regras de negócio, que serão detalhados nas próximas seções.

 - Criei exceções personalizadas para um controle mais granular dos erros da aplicação.

 - Embora as validações das entidades possam ser incluídas aqui, optei por não implementá-las devido ao tempo limitado e à ausência de casos de uso que exigissem inclusão ou alteração de dados.

### Application
A camada de aplicação foi responsável por orquestrar as chamadas ao banco de dados e as regras de negócio definidas na camada de domínio. Aqui:

 - Transformei os serviços em casos de uso, alinhando-os aos conceitos da Clean Architecture.

 - Utilizei o padrão Mediator (através do pacote MediatR) para facilitar a comunicação entre a camada de apresentação e a de aplicação, promovendo o desacoplamento.

 - Adicionei Design Patterns relacionados à orquestração, que serão explicados posteriormente.

### Infrastructure
A camada de infraestrutura foi criada para isolar a comunicação com pacotes externos e frameworks, sem interferir nas regras de negócio. Nela:

 - Centralizei toda a comunicação com o banco de dados.

 - Criei modelos de representação de dados (DTOs) para separar a lógica de persistência das entidades de domínio, garantindo que as regras de negócio permaneçam independentes.

### Presentation
A camada de apresentação contém a API responsável pela entrada e saída de dados do sistema. Aqui:

 - Adicionei instruções para facilitar a documentação automática via Swagger.

 - Implementei um filtro global para processar exceções e padronizar as respostas de erro.

 - A comunicação com a camada de aplicação foi feita através do padrão Mediator, conforme mencionado anteriormente.

## Correções e Melhorias
### Parte1Controller
Para corrigir o problema da geração de números aleatórios:

 - Movi a regra de negócio para a camada de domínio, na entidade RandomNumberEntity.

 - Adicionei uma verificação para evitar a inserção de números duplicados no banco de dados.

### Parte2Controller
Na correção da parte 2:

 - Resolvi o problema de paginação na consulta ao banco de dados.

 - Utilizei injeção de dependência para eliminar más práticas e melhorar a testabilidade.

 - Criei classes genéricas e abstratas para padronizar a paginação e evitar repetição de código nas requisições de listagem de produtos e clientes.

### Parte3Controller
Para a parte 3:

 - Adicionei a conversão da data armazenada no banco de dados (UTC) para o fuso horário UTC-3 na classe OrderResponse, utilizada como retorno da API.

 - Para respeitar o princípio Open-Closed, utilizei os seguintes padrões:

    - Strategy: Para definir uma interface comum aos métodos de pagamento.

    - Factory: Para instanciar o método de pagamento correto com base no parâmetro fornecido pelo usuário.

    - Facade: Para encapsular a lógica de pagamento, simplificando o código e facilitando a criação de testes.

 - Esses padrões permitem adicionar novos métodos de pagamento de forma desacoplada: basta implementar a interface IPaymentStrategy, e o PaymentFactory reconhecerá automaticamente a nova forma de pagamento.

### Parte4Controller
Para cumprir essa parte do desafio:

 - Reestruturei a arquitetura e utilizei os seguintes padrões:

    - Specification: Para isolar cada regra de negócio em uma classe específica.

    - Composite: Para agrupar as regras de negócio relacionadas à verificação de compra.

    - Factory: Para facilitar a criação da composição das regras.

 - Esses padrões permitiram separar as regras de negócio, facilitar os testes e criar uma estrutura flexível para adicionar novas regras no futuro.

### Testes
Adotei o padrão TDD (Test-Driven Development) durante o desenvolvimento, criando testes unitários para a maior parte do projeto. Além disso implementei alguns testes de integração para validar a comunicação entre o banco de dados e os casos de uso.

## Conclusão
Desenvolvi o projeto aplicando as melhores práticas que conheço, buscando torná-lo desacoplado, testável e escalável. Embora algumas melhorias adicionais possam ser implementadas, optei por priorizar a entrega dentro do prazo estipulado.

Agradeço pela oportunidade e fico à disposição para qualquer esclarecimento adicional. Espero que gostem do resultado!

Muito obrigado!
