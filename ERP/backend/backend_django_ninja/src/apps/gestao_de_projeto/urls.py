# ./src/apps/gestao_de_projeto/urls.py

from django.urls import path, include
from .api import api

urlpatterns = [
	path('', include(api.urls())),
]