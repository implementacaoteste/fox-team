# ./scripts/criar_entidade.py

import os
import sys

def camel_case(snake_str):
    components = snake_str.split('_')
    return ''.join(x.title() for x in components)

def criar_entidade(caminho_arquivo, conteudo):
    with open(caminho_arquivo, 'w') as f:
        f.write(conteudo)

def verbose(texto):
    mapeamento_singular = {
        'usuario': 'usuário',
        'email': 'e-mail'
        # Adicione mais mapeamentos aqui conforme necessário
    }

    palavras = texto.split('_')
    palavras_substituidas = []

    for palavra in palavras:
        if palavra in mapeamento_singular:
            palavra_substituida = mapeamento_singular[palavra]
        elif palavra.endswith('ao'):
            palavra_substituida = palavra[:-2] + 'ão'
        else:
            palavra_substituida = palavra
        palavras_substituidas.append(palavra_substituida)

    return ' '.join(palavras_substituidas)

def verbose_plural(texto):
    mapeamento_singular = {
        'usuario': 'usuário',
        'email': 'e-mail'
        # Adicione mais mapeamentos aqui conforme necessário
    }
    
    mapeamento_plural = {
        'usuario': 'usuários',
        'email': 'e-mails'
        # Adicione mais mapeamentos aqui conforme necessário
    }

    palavras = texto.split('_')
    palavras_substituidas = []

    for palavra in palavras:
        # Primeiro, aplica o método verbose para garantir substituições específicas de singular
        palavra_verbose = verbose(palavra)

        # Verifica e substitui terminações em 'são'
        if palavra_verbose.endswith('são'):
            palavra_verbose = palavra_verbose[:-3] + 'sões'
        # Verifica e substitui terminações em 'ção', desde que não tenha sido substituída anteriormente por verbose
        elif palavra_verbose.endswith('ção'):
            palavra_verbose = palavra_verbose[:-3] + 'ções'
        # Aplica substituições mapeadas ou adiciona 's' conforme a especificação
        elif palavra_verbose in mapeamento_plural:
            palavra_verbose = mapeamento_plural[palavra_verbose]
        elif palavra_verbose not in ['de', 'a']:
            palavra_verbose += 's'

        palavras_substituidas.append(palavra_verbose)
    
    # Trata 'grupo_de' especificamente
    if 'grupo' in palavras and 'de' in palavras:
        palavras_substituidas[palavras.index('grupo')] = 'grupos'

    return ' '.join(palavras_substituidas)


