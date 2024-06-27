# ./src/core/management/commands/rundjangoserver.py

from django.core.management.base import BaseCommand
from django.core.management import call_command
from django.db import connections
from django.db.utils import OperationalError
from time import sleep
import os
import logging

class Command(BaseCommand):
    help = 'Executa o servidor com migrações automáticas e dados iniciais'

    def add_arguments(self, parser):
        # Adiciona os argumentos do runserver
        parser.add_argument('addrport', nargs='?', default='8000',
                            help='Optional port number, or ipaddr:port')

    def esperar_banco_de_dados(self):
        self.stdout.write('Aguardando o banco de dados ficar disponível...')
        db_conn = None
        cont = 1
        while not db_conn:
            try:
                self.stdout.write(f"Tentativa: {cont}")
                cont += 1
                db_conn = connections['default']
                db_conn.cursor()
                self.stdout.write('Banco de dados disponível!')
                return True
            except OperationalError as e:
                self.stdout.write(f'Banco de dados não disponível, tentando novamente em 1 segundo... Erro: {e}')
                sleep(1)
        return False

    def handle(self, *args, **options):
        from django.conf import settings

        logging.basicConfig(level=logging.INFO)

        self.esperar_banco_de_dados()

        if os.getenv('DJANGO_INITIAL_SETUP_DONE', 'false') == 'false':
            self.stdout.write('Iniciando as migrações de contenttypes...')
            while True:
                try:
                    call_command('migrate', 'contenttypes')
                    break
                except OperationalError as e:
                    self.stdout.write(f'Erro durante migrate contenttypes, tentando novamente em 1 segundo... Erro: {e}')
                    logging.error(f'Erro durante migrate contenttypes: {e}', exc_info=True)
                    sleep(1)
            self.stdout.write('Migração de contenttypes concluída.')

            self.stdout.write('Iniciando as migrações...')
            while True:
                try:
                    call_command('makemigrations', '--noinput')
                    break
                except OperationalError as e:
                    self.stdout.write(f'Erro durante makemigrations, tentando novamente em 1 segundo... Erro: {e}')
                    logging.error(f'Erro durante makemigrations: {e}', exc_info=True)
                    sleep(1)
            self.stdout.write('Makemigrations concluído.')

            self.stdout.write('Aplicando migrações...')
            while True:
                try:
                    call_command('migrate')
                    break
                except OperationalError as e:
                    self.stdout.write(f'Erro durante migrate, tentando novamente em 1 segundo... Erro: {e}')
                    logging.error(f'Erro durante migrate: {e}', exc_info=True)
                    sleep(1)
            self.stdout.write('Migrate concluído.')

            self.stdout.write('Iniciando o seed de produtos...')
            while True:
                try:
                    call_command('seeds_produto')
                    break
                except OperationalError as e:
                    self.stdout.write(f'Erro durante seeds_produto, tentando novamente em 1 segundo... Erro: {e}')
                    logging.error(f'Erro durante seeds_produto: {e}', exc_info=True)
                    sleep(1)
            self.stdout.write('Seed de produtos concluído.')

            # Marque o setup inicial como concluído
            os.environ['DJANGO_INITIAL_SETUP_DONE'] = 'true'

        # Inicia o servidor
        endereco_porta = options['addrport']
        call_command('runserver', endereco_porta)