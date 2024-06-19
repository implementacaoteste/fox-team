# ./src/apps/gestao_de_projeto/apps.py

from django.apps import AppConfig

class Gestao_de_projetoConfig(AppConfig):
	default_auto_field = 'django.db.models.BigAutoField'
	name = 'apps.gestao_de_projeto'

# TODO: não esqueça de adicionar o seguinte conteúdo no INSTALLED_APPS do settings.py: 'apps.gestao_de_projeto',