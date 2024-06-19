# ./src/apps/gestao_de_projeto/api.py

from ninja import NinjaAPI
#from .views.produto_view import produto_router as router_produto

api = NinjaAPI(urls_namespace='gestao_de_projeto-api')
#api.add_router('produto', router_produto)