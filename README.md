# ApiCatalogoAulas
Api para gerenciamento de catálogos de aulas e modulos

Para rodar esta aplicação deverá ser importado o database catalogodb.sql, que está disponivel no repositório. Você deverá ter instalado em sua máquina o gerenciador de banco de dados MySql versão 8.0.
Caso dúvida siga este tutorial para instalar o banco https://help.eset.com/esmc_install/71/pt-BR/mysql_windows.html

Após o sgbd instalado vamos importar o arquivo do banco para o seu servidor.
Segue o link com o tutorial para a importação do banco https://help.umbler.com/hc/pt-br/articles/202385865-MySQL-Importando-Exportando-um-banco-de-dados

Clone o projeto em sua máquina usando o comando $ git clone https://github.com/CruzLucass/ApiCatalogoAulas.git
Quando o projeto já estiver na sua máquina abra o arquivo appsettings.json e modifique o valor da propriedade "DefaultConnection", setando o Uid e o Pwd utilizado para logar no banco.

Depois de configurado a connection string basta dar um run no VisualStudio 2019 e deixar a api rodando. Irá abrir o Swagger com a documentação das chamadas da api.

Fique a vontade para testar as funções implementadas no Swagger.

Para clonar a aplicação frontend basta seguir este link https://github.com/CruzLucass/catalogo-aulas.git

Clone na sua máquina e utilize o comando yarn start no terminal do VSCode.

Para fazer login você pode usar as credenciais do admin que estão configuradas no banco.
email: lucas@live.com
password: Lukao1902++