def main(nome_app, nome_entidade, artigo):
    caminho_base = os.path.join('../src', 'apps', nome_app)
    nome_da_classe = camel_case(nome_entidade)

    # Diretórios e arquivos a serem criados
    caminhos_e_conteudos = [
        (os.path.join(caminho_base, 'models', f'{nome_entidade}.py'), 
         f"# ./src/apps/{nome_app}/models/{nome_entidade}.py\n\n"
         f"from django.db import models\n"
         f"from django.db.models import UniqueConstraint, Index\n\n"
         f"class {nome_da_classe}(models.Model):\n"
         f"\t# TODO: Adicione aqui os atributos da classe.\n"
         f"\tdescricao = models.CharField(max_length=150)\n"
         f"\tativo = models.BooleanField(default=True)\n\n"
         f"\tdef __str__(self):\n"
         f"\t\treturn self.descricao\n"
         f"\n\tclass Meta:\n"
         f"\t\tverbose_name = '{verbose(nome_entidade)}'\n"
         f"\t\tverbose_name_plural = '{verbose_plural(nome_entidade)}'\n"
         f"\t\tdb_table = '{nome_entidade}'\n"
         f"\t\tconstraints = [\n"
         f"\t\t\tUniqueConstraint(fields=['descricao_{nome_entidade}'], name='unique_descricao_{nome_entidade}'),\n"
         f"\t\t]\n"
         f"\t\tindexes = [\n"
         f"\t\t\tIndex(fields=['descricao_{nome_entidade}'], name='idx_descricao_{nome_entidade}'),\n"
         f"\t\t]"),

        (os.path.join(caminho_base, 'data', f'{nome_entidade}_data.py'), 
         f"# ./src/apps/{nome_app}/data/{nome_entidade}_data.py\n\n"
         f"import logging\n"
         f"from django.db.utils import IntegrityError\n"
         f"from ..models.{nome_entidade} import {nome_da_classe}\n\n"
         f"class {nome_da_classe}Data:\n"
         "\t@staticmethod\n"
         "\tdef inserir(dados):\n"
         f"\t\treturn {nome_da_classe}.objects.create(**dados)\n\n"
         "\t@staticmethod\n"
         "\tdef buscar_todos():\n"
         f"\t\treturn {nome_da_classe}.objects.all()\n\n"
         "\t@staticmethod\n"
         f"\tdef buscar_por_id(id):\n"
         f"\t\treturn {nome_da_classe}.objects.get(id=id)\n\n"
         "\t@staticmethod\n"
         f"\tdef alterar({nome_entidade}, dados):\n"
         f"\t\tfor attr, valor in dados.items():\n"
         f"\t\t\tsetattr({nome_entidade}, attr, valor)\n"
         f"\t\t{nome_entidade}.save()\n"
         f"\t\treturn {nome_entidade}\n\n"
         "\t@staticmethod\n"
         f"\tdef excluir({nome_entidade}):\n"
         f"\t\t{nome_entidade}.delete()\n"),

        (os.path.join(caminho_base, 'services', f'{nome_entidade}_service.py'), 
         f"# ./src/apps/{nome_app}/services/{nome_entidade}_service.py\n\n"
         f"import logging\n"
         f"from django.db.utils import IntegrityError\n"
         f"from ..data.{nome_entidade}_data import {nome_da_classe}Data\n\n"
         f"class {nome_da_classe}Service:\n"
         f"\t@staticmethod\n"
         f"\tdef inserir(dados):\n"
         f"\t\tlogging.info(f\"Inserir {verbose(nome_entidade)} com os seguintes dados: {{dados}}\")\n"
         f"\t\ttry:\n"
         f"\t\t\treturn {nome_da_classe}Data.inserir(dados)\n"
         f"\t\texcept IntegrityError as e:\n"
         f"\t\t\traise ValueError(f\"Erro ao inserir {verbose(nome_entidade)}: {{str(e)}}\")\n"
         f"\t\texcept Exception as e:\n"
         f"\t\t\traise ValueError(f\"Erro inesperado ao inserir {verbose(nome_entidade)}: {{str(e)}}\")\n\n"
         f"\t@staticmethod\n"
         f"\tdef buscar_todos():\n"
         f"\t\tlogging.info(f\"Buscar todos os {verbose_plural(nome_entidade)}\")\n"
         f"\t\ttry:\n"
         f"\t\t\treturn {nome_da_classe}Data.buscar_todos()\n"
         f"\t\texcept IntegrityError as e:\n"
         f"\t\t\traise ValueError(f\"Erro ao buscar tod{artigo}s {artigo}s {verbose_plural(nome_entidade)}: {{str(e)}}\")\n"
         f"\t\texcept Exception as e:\n"
         f"\t\t\traise ValueError(f\"Erro inesperado ao buscar tod{artigo}s {artigo}s {verbose_plural(nome_entidade)}: {{str(e)}}\")\n\n"
         f"\t@staticmethod\n"
         f"\tdef buscar_por_id(id):\n"
         f"\t\tlogging.info(f\"Buscar {verbose(nome_entidade)} por id\")\n"
         f"\t\ttry:\n"
         f"\t\t\treturn {nome_da_classe}Data.buscar_por_id(id)\n"
         f"\t\texcept IntegrityError as e:\n"
         f"\t\t\traise ValueError(f\"Erro ao buscar {verbose(nome_entidade)} por id: {{str(e)}}\")\n"
         f"\t\texcept Exception as e:\n"
         f"\t\t\traise ValueError(f\"Erro inesperado ao buscar {verbose(nome_entidade)} por id: {{str(e)}}\")\n\n"
         f"\t@staticmethod\n"
         f"\tdef alterar(id, dados):\n"
         f"\t\tlogging.info(f\"Alterar {verbose(nome_entidade)} de id: {{id}}, com os dados: {{dados}}\")\n"
         f"\t\ttry:\n"
         f"\t\t\t{nome_entidade} = {nome_da_classe}Data.buscar_por_id(id)\n"
         f"\t\t\treturn {nome_da_classe}Data.alterar({nome_entidade}, dados)\n"
         f"\t\texcept IntegrityError as e:\n"
         f"\t\t\traise ValueError(f\"Erro ao alterar {verbose(nome_entidade)}: {{str(e)}}\")\n"
         f"\t\texcept Exception as e:\n"
         f"\t\t\traise ValueError(f\"Erro inesperado ao alterar {verbose(nome_entidade)}: {{str(e)}}\")\n\n"
         f"\t@staticmethod\n"
         f"\tdef excluir(id):\n"
         f"\t\tlogging.info(f\"Excluir {verbose(nome_entidade)} de id: {{id}}\")\n"
         f"\t\ttry:\n"
         f"\t\t\t{nome_entidade} = {nome_da_classe}Data.buscar_por_id(id)\n"
         f"\t\t\t{nome_da_classe}Data.excluir({nome_entidade})\n"
         f"\t\t\tlogging.info(f\"{verbose(nome_entidade)} excluíd{artigo}: {{{nome_entidade}}}\")\n"
         f"\t\texcept IntegrityError as e:\n"
         f"\t\t\traise ValueError(f\"Erro ao excluir {verbose(nome_entidade)}: {{str(e)}}\")\n"
         f"\t\texcept Exception as e:\n"
         f"\t\t\traise ValueError(f\"Erro inesperado ao excluir {verbose(nome_entidade)}: {{str(e)}}\")\n"),

        (os.path.join(caminho_base, 'views', f'{nome_entidade}_view.py'), 
         f"# ./src/apps/{nome_app}/views/{nome_entidade}_view.py\n\n"
         "from ninja import Router\n"
         f"from ..schemas.{nome_entidade}_schema import {nome_da_classe}Schema\n"
         f"from ..services.{nome_entidade}_service import {nome_da_classe}Service\n\n"
         f"{nome_entidade}_router = Router()\n\n"
         f"@{nome_entidade}_router.get(\"/{nome_entidade}/\")\n"
         "def buscar_todos(request):\n"
         f"\t{nome_entidade}_lista = {nome_da_classe}Service.buscar_todos()\n"
         f"\treturn [{nome_da_classe}Schema.from_orm({nome_entidade}) for {nome_entidade} in {nome_entidade}_lista]\n\n"
         f"@{nome_entidade}_router.post(\"/{nome_entidade}/\")\n"
         f"def inserir(request, {nome_entidade}: {nome_da_classe}Schema):\n"
         f"\t{nome_entidade} = {nome_da_classe}Service.inserir({nome_entidade}.dict())\n"
         f"\treturn {nome_da_classe}Schema.from_orm({nome_entidade})\n\n"
         f"@{nome_entidade}_router.get(\"/{nome_entidade}/{{id}}\")\n"
         "def buscar_por_id(request, id: int):\n"
         f"\t{nome_entidade} = {nome_da_classe}Service.buscar_por_id(id)\n"
         f"\treturn {nome_da_classe}Schema.from_orm({nome_entidade})\n\n"
         f"@{nome_entidade}_router.put(\"/{nome_entidade}/{{id}}\")\n"
         f"def alterar(request, id: int, {nome_entidade}: {nome_da_classe}Schema):\n"
         f"\t{nome_entidade} = {nome_da_classe}Service.alterar(id, {nome_entidade}.dict())\n"
         f"\treturn {nome_da_classe}Schema.from_orm({nome_entidade})\n\n"
         f"@{nome_entidade}_router.delete(\"/{nome_entidade}/{{id}}\")\n"
         "def excluir(request, id: int):\n"
         f"\t{nome_da_classe}Service.excluir(id)\n\t"
         f"return {{\"mensagem\": \"{verbose(nome_entidade)} excluíd{artigo} com sucesso!\"}}\n\n"
         "# TODO: Importar a router no urls.py do core:\n\n"
         f"# from apps.{nome_app}.views.{nome_entidade}_view import {nome_entidade}_router\n\n"
         f"# api.add_router(\"{nome_app}\", {nome_entidade}_router)\n\n"),

        (os.path.join(caminho_base, 'schemas', f'{nome_entidade}_schema.py'), 
         f"# ./src/apps/{nome_app}/schemas/{nome_entidade}_schema.py\n\n"
         "from ninja import Schema\n\n"
         f"class {nome_da_classe}Schema(Schema):\n"
         "\t# TODO: Coloque aqui as colunas do schema.\n"
         "\t# descricao: str\n"
         "\t# ativo: bool\n"
         "\tpass\n")
    ]

    # Cria os diretórios e arquivos com os conteúdos especificados
    for caminho_arquivo, conteudo in caminhos_e_conteudos:
        os.makedirs(os.path.dirname(caminho_arquivo), exist_ok=True)
        criar_entidade(caminho_arquivo, conteudo)
        os.makedirs(os.path.dirname(caminho_arquivo), exist_ok=True)
        criar_entidade(caminho_arquivo, conteudo)

if __name__ == "__main__":
    if len(sys.argv) != 4:
        print("Uso: python3 criar_estrutura_entidade.py <NOME_APP> <NOME_ENTIDADE> <ARTIGO>")
        sys.exit(1)

    nome_app = sys.argv[1]
    nome_entidade = sys.argv[2]
    artigo = sys.argv[3]
    main(nome_app, nome_entidade, artigo)
