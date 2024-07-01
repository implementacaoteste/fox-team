# ./src/core/urls.py

from apps.cadastro.views.produto_view import produto_router
from apps.certifica.views.certificado_view import certificado_router
from apps.configuracao.views.grupo_de_usuario_view import grupo_de_usuario_router
from apps.configuracao.views.permissao_view import permissao_router
from apps.configuracao.views.usuario_view import usuario_router
from apps.gestao_de_projeto.views.comentario_view import comentario_router
from apps.gestao_de_projeto.views.historia_de_usuario_view import historia_de_usuario_router
from apps.gestao_de_projeto.views.projeto_view import projeto_router
from apps.gestao_de_projeto.views.sprint_view import sprint_router
from apps.gestao_de_projeto.views.status_de_historia_de_usuario_view import status_de_historia_de_usuario_router
from apps.gestao_de_projeto.views.status_de_tarefa_view import status_de_tarefa_router
from apps.gestao_de_projeto.views.tarefa_view import tarefa_router
from apps.restaurante.views.atendente_view import atendente_router
from apps.restaurante.views.bebida_view import bebida_router
from apps.restaurante.views.prato_view import prato_router
from django.contrib import admin
from django.urls import path
from ninja import NinjaAPI


api = NinjaAPI()

api.add_router("cadastro-produto", produto_router)
api.add_router("certifica", certificado_router)
api.add_router("configuracao-grupo", grupo_de_usuario_router)
api.add_router("configuracao-permissao", permissao_router)
api.add_router("configuracao-usuario", usuario_router)
api.add_router("gestao_de_projeto-comentario", comentario_router)
api.add_router("gestao_de_projeto-historia", historia_de_usuario_router)
api.add_router("gestao_de_projeto-projeto", projeto_router)
api.add_router("gestao_de_projeto-sprint", sprint_router)
api.add_router("gestao_de_projeto-status-tarefa", status_de_tarefa_router)
api.add_router("gestao_de_projeto-status-historia", status_de_historia_de_usuario_router)
api.add_router("gestao_de_projeto-tarefa", tarefa_router)
api.add_router("restaurante-atendente", atendente_router)
api.add_router("restaurante-bebida", bebida_router)
api.add_router("restaurante-prato", prato_router)

urlpatterns = [
    path('admin/', admin.site.urls),
    path('api/', api.urls),
]
