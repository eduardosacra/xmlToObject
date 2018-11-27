# Aplicação de exemplo de como desserializar xml em objetos utilizando c#, web api.

## Cenário: 
Nessa aplicação vou fornecer um serviço que prove informações sobre livros, a princípio será apenas um livro por requisição sendo buscado por ID, esse livro é fornecido pelo [fake rest api](https://fakerestapi.azurewebsites.net/Help/Api/GET-api-Books) (quem ainda não conhece recomendo que dem uma olhada), esse recurso prove as informações no formato XML, que então faço um mapeamento em uma classe que representará o Livro e realizo o processo de deserialização e instancio meu objeto, em seguida devolvo essa informação no formato json para o meu cliente.

### Para testar essa aplicação basta usar o comando git clone desse repositório e buildar o projeto e realizar uma requisição no recurso http://localhost:58427/api/produtos/ListarBooks/{id>0}


### TODO:
Mapear uma lista de livros para ser fornecido no mesmo recurso ListarBooks, quando não é enviado o parâmetro id
