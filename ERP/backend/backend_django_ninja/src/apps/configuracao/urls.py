# ./src/apps/configuracao/urls.py

from django.urls import path, include
from .api import api

urlpatterns = [
	path('', include(api.urls())),
]