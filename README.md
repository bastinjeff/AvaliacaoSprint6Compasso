AO INSTRUTOR QUE VAI AVALIAR O CÓDIGO:

O Banco de dados vai ser criado automaticamente via migrations, porém é importante citar que ele está setado para funcionar no endereço localhost\SQLEXPRESS, entrando via Integrated Security, sem necessidade de senha ou login por conta disso.

As requisições do POSTMAN precisam ser adequadas aos IDs existentes no banco de dados. As linhas são criadas utilizando GUID e portanto sempre terão um ID diferente a cada inserção. 

O ID em GUID do usuário precisa ser carregado junto de algumas requisições do SysProduto para que possa ser registrado corretamente no banco de dados da Auditoria.

Há muito espaço para melhoras nesse projeto, em especial na área da consistencia de banco de dados e no tratamento de excessões.

Bugs e problemas conhecidos:
  Se o ID de usuário nao existir ao carregar junto do sistema, a auditoria vai registrar da mesma maneira.
  A auditoria está registrando no MongoDB com um tipo de GUID diferente, chamado de LUUID.
  O banco de dados possui uma certa inconsistência ao buscar os produtos filtrados, sempre carregando consigo os produtos sem Tags ou Categorias quando elas são chamadas.
  As pesquisas de banco de dados estão mal otimizadas. Todas as tabelas são buscadas juntas e isso pode causar problemas se essa fosse uma API de larga escala.
  Não existe um "login" propriamente dito pois o sistema não tem entendimento sobre permanência de usuário. Faltou o uso de Token e Autenticação para isso.
  O tratamento de excessões é genérico, sem de fato resolver a excessão, apenas impedindo ela de travar o sistema inteiro.
  O registro de excessões no MongoDB poderia ser mais descritivo.

IMPORTANTE:
  Devido a falta de uso da permanencia do login, é NECESSÁRIO atualizar o ID do usuário no CORPO do get para buscar produtos, tanto por ID quanto por filtro. Ele é utilizado para gravar que usuário buscou qual produto dentro do sistema. Sem isso o codigo irá TRAVAR pois não foi colocado um try catch naquele trecho em especifico.

Qualquer duvida ou problema por favor me contatem via TEAMS ou meu telefone: (55) 9 9941-5691
