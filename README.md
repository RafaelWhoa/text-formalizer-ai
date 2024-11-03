# Text Formalizer

Um projeto básico de implementação de grpc. A aplicação envia a mensagem recebida pelo cliente para a api da openai formalizar o texto.

## Pré-requisitos

Antes de começar, você precisará ter o seguinte instalado:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/)

## Instalação

Siga estas etapas para executar o projeto localmente:

1. **Clone o repositório**

   Abra seu terminal e execute o seguinte comando:

   ```bash
   git clone https://github.com/RafaelWhoa/text-formalizer-ai.git
   ```

2. **Adicione seu Token**

   Navegue até a pasta do projeto clonado e localize o arquivo `appsettings.json`. Abra o arquivo e adicione seu token da openai na seção apropriada, como mostrado abaixo:

   ```json
   {
     "OpenAiToken": "seu_token_aqui"
   }
   ```

   1. **Execute o docker compose**

   Abra seu terminal na pasta da solução e execute o seguinte comando:

   ```bash
   docker compose up --build
   ```
   
